using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames
{
    internal class TicTacToe:BaseGame
    {
        public TicTacToe(int X, int Y)
        {
            Token = new CurrentPlayer('X', 'O');
            //Create Computer Variable for AI
            string[] gridSize = new string[X * Y];//Calculates number of Board spaces
            Board = new Board(X, Y, gridSize, true);//Creates Board (True for numbers false for blank spaces)
            //Create GameHistory Class for save/Load
        }
        public override bool ValidMove()
        {
            string playerOne = $" {Token.PlayerOne} ";
            string playerTwo = $" {Token.PlayerTwo} ";
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice > 0 && choice <= Board.Grid.Length)
                {
                    if (Board.Grid[choice - 1] == playerOne || Board.Grid[choice - 1] == playerTwo)
                    {
                        Console.WriteLine("Invalid Input");
                        Thread.Sleep(1000);
                        return false;
                    }
                    else
                    {
                        Board.Grid[choice - 1] = $" {Token.CurrentToken} ";
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    Thread.Sleep(1000);
                    return false;
                }
            }
            catch
            {
                Console.WriteLine("Invalid Input");
                Thread.Sleep(1000);
                return false;
            }

        }
        public override int CheckWin() // set for Tic Tac Toe
        {
            string playerOne = $" {Token.PlayerOne} ";
            string playerTwo = $" {Token.PlayerTwo} ";
            // Check Horizontal Win
            if (Board.Grid[0] == Board.Grid[1] && Board.Grid[1] == Board.Grid[2])
            {
                if (Board.Grid[0] == playerOne || Board.Grid[0] == playerTwo)
                {
                    return 1;
                }
                return 0;
            }
            else if (Board.Grid[3] == Board.Grid[4] && Board.Grid[4] == Board.Grid[5])
            {
                if (Board.Grid[3] == playerOne || Board.Grid[3] == playerTwo)
                {
                    return 1;
                }
                return 0;
            }
            else if (Board.Grid[6] == Board.Grid[7] && Board.Grid[7] == Board.Grid[8])
            {
                if (Board.Grid[6] == playerOne || Board.Grid[0] == playerTwo)
                {
                    return 1;
                }
                return 0;
            }
            //Check Vertical Win
            else if (Board.Grid[0] == Board.Grid[3] && Board.Grid[3] == Board.Grid[6])
            {
                if (Board.Grid[0] == playerOne || Board.Grid[0] == playerTwo)
                {
                    return 1;
                }
                return 0;
            }
            else if (Board.Grid[1] == Board.Grid[4] && Board.Grid[4] == Board.Grid[7])
            {
                if (Board.Grid[1] == playerOne || Board.Grid[1] == playerTwo)
                {
                    return 1;
                }
                return 0;
            }
            else if (Board.Grid[2] == Board.Grid[5] && Board.Grid[5] == Board.Grid[8])
            {
                if (Board.Grid[2] == playerOne || Board.Grid[2] == playerTwo)
                {
                    return 1;
                }
                return 0;
            }
            //check Diagonal Win
            else if (Board.Grid[0] == Board.Grid[4] && Board.Grid[4] == Board.Grid[8])
            {
                if (Board.Grid[0] == playerOne || Board.Grid[0] == playerTwo)
                {
                    return 1;
                }
                return 0;
            }
            else if (Board.Grid[2] == Board.Grid[4] && Board.Grid[4] == Board.Grid[6])
            {
                if (Board.Grid[2] == playerOne || Board.Grid[2] == playerTwo)
                {
                    return 1;
                }
                return 0;
            }
            else if (IsMovesLeft() == false) // Draw if all squares are full
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
        private bool IsMovesLeft()
        {
            int x = 0;
            for (int z = 0; z < Board.Grid.Length; z++)
            {
                if (Board.Grid[z] == $" {Token.PlayerOne} " || Board.Grid[z] == $" {Token.PlayerTwo} ")
                {
                    x++;
                }
            }
            if (x == 9)
            {
                return false;
            }
            return true;
        } //Checks board for avaliable moves
    }
}
