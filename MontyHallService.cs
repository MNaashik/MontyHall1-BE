namespace MontyHall1
{
    public class MontyHallService
    {
        private Random _random = new Random();
        //private readonly ILogger<MontyHallService> _logger;

        //public MontyHallService(ILogger<MontyHallService> logger)
        //{
        //    _logger = logger;
        //}

        public bool Simulate(bool switchDoor, int chosenDoor, out int montyDoor)
        {
            int carPosition = _random.Next(3);
            int playerChoice = chosenDoor - 1;

            do
            {
                montyDoor = _random.Next(3);
            } while (montyDoor == playerChoice || montyDoor == carPosition);

            int finalChoice = switchDoor ? 3 - playerChoice - montyDoor : playerChoice;

            return finalChoice == carPosition;
        }

        public SimulationResult
            //(int SwitchWins, int StayWins, double SwitchWinPercentage, double StayWinPercentage) 
            SimulateGames(int numberOfGames, bool switchDoor, int chosenDoor)
        {
            int switchWins = 0;
            int stayWins = 0;

            for (int i = 0; i < numberOfGames; i++)
            {
                int montyDoor;
                bool win = Simulate(switchDoor, chosenDoor, out montyDoor);
                if (win)
                {
                    if (switchDoor)
                        switchWins++;
                    else
                        stayWins++;
                }
            }

            double switchWinPercentage = numberOfGames > 0 ? (switchWins / (double)numberOfGames) * 100 : 0;
            double stayWinPercentage = numberOfGames > 0 ? (stayWins / (double)numberOfGames) * 100 : 0;

            //// Log results for debugging
            //_logger.LogInformation($"Switch Wins: {switchWins}, Stay Wins: {stayWins}");
            //_logger.LogInformation($"Switch Win Percentage: {switchWinPercentage}, Stay Win Percentage: {stayWinPercentage}");

            //return (switchWins, stayWins, switchWinPercentage, stayWinPercentage);

            return new SimulationResult
            {
                SwitchWins = switchWins,
                StayWins = stayWins,
                SwitchWinPercentage = switchWinPercentage,
                StayWinPercentage = stayWinPercentage
            };
        }
    }
}
