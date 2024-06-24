using Microsoft.Maui.Controls;

namespace MauiHangmanGames
{
    public partial class App : Application
    {
        public static IServiceProvider? Services { get; private set; }

        public App(IServiceProvider serviceProvider)
        {
            Services = serviceProvider;
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
