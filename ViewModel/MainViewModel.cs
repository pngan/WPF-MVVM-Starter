using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Model;
using System.Windows.Input;

namespace ViewModel
{
    public interface IMainViewModel
    {
        void Start();
    }

    public class MainViewModel : ObservableObject, IMainViewModel
    {
        private readonly IMainModel m_model;
        private readonly IMessageViewModel m_messageDialogViewModel;


        public MainViewModel(IMainModel model, IMessageViewModel messageDialogViewModel)
        {
            m_model = model;
            m_messageDialogViewModel = messageDialogViewModel;
            m_model.OnGreetingChanged += OnGreetingChanged;

            ShowMessageDialogCommand = new RelayCommand(m_messageDialogViewModel.ShowMessage);
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


        public ICommand ShowMessageDialogCommand { get; set; }

        public void Start()
        {
            m_model.Start();
        }
    }
}