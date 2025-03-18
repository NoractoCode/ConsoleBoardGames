namespace BoardGames
{
    class ConnectFour : BaseGame
    {
        public ConnectFour(int X, int Y)
        {
            Token = new CurrentPlayer('X', 'O');
            //Create Computer Variable for AI
            string[] gridSize = new string[X * Y];//Calculates number of Board spaces
            Board = new Board(X, Y, gridSize, false);//Creates Board (True for numbers false for blank spaces)
        }
        public override bool ValidMove(string playerInput)
        {
            string playerOne = $" {Token.PlayerOne} ";
            string playerTwo = $" {Token.PlayerTwo} ";
            int[,] array = {
                        { 35, 28, 21, 14, 7, 0 },
                        { 36, 29, 22, 15, 8, 1 },
                        { 37, 30, 23, 16, 9, 2 },
                        { 38, 31, 24, 17, 10, 3 },
                        { 39, 32, 25, 18, 11, 4 },
                        { 40, 33, 26, 19, 12, 5 },
                        { 41, 34, 27, 20, 13, 6 }
                    };
            int columns = array.GetLength(1); // Get the number of columns
            int[] gridTest = new int[columns]; // Create a 1D array to store the row
            try
            {
                int choice = Convert.ToInt32(playerInput);
                if (choice > 0 && choice <= 7)
                {

                    int x = 0;
                    for (int i = 0; i < columns; i++)
                    {
                        gridTest[i] = array[choice - 1, i]; // choice-1 to adjust for 0-based indexing
                    }
                    for (x = 0; x < gridTest.Length; x++)
                    {
                        if (Board.Grid[gridTest[x]] != playerOne && Board.Grid[gridTest[x]] != playerTwo)
                        {
                            Board.Grid[gridTest[x]] = $" {Token.CurrentToken} ";
                            return true;
                        }
                    }
                    if (x == 6)
                    {
                        Console.WriteLine("That Column is Full!");
                        Thread.Sleep(1000);
                        return false;
                    }
                }
            }
            catch
            {
            }
            Console.WriteLine("InValid Move");
            Thread.Sleep(1000);
            return false;
        }
        public override int CheckWin()
        {
            string playerOne = $" {Token.PlayerOne} ";
            string playerTwo = $" {Token.PlayerTwo} ";
            int[,] columnArray = {
                        { 35, 28, 21, 14, 7, 0 },
                        { 36, 29, 22, 15, 8, 1 },
                        { 37, 30, 23, 16, 9, 2 },
                        { 38, 31, 24, 17, 10, 3 },
                        { 39, 32, 25, 18, 11, 4 },
                        { 40, 33, 26, 19, 12, 5 },
                        { 41, 34, 27, 20, 13, 6 }
                    };
            int[,] rowArray = {
                        { 35, 36, 37, 38, 39, 40, 41 },
                        { 28, 29, 30, 31, 32, 33, 34 },
                        { 21, 22, 23, 24, 25, 26, 27 },
                        { 14, 15, 16, 17, 18, 19, 20 },
                        { 7, 8, 9, 10, 11, 12, 13 },
                        { 0, 1, 2, 3, 4, 5, 6 },
                    };
            int columnLength = columnArray.GetLength(1);
            int rowLength = rowArray.GetLength(1);
            int[] rowTest = new int[rowLength];
            int[] columnTest = new int[columnLength];

            //test for Horizontal
            for(int x = 0; x< columnLength; x++)
            {
                for (int i = 0; i < rowLength; i++)
                {
                    rowTest[i] = rowArray[x, i];             
                }
                for(int y = 0; y <= rowLength -4; y++)
                {
                    foreach(var player in new[] {playerOne, playerTwo })
                    {
                        if (Board.Grid[rowTest[y]] == player && 
                            Board.Grid[rowTest[y + 1]] == player && 
                            Board.Grid[rowTest[y + 2]] == player && 
                            Board.Grid[rowTest[y + 3]] == player)
                        {
                            return 1;
                        }
                    }

                }
            }

            //test for Vertical
            for (int x = 0; x < rowLength; x++)
            {
                for (int i = 0; i < columnLength; i++)
                {
                    columnTest[i] = columnArray[x, i];
                }
                for (int y = 0; y <= columnLength-4; y++)
                {
                    foreach (var player in new[] { playerOne, playerTwo })
                    {
                        if (Board.Grid[columnTest[y]] == player && 
                            Board.Grid[columnTest[y + 1]] == player && 
                            Board.Grid[columnTest[y + 2]] == player && 
                            Board.Grid[columnTest[y + 3]] == player)
                        {
                            return 1;
                        }
                    }
                }
            }

            // **Check for Left-to-Right Diagonal Wins (↘)**
            for (int row = 0; row <= rowLength - 5; row++)  // Must have at least 4 rows below
            {
                for (int col = 0; col <= columnLength - 4; col++)  // Must have at least 4 columns right
                {
                    foreach (var player in new[] { playerOne, playerTwo })
                    {
                        
                        if (Board.Grid[rowArray[row, col]] == player &&
                            Board.Grid[rowArray[row + 1, col + 1]] == player &&
                            Board.Grid[rowArray[row + 2, col + 2]] == player &&
                            Board.Grid[rowArray[row + 3, col + 3]] == player)
                        {
                            return 1;
                        }
                    }
                }
            }

            // **Check for Right-to-Left Diagonal Wins (↙)**
            for (int row = 0; row <= rowLength - 5; row++)  // Must have at least 4 rows below
            {
                for (int col = columnLength; col >= 3 ; col--)  // Must have at least 4 columns left
                {
                    foreach (var player in new[] { playerOne, playerTwo })
                    {
                        // Ensure indices are within bounds
                        if (row + 3 <= rowLength && col - 3 >= 0)
                        {
                            if 
                                (Board.Grid[rowArray[row, col]] == player &&
                                Board.Grid[rowArray[row + 1, col - 1]] == player &&
                                Board.Grid[rowArray[row + 2, col - 2]] == player &&
                                Board.Grid[rowArray[row + 3, col - 3]] == player)
                            {
                                return 1;
                            }
                        }
                    }
                }
            }
                if (IsMovesLeft() == false)
            {
                return 2;
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
