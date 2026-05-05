using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_BasedGameRotation
{
    public class TurnBasedGameRotation
    {

        private class PlayerNode
        {

            public string PlayerName { get; set; }

            public PlayerNode Next { get; set; }

            public PlayerNode(string PlayerName)
            {

                this.PlayerName = PlayerName;
                this.Next = null;
                
            }

        }


        private PlayerNode _currentplayer;

        private PlayerNode _Tail;

        private int _Count;

        public TurnBasedGameRotation()
        {
            _Count = 0;
        }

        public void AddPlayer(string PlayerName)
        {

            if (String.IsNullOrWhiteSpace(PlayerName)) { Console.WriteLine("Enter A Valid Name"); return; }

            PlayerNode NewNode = new PlayerNode(PlayerName);

            if(_currentplayer == null)
            {
                _currentplayer = NewNode;
                _Tail = NewNode;
                _Tail.Next = _currentplayer;
                _Count++;
                return;
            }

            _Tail.Next = NewNode;
            _Tail = NewNode;
            _Tail.Next = _currentplayer;
          
            _Count++;

        }

        public void NextTurn()
        {

            if(_currentplayer == null)
            {
                Console.WriteLine("No Players Avaible");
                return;
            }

            _currentplayer = _currentplayer.Next;

        }

        public void ShowCurrenPlayer()
        {

            if (_currentplayer == null)
            {
                Console.WriteLine("No Current Players ");
                return;
            }

            string Player = _currentplayer.PlayerName;

            Console.Write($"Current Player : {Player}\n");

        }

        public void ShowPlayers()
        {

            PlayerNode current = _currentplayer;
            int Count = 0;

            if( current == null ) { Console.Write("No Players to show"); return; }


            Console.Write("The currents Players are : ");


            while (Count < _Count)
            {

                Console.Write(current.PlayerName);


                if(Count < _Count - 1)
                {

                    Console.Write(" - > ");
                }




                current = current.Next;
                Count++;
            }



        }

        public void RemovePlayer(string PlayerName)
        {

            if (_currentplayer == null)
            {
                _Tail = null;
                return;
            }


            PlayerNode Previous = _Tail;
            PlayerNode current = _currentplayer;
            int count = 0;

            while (count < _Count)
            {

                if (String.Equals(current.PlayerName, PlayerName, StringComparison.OrdinalIgnoreCase))
                {

                    if (_Count == 1)
                    {
                        _currentplayer = null;
                        _Tail = null;
                    }
                    else if (current == _currentplayer)
                    {
                        _currentplayer = _currentplayer.Next;
                        _Tail.Next = _currentplayer;

                    }
                    else if (current == _Tail)
                    {
                        _Tail = Previous;
                        _Tail.Next = _currentplayer;

                    }
                    else
                    {

                        Previous.Next = current.Next;
                    }

                    _Count--;
                    return;


                }

                Previous = current;
                current = current.Next;
                count++;

            }

            throw new ArgumentException("The value not found");

        }

        public bool HasPlayers() => _Count > 0;
    }
}
