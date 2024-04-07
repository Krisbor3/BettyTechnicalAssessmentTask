using BettyTechnicalAssessmentTask.Interfaces;

namespace BettyTechnicalAssessmentTask
{
    public class Game
    {
        private readonly IGameService gameService;
        public Game(IGameService gameService)
        {
            this.gameService = gameService;
        }
        public void Play()
        {
            string input = "";

            while (true)
            {
                try
                {
                    Console.WriteLine("Please, submit action:");
                    input = Console.ReadLine().ToLower();
                    if (input == "exit")
                    {
                        break;
                    }
                    string[] split = input.Split(' ');
                    string action = split[0];
                    if (split.Length == 1)
                    {
                        throw new Exception(string.Format(ValidationMessages.UnexpectedAction,action));
                    }
                    decimal value = 0;
                    bool isValueValid = decimal.TryParse(split[1], out value);
                    if (!isValueValid)
                    {
                        throw new Exception(ValidationMessages.ExceptionMessage);
                    }

                    if (action == "bet")
                    {
                        this.gameService.Bet(value);
                    }
                    else if (action == "deposit")
                    {
                        this.gameService.Deposit(value);
                    }
                    else if (action == "withdraw")
                    {
                        this.gameService.Withdraw(value);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Thank you for playing! Hope to see you again soon.");
        }
    }
}
