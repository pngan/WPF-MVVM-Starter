using System;
using System.Windows;
using ViewModel;

namespace View
{
    public partial class MainWindow : Window
    {
        private readonly IMainViewModel m_viewModel;
        private readonly MessageDialog m_messageDialog;
        private readonly IMessageViewModel m_messageViewModel;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(IMainViewModel viewModel, IMessageViewModel messageViewModel,  MessageDialog messageDialog) : this()
        {
            m_viewModel = viewModel;
            m_messageViewModel = messageViewModel;
            m_messageDialog = messageDialog;
            m_viewModel.Start();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            ((FrameworkElement)sender).DataContext = m_viewModel;

            m_messageViewModel.OnShowMessage += ShowMessage;
        }

        private void ShowMessage(object? sender, EventArgs e)
        {
            m_messageDialog.ShowDialog();
        }
    }
}
