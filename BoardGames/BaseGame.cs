namespace BoardGames
{
    [Serializable]
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
                string gameName = this.GetType().Name;
                Console.WriteLine($"Welcome to {gameName}");
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
                if (CheckWin() == 1)
                {
                    Console.Clear();
                    Board.BoardState();
                    Console.WriteLine($"Congratulations {currentPlayer} on your victory!");
                    Console.WriteLine("\n");
                }
                else if (CheckWin() == 2)
                {
                    Console.Clear();
                    Board.BoardState();
                    Console.WriteLine($"DRAW!");
                    Console.WriteLine("\n");
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
                return ValidMove (playerInput);
            }
            return false;
        }

        public abstract bool ValidMove(string playerInput);
        public abstract int CheckWin();


    }
}