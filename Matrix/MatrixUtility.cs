using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class MatrixUtility
    {

        private int[,] _matrix;
        private int _rows;
        private int _cols;


        public MatrixUtility(int Row , int Col)
        {

            if (Row <= 0 || Col <= 0)
                throw new ArgumentException("Rows and Columns must be greater than zero");

            _rows = Row;
            _cols = Col;

            _matrix = new int[Row, Col];

        }



        public void SetValue(int row, int col , int value)
        {

            if(!((row >= 0 && row < _rows) && (col >= 0 && col < _cols))) return;

           

            _matrix[row, col] = value;

        }

        public int GetValue(int Row , int Col)
        {
            if (!((Row >= 0 && Row < _rows) && (Col >= 0 && Col < _cols))) return -1;

            return _matrix[Row, Col];


        }


        public void Display()
        {

            for (int i = 0; i < _rows; i++)
            {

                Console.Write("[");

                for (int j = 0; j < _cols; j++)
                {

                    Console.Write(_matrix[i,j]);

                    if (j < _cols -1 )
                    {
                        Console.Write(",");
                    }
                    

                }

                Console.WriteLine("]");


            }

        }

        public void FillSequential()
        {

            int counter = 1;


            for (int i = 0; i < _rows; i++)
            {

                for (int j = 0; j < _cols; j++)
                {

                    _matrix[i, j] = counter++;

                }

            }

        }

        public int SumAll()
        {

            int sum = 0;

            for (int i = 0; i < _rows; i++)
            {

                for (int j = 0; j < _cols; j++)
                {

                    sum += _matrix[i, j];

                }

            }

            return sum;


        }

        public int RowSum(int Row)
        {

            if (Row < 0 || Row >= _rows)
                return -1;

            int sumRow = 0;


            for (int i = 0; i < _cols; i++)
            {
                
                sumRow += _matrix[Row,i];

            }



            return sumRow;


        }


        public int ColumnSum(int Col)
        {

            if (Col < 0 || Col >= _cols)
                return -1;

            int ColSum = 0;


            for (int i = 0; i < _rows; i++)
            {

                ColSum += _matrix[i, Col];

            }



            return ColSum;


        }


        public string Search(int value)
        {


            for (int i = 0; i < _rows; i++)
            {

                for (int j = 0; j < _cols; j++)
                {


                    if (_matrix[i, j] == value)
                    {

                        return $"[{i},{j}]";

                      

                    }

                    
                }

            }

            return "The Value its not found"; 

        }


        public int MainDiagonalSum()
        {


            if (_rows != _cols)
                throw new ArgumentException("Matrix must be square.");

            int MainDiagonalRow = 0;

            for (int i = 0; i < _rows; i++)
            {
                
                MainDiagonalRow += _matrix[i, i];

            }

            return MainDiagonalRow;

        }


        public int SecondaryDiagonalSum()
        {


            if (_rows != _cols)
                throw new ArgumentException("Matrix must be square.");

            int SecondrayDiagonalSum = 0;

            for (int i = 0; i < _rows; i++)
            {


                SecondrayDiagonalSum += _matrix[i, _cols - 1 - i];


            }

            return SecondrayDiagonalSum;

        }

        public bool IsSymmetric()
        {


            if(_rows != _cols) throw new ArgumentException("Rows and Columns must be square");


            for (int i = 0; i < _rows; i++)
            {

                for (int j = 0; j < _cols; j++)
                {

                    if (_matrix[i,j] != _matrix[j, i])
                        { return false; }
                    
                }

            }

            return true;

        }

        public int[,] Transpose()
        {

            int[,]Transpose = new int[_cols, _rows];

            for (int i = 0; i < _rows; i++)
            {

                for (int j = 0; j < _cols; j++)
                {
                    Transpose[j,i] = _matrix[i,j];
                }



            }

            return Transpose;

        }


        public bool IsIdentity()
        {

            if (_rows != _cols)
                return false;



            for (int i = 0; i < _rows; i++)
            {

                for (int j = 0; j < _cols; j++)
                {

                    if (i == j && _matrix[i, j] != 1)
                        return false;

                    if (i != j && _matrix[i, j] != 0)
                        return false;
                }

            }

            return true;

           

        }


    }
}
