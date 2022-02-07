using Model;

namespace ViewModel
{
    public interface IMainViewModel
    {
        void Start();
    }

    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private readonly IMainModel m_model;

        public MainViewModel(IMainModel model)
        {
            m_model = model;
            m_model.OnGreetingChanged += OnGreetingChanged;
        }

        private void OnGreetingChanged(object sender, GreetingArgs e)
        {
            Greeting = e.Greeting;
        }

        private string m_name;
        private string m_greeting;

        public string Name
        {
            get { return m_name; }
            set
            {
                m_name = value;
                m_model.SetName(value);
            }
        }

        public string Greeting
        {
            get { return m_greeting; }
            set
            {
                m_greeting = value;
                OnPropertyChanged("Greeting");
            }
        }
        
        public void Start()
        {
            m_model.Start();
        }
    }
}