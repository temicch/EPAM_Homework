namespace Matrix
{
    /// <summary>
    ///     Contains methods for working with integer matrices of arbitrary size.
    /// </summary>
    public class Matrix
    {
        private readonly int[,] matrix;

        public MatrixSize Size;

        /// <summary>
        ///     Initialize a rectangular matrix filled with zeros with the specified number of <see langword="rows" /> and
        ///     <see langword="columns" />.
        /// </summary>
        /// <param name="rowsCount">Number of rows</param>
        /// <param name="columnsCount">Number of columns</param>
        public Matrix(int rowsCount, int columnsCount) : this(new MatrixSize(rowsCount, columnsCount))
        {
        }

        /// <summary>
        ///     Initialize a square matrix filled with zeros with the specified number of <see langword="rows" />.
        /// </summary>
        /// <param name="rows">Number of columns</param>
        public Matrix(int rows) : this(new MatrixSize(rows))
        {
        }

        public Matrix(MatrixSize matrixSize)
        {
            Size = matrixSize;
            matrix = new int[matrixSize.Rows, matrixSize.Columns];
        }

        public Matrix() : this(new MatrixSize(MatrixSize.DefaultSize))
        {
        }

        private int ColumnsCount => Size.Columns;
        private int RowsCount => Size.Rows;

        public int this[int i, int j]
        {
            get => matrix[i, j];
            set => matrix[i, j] = value;
        }

        /// <summary>
        ///     This method checks if the matrix is ​​identity.
        /// </summary>
        /// <returns><see langword="true" /> if identity</returns>
        public bool IsIdentity()
        {
            if (ColumnsCount != RowsCount)
                return false;
            for (var i = 0; i < RowsCount; i++)
            for (var j = 0; j < ColumnsCount; j++)
            {
                if (this[i, j] == 1 && i == j)
                    continue;
                if (this[i, j] != 0 && i != j)
                    return false;
            }

            return true;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.ColumnsCount != b.RowsCount)
                throw new MatrixInvalidOperationException(
                    "Matrix multiplication is only possible if the number of columns in the first matrix is ​​equal to the number of rows in the second matrix.",
                    a.Size, b.Size);

            var matrixC = new Matrix(a.RowsCount, b.ColumnsCount);

            for (var i = 0; i < a.RowsCount; i++)
            for (var j = 0; j < b.ColumnsCount; j++)
            {
                matrixC[i, j] = 0;

                for (var k = 0; k < a.ColumnsCount; k++)
                    matrixC[i, j] += a[i, k] * b[k, j];
            }

            return matrixC;
        }

        public static Matrix operator *(Matrix a, int b)
        {
            var resMatrix = new Matrix(a.RowsCount, a.ColumnsCount);
            for (var i = 0; i < a.RowsCount; i++)
            for (var j = 0; j < a.ColumnsCount; j++)
                resMatrix[i, j] = a[i, j] * b;
            return resMatrix;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.ColumnsCount != b.ColumnsCount && a.RowsCount != b.RowsCount)
                throw new MatrixInvalidOperationException(
                    "The difference between the two matrices is possible only with the same size.", a.Size, b.Size);
            var resMass = new Matrix(a.RowsCount, a.ColumnsCount);
            for (var i = 0; i < a.RowsCount; i++)
            for (var j = 0; j < b.ColumnsCount; j++)
                resMass[i, j] = a[i, j] - b[i, j];
            return resMass;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.ColumnsCount != b.ColumnsCount && a.RowsCount != b.RowsCount)
                throw new MatrixInvalidOperationException(
                    "The sum of two matrices is possible only if they are the same size.", a.Size, b.Size);
            var resMass = new Matrix(a.RowsCount, a.ColumnsCount);
            for (var i = 0; i < a.RowsCount; i++)
            for (var j = 0; j < b.ColumnsCount; j++)
                resMass[i, j] = a[i, j] + b[i, j];
            return resMass;
        }

        /// <summary>
        ///     Initializes a square matrix filled with zeros.
        /// </summary>
        /// <param name="columnsCount"></param>
        /// <returns></returns>
        public static Matrix GetEmpty(int columnsCount)
        {
            return new Matrix(columnsCount);
        }

        /// <summary>
        ///     Initializes a rectangular matrix filled with zeros.
        /// </summary>
        /// <param name="columnsCount">Number of columns</param>
        /// <param name="rowsCount">Number of rows</param>
        /// <returns></returns>
        public static Matrix GetEmpty(int columnsCount, int rowsCount)
        {
            return new Matrix(rowsCount, columnsCount);
        }
    }
}