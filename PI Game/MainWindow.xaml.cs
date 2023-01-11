using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PI_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string PI = "3.141592653589793238462643383279502884197169399375105820974944592307816406286208998628034825342";
        int Count = 4;
        int Score = 0;
        bool ProgrammWrite = true;
        public MainWindow()
        {
            InitializeComponent();
            GameStart();
        }

        private void ButtonNum_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (!ProgrammWrite)
            {
                TextBoxMain.Text += button.Content.ToString();
            }
        }
        private void Button_Clicl_Minimize(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void Button_Click_Max(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            else
                Application.Current.MainWindow.WindowState = WindowState.Normal;
        }

        private void Button_Click_Stop(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        async void GameStart()
        {
            ProgrammWrite = true;
            TextBoxMain.Text = string.Empty;
            TextBoxMain.IsEnabled = false;
            Count++;
            if (Count == PI.Length)
            {
                Score = 0;
                TextBlockScore.Text = $"Score: {Score}";
                Count = 4;
            }
            for (int i = 0; i < Count; i++)
            {
                await Task.Delay(1000);
                TextBoxMain.Text += PI[i];
            }
            TextBoxMain.Text = string.Empty;
            TextBoxMain.IsEnabled = true;
            ProgrammWrite = false;
        }

        private void TextBoxMain_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ProgrammWrite)
                return;

            if (PI.Contains(TextBoxMain.Text))
            {
                if (TextBoxMain.Text.Length == Count - 1)
                {
                    GameStart();
                    Score++;
                    TextBlockScore.Text = $"Score: {Score}";
                }
            }
            else
            {
                Score = 0;
                TextBlockScore.Text = $"Score: {Score}";
                Count = 4;
                GameStart();
            }
        }
    }
}
