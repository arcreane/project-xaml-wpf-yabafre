using MauiHangmanGames.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using MauiHangmanGames.Data;
using Microsoft.EntityFrameworkCore;

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
            builder.Services.AddDbContext<HangmanDbContext>(options =>
                    options.UseNpgsql("Host=ep-broad-lab-a251k1b8-pooler.eu-central-1.aws.neon.tech;Database=verceldb;Username=default;Password=Xpa4VKikJN5O"));
            builder.Services.AddTransient<LeaderboardService>();
            builder.Services.AddSingleton<GameService>();
            builder.Services.AddSingleton<GestionnaireDePartie>();

            // Crée l'application
            var app = builder.Build();
            
            return app;
        }
    }
}
