
using SeaBreeze.Domain.Constants;

namespace SeaBreeze.Service.Helpers
{
    public class PriceCalculator
    {
        public decimal CalculatePrice(bool IsEnsured, bool isRoseBar, bool isForToday)
        {
            decimal price = 0;

            if (isForToday)
            {
                price = Constants.TicketPrice;

                if (isRoseBar)
                {
                    price += Constants.RoseBarPrice;
                }

                if (IsEnsured)
                {
                    price += Constants.InsurancePrice;
                }
                return price;
            }
            else
            {
                price = Constants.TicketPrice * (decimal)0.9;


                if (isRoseBar)
                {
                    price += Constants.RoseBarPrice * (decimal)0.9;
                }

                if (IsEnsured)
                {
                    price += Constants.InsurancePrice;
                }
                return price;

            }


        }

        public decimal CalculatePremiumPrice(bool isPremiumInsured)
        {
            decimal premiumPrice = Constants.PremiumTicketPrice;
            if (isPremiumInsured)
            {
                premiumPrice += Constants.PremiumInsurancePrice;
            }
            return premiumPrice;
        }
    }
}
