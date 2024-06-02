using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace MauiHangmanGames
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
