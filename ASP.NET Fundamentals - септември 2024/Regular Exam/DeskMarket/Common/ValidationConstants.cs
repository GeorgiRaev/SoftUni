namespace DeskMarket.Common
{
    public class ValidationConstants
    {
        public const int DeskMarketTitleMinLength = 2;
        public const int DeskMarketTitleMaxLength = 60;
        public const int DeskMarketDescriptionMinLength = 10;
        public const int DeskMarketDescriptionMaxLength = 250;
        public const decimal DeskMarketProductMinPrice = 1.00m;
        public const decimal DeskMarketProductMaxPrice = 3000.00m;
        public const string DateFormat = "yyyy-MM-dd HH:mm";
        public const int CategoryNameMinLength = 3;
        public const int CategoryNameMaxLength = 20;
    }
}
