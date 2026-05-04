using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer_Queue_System
{
    public class PrintJob
    {
        private Queue<string> _PrintJobs;

        public PrintJob()
        {
            _PrintJobs = new Queue<string>();
        }

        public void AddPrintJob(string DocumentName)
        {
            if (string.IsNullOrWhiteSpace(DocumentName))
            {
                Console.WriteLine("Document name cannot be empty.");
                return;
            }
            _PrintJobs.Enqueue(DocumentName);
        }

        public void PrintNextJob()
        {

            if (_PrintJobs.IsEmpty()) { Console.Write("No print jobs available"); return; }

            string PrintJob = _PrintJobs.Dequeue();
            Console.WriteLine($"Printing : {PrintJob}");

            

        }

        public void PeekNextJob()
        {
            if (_PrintJobs.IsEmpty()) { Console.Write("No print jobs available"); return; }
            string NexJob = _PrintJobs.Peek();
            Console.WriteLine($"Next job : {NexJob}");
        }

        public void ShowAllJobs()
        {
            if(_PrintJobs.IsEmpty()) { Console.Write("No print jobs available"); return; }

            Console.Write("Waiting Jobs : ");
            _PrintJobs.Display();
            Console.WriteLine();

        }

        public bool HasJobs() => !_PrintJobs.IsEmpty();

    }
}
