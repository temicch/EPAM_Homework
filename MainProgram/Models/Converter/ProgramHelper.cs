using System;

namespace Converter
{
    public class ProgramHelper : ProgramConverter, ICodeChecker
    {
        public bool CheckCodeSyntax(string code, Language type)
        {
            switch (type)
            {
                case Language.CSharp_Code:
                    return IsCSharpCode(code);
                case Language.VB_Code:
                    return IsVisualBasicCode(code);
                default:
                    throw new ArgumentException("Incorrect language");
            }
        }

        private bool IsVisualBasicCode(string str)
        {
            if (str.Contains("Module") || str.Contains("Dim") || str.Contains("Sub"))
                return true;
            return false;
        }

        private bool IsCSharpCode(string str)
        {
            if (str.Contains("namespace") || str.Contains("var"))
                return true;
            return false;
        }
    }
}