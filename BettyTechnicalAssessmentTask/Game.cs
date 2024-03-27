namespace BettyTechnicalAssessmentTask
{
    public class Game
    {
        private decimal balance = 0;

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
                    decimal value = decimal.Parse(split[1]);

                    if (action == "bet")
                    {
                        if (value <= 0 || value > 10)
                        {
                            Console.WriteLine(ValidationMessages.BetsBetweenOneAndTen);
                            continue;
                        }
                        Bet(value);
                    }
                    else if (action == "deposit")
                    {
                        if (value > 0)
                        {
                            Deposit(value);
                            Console.WriteLine($"Your deposit of ${value} was successful. Your current balance is: ${balance}");
                        }
                        else
                        {
                            Console.WriteLine(ValidationMessages.PositiveDeposit);
                        }
                    }
                    else if (action == "withdraw")
                    {
                        Withdraw(value);
                    }
                    else
                    {
                        Console.WriteLine(ValidationMessages.UnexpectedAction,action);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(ValidationMessages.ExceptionMessage);
                }
            }
            Console.WriteLine("Thank you for playing! Hope to see you again soon.");
        }

        private void Bet(decimal amount)
        {
            if (balance == 0 || balance - amount < 0)
            {
                Console.WriteLine(ValidationMessages.NotEnoughBalance);
                return;
            }
            //place bet
            balance -= amount;

            //generate chance
            Random rnd = new Random();
            int randChance = rnd.Next(1, 101);
            //50% lose case
            if (randChance > 0 && randChance <= 50)
            {
                Console.WriteLine($"No luck this time! Your current balance is: ${balance}");
            }
            //2x win
            else if (randChance > 50 && randChance <= 90)
            {
                decimal wonAmount = amount * 2;
                balance += wonAmount;
                Console.WriteLine($"Congrats - you won ${wonAmount}! Your current balance is: ${balance}");
            }
            //10% for win over x2 and up to x10
            else if (randChance > 90 && randChance <= 100)
            {
                int x = GenerateMultiplier();
                decimal wonAmount = amount * x;
                balance += wonAmount;
                Console.WriteLine($"Congrats - you won ${wonAmount}! Your current balance is: ${balance}");
            }
        }

        private int GenerateMultiplier()
        {
            Random rnd = new Random();
            int multi = rnd.Next(2, 11);
            return multi;
        }

        private decimal Deposit(decimal amount) => balance += amount;

        private void Withdraw(decimal amount)
        {
            if (balance - amount < 0)
            {
                Console.WriteLine(ValidationMessages.NotEnoughBalance);
            }
            else
            {
                balance -= amount;
                Console.WriteLine($"Your withdrawal of ${amount} was successful. Your current balance is: {balance}");
            }
        }
    }
}
