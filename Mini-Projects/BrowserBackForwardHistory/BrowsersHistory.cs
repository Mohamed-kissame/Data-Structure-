using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserBackForwardHistory
{
    public class BrowsersHistory
    {

        private class PageNode
        {

            public string Url { get; set; }
            public PageNode Next { get; set; }

            public PageNode Previous { get; set; }

            public PageNode(string Url)
            {

                this.Url = Url;
                Next = null;
                Previous = null;
                
            }

        }

        private PageNode _current;

        public BrowsersHistory()
        {
           
        }

        public void VisitPage(string Url)
        {

            if (String.IsNullOrWhiteSpace(Url))
            {
                Console.WriteLine("Enter a valide Url");
                return;

            }

            PageNode NewNode = new PageNode(Url);

            if(_current == null)
            {
                _current = NewNode;
            }
            else
            {
                _current.Next = NewNode;
                NewNode.Previous = _current;
                _current = NewNode;
            }

        }

        public void GoBack()
        {

            if(_current == null)
            {
                Console.WriteLine("No Page visited");
                return;
            }
            else if(_current.Previous == null)
            {
                Console.WriteLine("You are already at First Page ");
                return;
            }
            else
            {
                _current = _current.Previous;
            }

        }

        public void GoForward()
        {

            if (_current == null)
            {
                Console.WriteLine("No Next Page");
                return;
            }
            else if (_current.Next == null)
            {
                Console.WriteLine("You are already at The Last Page ");
                return;
            }
            
            
                _current = _current.Next;
            

        }

        public void ShowCurrentPage()
        {

            if(_current == null)
            {

                Console.WriteLine("No Page visited yet");
                return;

            }

            Console.Write($"Current Page : {_current.Url}\n");

        }

        public void ShowHistory()
        {


            if (_current == null)
            {
                Console.WriteLine("No history");
                return;
            }

            PageNode First = _current;

            while (First.Previous != null)
            {

                First = First.Previous;

            }


            while (First != null)
            {

                if (First == _current)
                {

                    Console.Write($" [ {First.Url} ] ");

                }
                else
                {
                    Console.Write(First.Url);
                }

                if (First.Next != null) { Console.Write(" - > "); }

                First = First.Next;

            }


        }




    }
}
