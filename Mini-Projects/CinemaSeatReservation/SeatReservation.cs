using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSeatReservation
{
    public class SeatReservation
    {


        private int[,] _Seats;
        private int _Rows;
        private int _Columns;
        private int _TotalReserveSeats;
        private int _TotalSeats;

        public SeatReservation(int Rows , int Colums)
        {

            if (Rows <= 0 || Colums <= 0)
                throw new ArgumentException("Rows and Columns must be greater than zero");

            _Rows = Rows;
            _Columns = Colums;

            _Seats = new int[Rows, Colums];

            _TotalReserveSeats = 0;

            _TotalSeats = Rows * _Columns;
            
        }

        public int CountReservedSeats() => _TotalReserveSeats;

        public int CountAvailableSeats() => _TotalSeats - _TotalReserveSeats;

        public void FindFirstAvailableSeat()
        {

            for (int i = 0; i < _Rows; i++)
            {

                for (int j = 0; j < _Columns; j++)
                {

                    if (_Seats[i,j] == 0)
                    {
                        int Seat = ((i* _Columns) + j);

                        Console.WriteLine($"Seat {Seat + 1} is Available");
                        return;
                    }

                }

            }

            Console.WriteLine("All Seats they are Reserved");
        }

        public int CountReservedInRow(int Row)
        {

            if (Row < 0 || Row >= _Rows) return -1;

            int count = 0;

            for (int i = 0; i < _Columns; i++)
            {
                if (_Seats[Row,i] == 1)
                {
                    count++;
                }

            }

            return count;
        }

        public bool IsRowFull(int Row)
        {

             if(Row < 0 || Row >= _Rows) return false;

            for (int i = 0; i < _Columns; i++)
            {

                if (_Seats[Row,i] == 0)
                    return false;
                
            }

            return true;
        }

        private bool Validation(int Rows, int Colums) => ((Rows >= 0 && Rows < _Rows) && (Colums >= 0 && Colums < _Columns));

        public void ReserveSeat(int Row , int col)
        {

            if(!Validation(Row , col))
            {
                Console.WriteLine("No sets with this position");
                return;
            }

            if(!IsSeatAvailable(Row, col))
            {

                Console.WriteLine("This Seat is Already Reserved");
                return;
            }
          

            _Seats[Row, col] = 1;
            _TotalReserveSeats++;
        }

        public void CancelReservation(int Row, int col)
        {
            if (!Validation(Row, col))
            {
                Console.WriteLine("No seats with this position");
                return;
            }


            if (IsSeatAvailable(Row, col))
            {

                Console.WriteLine("This Seat is Already Available");
                return;
            }

            _Seats[Row, col] = 0;
            _TotalReserveSeats--;
        }


        public bool IsSeatAvailable(int Row , int Col)
        {
            if (!Validation(Row, Col))
            {
                return false;
            }

            int Seat = ((Row * _Columns) + Col);

            if (_Seats[Row,Col] == 1)
            {

                
                return false;
            }

           
            return true;
        }


        public void DisplaySeats()
        {

            for (int i = 0; i < _Rows; i++)
            {

                for (int j = 0; j < _Columns; j++)
                {

                    if (_Seats[i, j] == 1)
                    {

                        Console.Write("[ R ]");
                    }

                    else
                    {
                        Console.Write("[ A ]");
                    }


                    if (j < _Columns - 1)
                    {
                        Console.Write(",");
                    }


                }

                Console.WriteLine();


            }

        }



    }
}
