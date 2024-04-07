using BettyTechnicalAssessmentTask.Interfaces;

namespace BettyTechnicalAssessmentTask.Services
{
    public class GameService : IGameService
    {

        private decimal balance = 0;

        public decimal Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new Exception(ValidationMessages.PositiveDeposit);
            }
            balance += amount;
            Console.WriteLine($"Your deposit of ${amount} was successful. Your current balance is: ${this.balance}");
            return balance;
        }

        public void Withdraw(decimal amount)
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
        public void Bet(decimal amount)
        {
            if (amount <= 0 || amount > 10)
            {
                throw new Exception(ValidationMessages.BetsBetweenOneAndTen);
            }
            if (balance == 0 || balance - amount < 0)
            {
                throw new Exception(ValidationMessages.NotEnoughBalance);
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
    }
}
