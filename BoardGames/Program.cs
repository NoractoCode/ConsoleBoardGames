using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames
{
    internal class Program
    {
        static void Main()
        {
            TicTacToe game = new TicTacToe(3, 3);
            game.GameStart();
        }
    }
}