using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserBackForwardHistory
{
    internal class Program
    {
        static void Main(string[] args)
        {


            BrowsersHistory browsers = new BrowsersHistory();

            browsers.VisitPage("google.com");
            browsers.VisitPage("github.com");
            browsers.VisitPage("Openai.com");

            browsers.GoBack();

            browsers.ShowHistory();


         

           




        }
    }
}
