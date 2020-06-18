using System;

namespace Matrix
{
    public class MatrixInvalidOperationException : InvalidOperationException
    {
        public MatrixInvalidOperationException()
        {
        }

        public MatrixInvalidOperationException(string message)
            : base(message)
        {
        }

        public MatrixInvalidOperationException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public MatrixInvalidOperationException(string message, Exception inner, MatrixSize matrixSize)
            : base(message, inner)
        {
            FirstMatrixSize = matrixSize;
        }

        public MatrixInvalidOperationException(string message, Exception inner, MatrixSize firstMatrixSize,
            MatrixSize secondMatrixSize)
            : base(message, inner)
        {
            FirstMatrixSize = firstMatrixSize;
            SecondMatrixSize = secondMatrixSize;
        }

        public MatrixInvalidOperationException(string message, MatrixSize matrixSize)
            : this(message, null, matrixSize)
        {
        }

        public MatrixInvalidOperationException(string message, MatrixSize firstMatrixSize, MatrixSize secondMatrixSize)
            : this(message, null, firstMatrixSize, secondMatrixSize)
        {
        }

        public MatrixSize FirstMatrixSize { get; }
        public MatrixSize SecondMatrixSize { get; }
    }
}