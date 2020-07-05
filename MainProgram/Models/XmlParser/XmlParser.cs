using NLog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace Task12
{
    public static class XmlParser
    {
        public const string MissingNode = "N/A";
#warning Not implemented
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IDictionary<string, int> EvaluateFile(string filePath, string xpathExpression)
        {
            IDictionary<string, int> result = CreateDictionary();

            ParseFile(filePath, xpathExpression, ref result);

            return result.SortByValues();
        }

        public static IDictionary<string, int> EvaluateFiles(IEnumerable<string> files, string xpathExpression)
        {
            IDictionary<string, int> result = CreateDictionary();

            Parallel.ForEach(files, (filePath) =>
            {
                ParseFile(filePath, xpathExpression, ref result);
            });

            return result.SortByValues();
        }

        public static IDictionary<string, int> EvaluateDirectory(string path, string xpathExpression)
        {
            return EvaluateFiles(Directory.EnumerateFiles(path), xpathExpression);
        }

        private static void ParseFile(string filePath, string xpathExpression, ref IDictionary<string, int> dictionary)
        {
            try
            {
                XPathNavigator navigator = CreateNavigator(filePath);
                XmlNamespaceManager nsmgr = GetRootNamespace(navigator);

                GetOccurrences(xpathExpression, dictionary, navigator, nsmgr);
            }
            catch (Exception exception)
            {
                logger.Error(exception);
            }
        }

        private static IDictionary<string, int> CreateDictionary()
        {
            return new ConcurrentDictionary<string, int>();
        }

        private static void GetOccurrences(string xpathExpression, IDictionary<string, int> result, XPathNavigator navigator, XmlNamespaceManager nsmgr)
        {
            var occurrences = navigator.Evaluate($"descendant::nspace:{xpathExpression}", nsmgr) as XPathNodeIterator;
            foreach (XPathNavigator node in occurrences)
            {
                result.IncrementValueByKey(node.InnerXml);
            }
            if (occurrences.Count == 0)
            {
                result.IncrementValueByKey(MissingNode);
            }
        }

        private static XPathNavigator CreateNavigator(string filePath)
        {
            XPathDocument document = new XPathDocument(filePath);
            XPathNavigator navigator = document.CreateNavigator();
            return navigator;
        }

        private static XmlNamespaceManager GetRootNamespace(XPathNavigator navigator)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(navigator.NameTable);
            var rootNamespace = navigator.Evaluate("namespace-uri(/*)");
            nsmgr.AddNamespace("nspace", rootNamespace.ToString());
            return nsmgr;
        }
    }
    internal static class DictionaryExtension
    {
        public static IDictionary<T, int> SortByValues<T>(this IDictionary<T, int> dictionary)
        {
            return dictionary.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
        }

        public static void IncrementValueByKey<T>(this IDictionary<T, int> dictionary, T key)
        {
            lock (dictionary)
            {
                if (!dictionary.ContainsKey(key))
                    dictionary[key] = 0;
                dictionary[key]++;
            }
        }
    }
}
