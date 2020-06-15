namespace Converter
{
    public class ProgramConverter : IConvertible
    {
        public string ConvertToCSharp(string str)
        {
            return "(C#) var";
        }

        public string ConvertToVB(string str)
        {
            return "(VisualBasic) Module";
        }
    }
}
