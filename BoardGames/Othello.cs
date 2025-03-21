namespace BoardGames
{
    class Othello : BaseGame
    {
        public Othello(int X, int Y)
        {
            Token = new CurrentPlayer('X', 'O');
            //Create Computer Variable for AI
            string[] gridSize = new string[X * Y];//Calculates number of Board spaces
            Board = new Board(X, Y, gridSize, false);//Creates Board (True for numbers false for blank spaces)
        }


        public override void CustomBoard()
        {
            Board.InitializeBoard();
            Board.Grid[27] = $" {Token.PlayerOne} ";
            Board.Grid[28] = $" {Token.PlayerTwo} ";
            Board.Grid[35] = $" {Token.PlayerTwo} ";
            Board.Grid[36] = $" {Token.PlayerOne} ";
        }
        public override bool CheckInput()
        {
            Console.WriteLine("If there are no moves, type \"Pass\"");
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
        public override bool ValidMove(string playerInput)
        {
            if (playerInput.ToLower() == "pass")
            {
                return true;
            }
            int index = ConvertMoveToIndex(playerInput);
            if (index == -1)
            {
                Console.WriteLine("Invalid Move");
                Thread.Sleep(2000);
                return false;
            }

            if (IsValidMove(index, Token.CurrentToken))
            {
                Board.Grid[index] = $" {Token.CurrentToken} ";
                FlipTokens(index, Token.CurrentToken);
                return true;
            }
            Console.WriteLine("Invalid Move");
            Thread.Sleep(2000);
            return false;
        }
        private int ConvertMoveToIndex(string playerInput)
        {
            if (playerInput.Length != 2) return -1; // Ensure input is exactly 2 characters

            char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            char columnChar = playerInput[0];
            char rowChar = playerInput[1];

            if (!IsAllLetters(columnChar.ToString()) || !IsAllDigits(rowChar.ToString())) return -1;

            int column = Array.IndexOf(letters, columnChar); // Convert 'a' to 'h' into column index 0-7
            int row = Convert.ToInt32(Char.GetNumericValue(rowChar)) - 1; // Convert '1'-'8' into row index 0-7

            if (column < 0 || row < 0 || column > 7 || row > 7) return -1; // Bounds check

            return column * 8 + row; // Convert (row, column) to 1D array index
        }

        private bool IsValidMove(int index, char currentToken)
        {
            if (Board.Grid[index] != "   ") return false; // Can't place on an occupied tile

            int[] directions = { -9, -8, -7, -1, 1, 7, 8, 9 };
            char opponentToken = (currentToken == Token.PlayerOne) ? Token.PlayerTwo : Token.PlayerOne;

            foreach (int dir in directions)
            {
                int pos = index + dir;
                bool hasOpponent = false;

                while (pos >= 0 && pos < Board.Grid.Length && Board.Grid[pos] == $" {opponentToken} ")
                {
                    hasOpponent = true;
                    pos += dir;
                }

                if (hasOpponent && pos >= 0 && pos < Board.Grid.Length && Board.Grid[pos] == $" {currentToken} ")
                {
                    return true; // A valid move must sandwich opponent tokens
                }
            }
            return false;
        }

        private void FlipTokens(int index, char currentToken)
        {
            int[] directions = { -9, -8, -7, -1, 1, 7, 8, 9 }; // Directions in a 1D array representation of an 8x8 board
            char opponentToken = (currentToken == Token.PlayerOne) ? Token.PlayerTwo : Token.PlayerOne;

            foreach (int dir in directions)
            {
                int pos = index + dir;
                List<int> toFlip = new List<int>();

                while (pos >= 0 && pos < Board.Grid.Length && Board.Grid[pos] == $" {opponentToken} ")
                {
                    toFlip.Add(pos);
                    pos += dir;
                }

                if (pos >= 0 && pos < Board.Grid.Length && Board.Grid[pos] == $" {currentToken} " && toFlip.Count > 0)
                {
                    foreach (int flipIndex in toFlip)
                    {
                        Board.Grid[flipIndex] = $" {currentToken} ";
                    }
                }
            }
        }

        private static bool IsAllLetters(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }
        private static bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public override int CheckWin()
        {
            int playerOneCount = 0;
            int playerTwoCount = 0;

            if (IsMovesLeft() == false)
            {
                for (int i = 0; i < Board.Grid.Length; i++)
                {
                    if (Board.Grid[i] == $" {Token.PlayerOne} ")
                    {
                        playerOneCount++;
                    }
                    if (Board.Grid[i] == $" {Token.PlayerTwo} ")
                    {
                        playerTwoCount++;
                    }
                }

                if (playerOneCount > playerTwoCount)
                {
                    Token.CurrentToken = Token.PlayerOne;
                    return 1;
                }
                else if (playerTwoCount > playerOneCount)
                {
                    Token.CurrentToken = Token.PlayerTwo;
                    return 1;
                }
                else if (playerOneCount == playerTwoCount)
                {
                    return 2;
                }
            }
            return 0;
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
            if (x == Board.Grid.Length)
            {
                return false;
            }
            return true;
        } //Checks board for avaliable moves
    }
}
