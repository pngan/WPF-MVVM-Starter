using System.Windows;
using ViewModel;

namespace View
{
    public partial class MainWindow : Window
    {
        private readonly IMainViewModel m_viewModel;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(IMainViewModel viewModel) : this()
        {
            m_viewModel = viewModel;
            m_viewModel.Start();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            ((FrameworkElement)sender).DataContext = m_viewModel;
        }
    }
}
