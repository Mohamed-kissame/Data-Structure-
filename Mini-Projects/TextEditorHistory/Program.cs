using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditorHistory
{
    public class Program
    {
        static void Main(string[] args)
        {


             UndoRedo undoRedo = new UndoRedo();

            undoRedo.TypeText("A");
            undoRedo.TypeText("B");
            undoRedo.TypeText("C");
            undoRedo.ShowText();

            Console.WriteLine();

            undoRedo.Undo();
            undoRedo.Undo();
          
          
            undoRedo.ShowText();

            Console.WriteLine();


            undoRedo.Redo();
         
           
          
          
          
            undoRedo.ShowText();


          

        }
    }
}
