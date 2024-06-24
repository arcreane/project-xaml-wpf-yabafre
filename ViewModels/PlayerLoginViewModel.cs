using System.Windows.Input;
using MauiHangmanGames.Models;
using MauiHangmanGames.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MauiHangmanGames.ViewModels
{
    public class PlayerLoginViewModel : BaseViewModel
    {
        private string? _playerName;
        private GameMode? _GameMode;

        public string? PlayerName
        {
            get => _playerName;
            set => SetProperty(ref _playerName, value);
        }

        public GameMode? GameMode
        {
            get => _GameMode;
            set => SetProperty(ref _GameMode, value);
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

            await Shell.Current.GoToAsync($"//GamePage", new Dictionary<string, object>
            {
                { "Player", player },
                { "GameMode", GameMode }
            });
        }
    }
}
