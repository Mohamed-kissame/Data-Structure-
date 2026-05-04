using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer_Queue_System
{
    internal class Program
    {
        static void Main(string[] args)
        {

            PrintJob printJob = new PrintJob();

            printJob.AddPrintJob("cv.pdf");
            printJob.AddPrintJob("Report.docx");
            printJob.AddPrintJob("Invoice.pdf");

            printJob.PeekNextJob();
            printJob.PrintNextJob();
            printJob.ShowAllJobs();
            printJob.PrintNextJob();
            printJob.PrintNextJob();
            printJob.PrintNextJob();

            Console.ReadLine();



        }
    }
}
