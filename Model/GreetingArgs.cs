namespace Model
{
    public class GreetingArgs : EventArgs
    {
        private readonly string m_name;

        public GreetingArgs(string name)
        {
            m_name = name;
        }

        public string Greeting => $"Hi there, {m_name}!";
    }
}