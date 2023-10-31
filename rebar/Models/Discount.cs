namespace rebar.Models
{
    public class Discount
    {
        private string _description;
        private int _discountPercent;

                public Discount(string description, int discountPercent)
        {
            _description = description;
            _discountPercent = discountPercent;
        }
        public string Description
        {
            get { return _description; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _description = value;
            }
        }

        public int DiscountPercent
        {
            get { return _discountPercent; }
            set
            {
                if (value >= 0 && value <= 100)
                    _discountPercent = value;
            }
        }


    }
}
