using System.Text.RegularExpressions;

namespace BoardGames
{
    abstract class BaseGame : SaveManager
    {
        public Board Board { get; set; }
        public CurrentPlayer Token { get; set; }

        public virtual void GameStart()
        {
            CustomBoard();
            Game();//Runs the Game
        }

        public virtual void CustomBoard() //Create Custom Board by overriding this method
        {
            Board.InitializeBoard();//Creates Initial BoardState
        }
        public virtual void Game()// Basic HUD for Game
        {
            {
                char currentPlayer = Token.CurrentToken;
                Console.WriteLine($"Welcome to {SplitName(this.GetType().Name)}");
                Thread.Sleep(2000);
                do
                {
                    currentPlayer = Token.SwitchPlayers();
                    do
                    {
                        Console.Clear();
                        Board.BoardState();
                        Console.WriteLine($"it is player {currentPlayer}'s turn!");
                        Console.WriteLine("type \"save\" to save the game and \"Load\" to load one.");

                    }
                    while (CheckInput() == false);// Loops until valid move is made
                }
                while (CheckWin() == 0); //Loops until win condition is found

                Console.Clear();
                Board.BoardState();

                if (CheckWin() == 1)
                {
                    Console.WriteLine($"Congratulations {currentPlayer} on your victory!");
                    Console.WriteLine("\n");
                    Thread.Sleep(3000);
                }
                else if (CheckWin() == 2)
                {
                    Console.WriteLine($"DRAW!");
                    Console.WriteLine("\n");
                    Thread.Sleep(3000);
                }
            }
        }

        public virtual bool CheckInput()
        {
            string playerInput = Console.ReadLine();
            if (playerInput.ToLower() == "save")
            {
                Save(Board, $"{this.GetType().Name}BoardSave");
                Save(Token, $"{this.GetType().Name}TokenSave");

            }
            else if (playerInput.ToLower() == "load")
            {
                Board = Load<Board>($"{this.GetType().Name}BoardSave");
                Token = Load<CurrentPlayer>($"{this.GetType().Name}TokenSave");
            }
            else
            {
                return ValidMove(playerInput);
            }
            return false;
        }

        public abstract bool ValidMove(string playerInput);
        public abstract int CheckWin();

        private string SplitName(string input)//Turns Class Name into useable string
        {
            string name = null;
            string pattern = @"(?<!^)(?=[A-Z])";
            string[] result = Regex.Split(input, pattern);

            foreach (var word in result)
            {
                name = name + " " + word;
            }

            return name;
        }
    }
}