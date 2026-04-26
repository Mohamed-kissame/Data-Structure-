using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //MatrixUtility matrix = new MatrixUtility(3, 3);


            //matrix.SetValue(0, 0, 1);
            //matrix.SetValue(0, 1, 2);
            //matrix.SetValue(0, 2, 3);

            //matrix.SetValue(1, 0, 4);
            //matrix.SetValue(1, 1, 5);
            //matrix.SetValue(1, 2, 6);

            //matrix.SetValue(2, 0, 7);
            //matrix.SetValue(2, 1, 8);
            //matrix.SetValue(2, 2, 9);


            //matrix.Display();


            //Console.WriteLine("\nEnter the Position of Row : ");
            //int row = Convert.ToInt32(Console.ReadLine());


            //Console.WriteLine("\nEnter the Position of Col : ");
            //int col = Convert.ToInt32((Console.ReadLine()));


            //Console.WriteLine($"\nthe value of position [{row}][{col}] equal : {matrix.GetValue(row , col)} ");

            //Console.ReadLine();



            //MatrixUtility matrix1 = new MatrixUtility(4, 4);

            //matrix1.FillSequential();

            //matrix1.Display();


            //int sum = matrix.SumAll();

            //Console.WriteLine($"The Total of all values inside the matrix its : {sum} ");


            //Console.WriteLine("\nEnter the Position of Row that you wanna to sum : ");
            //int row = Convert.ToInt32(Console.ReadLine());

            //int sumRow = matrix.RowSum(row);

            //Console.WriteLine($"\nThe Total of all values inside the Row {row} its : {sumRow} ");


            //Console.WriteLine("\nEnter the Position of Col that you wanna to sum : ");
            //int Col = Convert.ToInt32(Console.ReadLine());

            //int ColumnSum = matrix.ColumnSum(Col);

            //Console.WriteLine($"\nThe Total of all values inside the Column {Col} its : {ColumnSum} ");


            //Console.WriteLine($"The Main Diagonal sum its  : {matrix.MainDiagonalSum()}");

            //Console.WriteLine($"The Secondray Diagonal sum its  : {matrix.SecondaryDiagonalSum()}");


            //matrix.Transpose();



            MatrixUtility matrix2 = new MatrixUtility(3, 3);


            matrix2.SetValue(0, 0, 1);
            matrix2.SetValue(0, 1, 0);
            matrix2.SetValue(0, 2, 0);

            matrix2.SetValue(1, 0, 0);
            matrix2.SetValue(1, 1, 1);
            matrix2.SetValue(1, 2, 0);

            matrix2.SetValue(2, 0, 0);
            matrix2.SetValue(2, 1, 0);
            matrix2.SetValue(2, 2, 1);


            matrix2.Display();

            if (matrix2.IsIdentity()())
            {

                Console.WriteLine("yes this matrix is identity");
            }
            else
            {

                Console.WriteLine("No this is not identity matrix");
            }



        }
    }
}
