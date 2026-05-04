using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call_Center_Waiting_Buffer
{
    public class CallCenterWaitingBuffer
    {

        private CircularQueue<string> _Callers;

        public CallCenterWaitingBuffer()
        {
            _Callers = new CircularQueue<string>();
        }

        public void AddCaller(string callerName)
        {

            if (string.IsNullOrWhiteSpace(callerName))
            {

                Console.WriteLine("Should Enter an Valid Name");
                return;
            }

            _Callers.Enqueue(callerName);

        }

        public void ServeNextCaller()
        {
            if (_Callers.IsEmpty()) { Console.Write("No callers waiting"); return; }

            string caller = _Callers.Dequeue();

            Console.WriteLine($"Serving : {caller}");
        }

        public void PeekNextCaller()
        {

            if (_Callers.IsEmpty()) { Console.WriteLine("No next Caller "); return; }

            string next = _Callers.Peek();

            Console.WriteLine($"Next caller : {next}");

        }

        public void ShowWaitingCallers()
        {

            if (_Callers.IsEmpty()) { Console.Write("No callers waiting"); return; }

            Console.Write("Waiting callers : ");

            _Callers.Display();

            Console.WriteLine();

        }

        public bool HasCallers() => !_Callers.IsEmpty();
    }
}
