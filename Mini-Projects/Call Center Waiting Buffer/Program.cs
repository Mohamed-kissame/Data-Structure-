using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call_Center_Waiting_Buffer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            CallCenterWaitingBuffer callCenterWaitingBuffer = new CallCenterWaitingBuffer();

            callCenterWaitingBuffer.AddCaller("Mohamed");
            callCenterWaitingBuffer.AddCaller("Youssef");
            callCenterWaitingBuffer.AddCaller("Amin");

            callCenterWaitingBuffer.PeekNextCaller();
            callCenterWaitingBuffer.ServeNextCaller();
            callCenterWaitingBuffer.ServeNextCaller();
            callCenterWaitingBuffer.AddCaller("Adam");
            callCenterWaitingBuffer.ShowWaitingCallers();


        }
    }
}
