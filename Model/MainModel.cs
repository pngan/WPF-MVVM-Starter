using System;

namespace Model
{
    public class MainModel : IMainModel
    {
        public void Start()
        {
            
        }

        public void SetName(string name)
        {
            OnGreetingChanged?.Invoke(this, new GreetingArgs(name));
        }

        public event EventHandler<GreetingArgs> OnGreetingChanged;
    }
}