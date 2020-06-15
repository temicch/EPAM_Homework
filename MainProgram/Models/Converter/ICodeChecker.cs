namespace Converter
{
    public interface ICodeChecker
    {
        /// <summary>
        /// This method checks if the specified string is a code block of the specified language
        /// </summary>
        /// <param name="code">Code block</param>
        /// <param name="type">Language used</param>
        /// <returns>True if string is a code block of specified language</returns>
        bool CheckCodeSyntax(string code, Language type);
    }
}
