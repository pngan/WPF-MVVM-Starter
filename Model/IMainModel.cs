namespace Model
{
    public interface IMainModel
    {
        void Start();
        void SetName(string name);
        event EventHandler<GreetingArgs> OnGreetingChanged;

        string Name { get; }
    }
}