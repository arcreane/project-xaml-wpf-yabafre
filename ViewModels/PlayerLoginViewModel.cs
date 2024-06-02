using System.Windows.Input;
using MauiHangmanGames.Models;
using MauiHangmanGames.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MauiHangmanGames.ViewModels
{
    public class PlayerLoginViewModel : BaseViewModel
    {
        private string? _playerName;
        private ModeDeJeu? _modeDeJeu;

        public string? PlayerName
        {
            get => _playerName;
            set => SetProperty(ref _playerName, value);
        }

        public ModeDeJeu? ModeDeJeu
        {
            get => _modeDeJeu;
            set => SetProperty(ref _modeDeJeu, value);
        }

        public ICommand LoginCommand { get; }

        public PlayerLoginViewModel()
        {
            LoginCommand = new Command(OnLogin);
        }

        private async void OnLogin()
        {
            if (string.IsNullOrEmpty(PlayerName))
                return;

            var gameService = App.Services.GetService<GameService>();
            var player = await gameService.AuthenticateOrCreatePlayerAsync(PlayerName);

            await Shell.Current.GoToAsync($"//MainPage", new Dictionary<string, object>
            {
                { "Player", player },
                { "ModeDeJeu", ModeDeJeu }
            });
        }
    }
}
