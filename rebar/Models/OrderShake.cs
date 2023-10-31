namespace rebar.Models
{
    public class OrderShake
    {
        private string _name;
        private string _size;
        private decimal _price;

        // Constructor
        public OrderShake(string name, string size, decimal price)
        {
            _name = name;
            _size = size;
            _price = price;
        }

        // Property for _name
        public string Name
        {
            get { return _name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _name = value;
            }
        }

        // Property for _size
        public string Size
        {
            get { return _size; }
            set
            {
                if (value == "L" || value == "M" || value == "S")
                    _size = value;
            }
        }

        // Property for _price
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value >= 0)
                    _price = value;
            }
        }
    }
}
