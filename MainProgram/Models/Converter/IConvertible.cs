namespace Converter
{
    public interface IConvertible
    {
        /// <summary>
        /// Converts a block of code written in VisualBasic to a block of code in C#
        /// </summary>
        /// <param name="str">A block of code written in VisualBasic</param>
        /// <returns>C# block code</returns>
        string ConvertToCSharp(string str);
        /// <summary>
        /// Converts a block of code written in C# to a block of code in VisualBasic
        /// </summary>
        /// <param name="str">A block of code written in C#</param>
        /// <returns>VisualBasic block code</returns>
        string ConvertToVB(string str);
    }
}
