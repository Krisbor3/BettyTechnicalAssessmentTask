namespace BettyTechnicalAssessmentTask
{
    public class ValidationMessages
    {
        public const string BetsBetweenOneAndTen = "You can only place bets between $1 and $10";
        public const string PositiveDeposit = "The deposit amount must be positive or higher than $0";
        public const string NotEnoughBalance = "Sorry, You don't have enough balance!";
        public const string ExceptionMessage = "Please use bet, withdraw or deposit.";
        public const string UnexpectedAction = "Action {0} is not recognised";
    }
}
