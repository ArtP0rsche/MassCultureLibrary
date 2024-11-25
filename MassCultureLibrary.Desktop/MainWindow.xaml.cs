using MassCultureLibrary.Desktop.Pages;
using System.Windows;


namespace MassCultureLibrary.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance;
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            MainFrame.Navigate(new MainPage());
        }
    }
}