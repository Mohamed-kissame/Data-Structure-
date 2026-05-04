using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditorHistory
{
    public class UndoRedo
    {

        private Stack<string> _UndoStack;
        private Stack<string> _RedoStack;

        private string _CurrentText;

        public UndoRedo()
        {
            _UndoStack = new Stack<string>();
            _RedoStack = new Stack<string>();
            _CurrentText = "";
        }

        public void TypeText(string text)
        {
            _UndoStack.Push(_CurrentText);
            _CurrentText += text;
            _RedoStack.Clear();
        }

        public void Undo()
        {

            if(_UndoStack.IsEmpty()) return;

            _RedoStack.Push(_CurrentText);

            string PrevsText = _UndoStack.Pop();

            _CurrentText = PrevsText;



        }

        public void Redo()
        {
            if(_RedoStack.IsEmpty()) return;

            _UndoStack.Push(_CurrentText);

            string NextText = _RedoStack.Pop();

            _CurrentText = NextText;

        }

        public void ShowText()
        {
            Console.Write(_CurrentText);
        }
    }
}
