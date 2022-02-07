using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Model;
using System.Windows.Input;

namespace ViewModel
{
    public interface IMessageViewModel
    {
        void ShowMessage();
        void HideMessage();

        event EventHandler OnShowMessage;
        event EventHandler OnHideMessage;
    }

    public class MessageViewModel : ObservableObject, IMessageViewModel
    {
        private string m_greeting;
        public MessageViewModel(IMainModel model)
        {
            _mainModel = model;

            HideMessageDialogCommand = new RelayCommand(HideMessage);

            _mainModel.OnGreetingChanged += OnGreetingChanged;
        }

        private void OnGreetingChanged(object? sender, GreetingArgs e)
        {
            Greeting = e.Greeting;
        }

        private IMainModel _mainModel;

        public string Greeting
        {
            get { return m_greeting; }
            set
            {
                m_greeting = value;
                OnPropertyChanged("Greeting");
            }
        }

        public void ShowMessage() 
        {
            OnShowMessage?.Invoke(this, new EventArgs());
        }


        public ICommand HideMessageDialogCommand { get; set; }

        public void HideMessage()
        {
            OnHideMessage?.Invoke(this, new EventArgs());
        }

        public event EventHandler OnShowMessage;
        public event EventHandler OnHideMessage;
    }
}
