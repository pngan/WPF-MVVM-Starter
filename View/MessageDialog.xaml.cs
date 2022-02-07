using System;
using System.Windows;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for MessageDialog.xaml
    /// </summary>
    public partial class MessageDialog : Window
    {
        public MessageDialog() => InitializeComponent();

        private readonly IMessageViewModel m_viewModel;

        public MessageDialog(IMessageViewModel viewModel) : this()
        {
            m_viewModel = viewModel;
            viewModel.OnHideMessage += HideMessage;
        }

        private void HideMessage(object? sender, EventArgs e)
        {
            Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ((FrameworkElement)sender).DataContext = m_viewModel;
        }
    }
}
