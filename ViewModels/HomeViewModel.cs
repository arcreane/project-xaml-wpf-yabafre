using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiHangmanGames.Models;
using MauiHangmanGames.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MauiHangmanGames.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly GameService _gameService;
        public ObservableCollection<LeaderboardEntry> LeaderboardEntries { get; set; }
        public ICommand SelectModeCommand { get; }

        public HomeViewModel()
        {
            _gameService = App.Services.GetService<GameService>();
            LeaderboardEntries = new ObservableCollection<LeaderboardEntry>((IEnumerable<LeaderboardEntry>)_gameService.GetLeaderboardAsync());
            SelectModeCommand = new Command<string>(OnSelectMode);
        }

        private async void OnSelectMode(string modeDeJeu)
        {
            ModeDeJeu mode;
            switch (modeDeJeu)
            {
                case "Classique":
                    mode = new ModeDeJeuClassique();
                    break;
                case "Duel":
                    mode = new ModeDeJeuDuel();
                    break;
                case "Survie":
                    mode = new ModeDeJeuSurvie();
                    break;
                default:
                    return;
            }

            await Shell.Current.GoToAsync($"//PlayerLoginPage", new Dictionary<string, object>
            {
                { "ModeDeJeu", mode }
            });
        }
    }
}
