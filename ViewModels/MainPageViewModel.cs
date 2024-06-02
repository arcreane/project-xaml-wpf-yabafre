using MauiHangmanGames.Services;

namespace MauiHangmanGames.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly GameService _gameService;
        private readonly GestionnaireDePartie _gestionnaireDePartie;
        private string _currentLetter = string.Empty;

        public string CurrentLetter
        {
            get => _currentLetter;
            set => SetProperty(ref _currentLetter, value);
        }

         public void Initialize()
        {
            // Logique d'initialisation ici
        }

        public MainPageViewModel()
        {
            _gameService = App.Services.GetService<GameService>()!;
            _gestionnaireDePartie = App.Services.GetService<GestionnaireDePartie>()!;
        }
    }
}
