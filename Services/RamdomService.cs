namespace BackendHectorDeLeon.Services
{
    public class RamdomService : IRamdomService
    {
        private readonly int _value;

        public int Value
        { 
            get => _value;
        }

        public RamdomService() 
        {
            _value = new Random().Next(1000);
        }
    }
}
