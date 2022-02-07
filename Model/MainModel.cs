namespace Model
{
    public class MainModel : IMainModel
    {
        public void Start()
        {
            
        }


        public string Name { get; private set; } = string.Empty;

        public void SetName(string name)
        {
            Name = name;
            OnGreetingChanged?.Invoke(this, new GreetingArgs(name));
        }

        public event EventHandler<GreetingArgs> OnGreetingChanged;
    }
}