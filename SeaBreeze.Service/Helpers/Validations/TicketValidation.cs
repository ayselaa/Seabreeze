using SeaBreeze.Service.Exceptions;

namespace SeaBreeze.Service.Helpers.TicketValidation
{
    public class TicketValidation
    {

        public void DateValidation(DateTime date)
        {
            if (DateTime.Today.CompareTo(date) > 0)
                throw new InvalidDateTimeException("Gonderilen tarix duzgun deyil.");

        }
    }
}
