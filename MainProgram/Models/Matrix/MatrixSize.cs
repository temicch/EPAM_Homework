namespace Matrix
{
    /// <summary>
    ///     Represents matrix sizes in <see langword="rows" /> and <see langword="columns" />
    /// </summary>
    public readonly struct MatrixSize
    {
        internal static readonly int DefaultSize = 3;
        public int Columns { get; }
        public int Rows { get; }

        /// <summary>
        ///     Initialize the matrix size structure with the specified number of <see langword="rows" /> and
        ///     <see langword="columns" />
        /// </summary>
        /// <param name="rows">Number of rows</param>
        /// <param name="columns">Number of columns</param>
        public MatrixSize(int rows, int columns)
        {
            Columns = columns;
            Rows = rows;
        }

        /// <summary>
        ///     Initialize the matrix size structure with the specified <see langword="rows" /> x <see langword="rows" /> size
        /// </summary>
        /// <param name="rows">Number of rows</param>
        public MatrixSize(int rows)
        {
            Columns = rows;
            Rows = rows;
        }
    }
}