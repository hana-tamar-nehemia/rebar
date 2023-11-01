namespace rebar.Models
{
    public class Menu
    {
        private List<Shake> _shakes = new List<Shake>();

        public Menu(List<Shake> shakes)
        {
            _shakes = shakes;
        }

        public List<Shake> Get()
        {
            return _shakes;
        }

    }

}

