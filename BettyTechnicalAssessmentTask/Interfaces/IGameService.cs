namespace BettyTechnicalAssessmentTask.Interfaces
{
    public interface IGameService
    {
        public decimal Deposit(decimal amount);
        public void Withdraw(decimal amount);
        public void Bet(decimal amount);
    }
}
