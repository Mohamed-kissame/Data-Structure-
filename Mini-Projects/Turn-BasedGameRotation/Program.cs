using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_BasedGameRotation
{
    public class Program
    {
        static void Main(string[] args)
        {

            TurnBasedGameRotation gameRotation = new TurnBasedGameRotation();

            gameRotation.AddPlayer("Player 1");
            gameRotation.AddPlayer("Player 2");
            gameRotation.AddPlayer("Player 3");


            gameRotation.NextTurn();
            gameRotation.ShowCurrenPlayer();
            gameRotation.NextTurn();
            gameRotation.ShowCurrenPlayer();
            gameRotation.NextTurn();
            gameRotation.ShowCurrenPlayer();

            gameRotation.RemovePlayer("Player 3");

            gameRotation.ShowPlayers();

        }
    }
}
