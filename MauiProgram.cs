using MauiHangmanGames.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using MauiHangmanGames.Data;

namespace MauiHangmanGames
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Enregistre les services
            builder.Services.AddDbContext<HangmanDbContext>();
            builder.Services.AddTransient<LeaderboardService>();
            builder.Services.AddSingleton<GameService>();
            builder.Services.AddSingleton<GestionnaireDePartie>();

            // Crée l'application et assigne les services
            var app = builder.Build();
            App.Services = app.Services;

            return app;
        }
    }
}
