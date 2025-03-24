namespace BoardGames
{
    public class CurrentPlayer
    {
        public char PlayerOne { get; set; }
        public char PlayerTwo { get; set; }
        public char CurrentToken { get; set; }

        public CurrentPlayer()
        {

        }
        public CurrentPlayer(char playerOne, char playerTwo)
        {
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
        }

        public char SwitchPlayers()
        {
            if (CurrentToken == PlayerOne)
            {
                Console.WriteLine("1");
                CurrentToken = PlayerTwo;
                return PlayerTwo;
            }
            else
            {
                Console.WriteLine("2");
                CurrentToken = PlayerOne;
                return PlayerOne;
            }
        }
    }

}

