using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSeatReservation
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SeatReservation seat = new SeatReservation(3, 4);

            seat.ReserveSeat(0, 0);
            seat.ReserveSeat(0, 1);
            seat.ReserveSeat(0, 2);
            seat.ReserveSeat(0, 3);

            seat.ReserveSeat(1, 0);
            seat.ReserveSeat(1, 1);
            seat.ReserveSeat(1, 2);
            seat.ReserveSeat(1, 3);

            seat.ReserveSeat(2, 0);
            seat.ReserveSeat(2, 1);
            seat.ReserveSeat(2, 2);
            seat.ReserveSeat(2, 3);


            seat.CancelReservation(0, 1);
            seat.CancelReservation(0, 2);

            seat.DisplaySeats();

            seat.IsSeatAvailable(0, 2);


            Console.Write($"\nTotal Reserved seat {seat.CountReservedSeats()}");
            Console.Write($"\nTotal Available seat {seat.CountAvailableSeats()}");

          

            Console.ReadLine();







        }
    }
}
