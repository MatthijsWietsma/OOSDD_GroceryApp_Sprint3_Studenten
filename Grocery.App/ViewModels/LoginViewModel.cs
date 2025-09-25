
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Helpers;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.App.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;
        private readonly IClientService _clientService;
        private readonly GlobalViewModel _global;

        private const string defaultEmail = "user3@mail.com";
        private const string defaultPassword = "user3";

        [ObservableProperty]
        private bool loginVisible = true;

        [ObservableProperty]
        private bool createVisible = false;

        [ObservableProperty]
        private string email = defaultEmail;

        [ObservableProperty]
        private string password = defaultPassword;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string createMessage;

        [ObservableProperty]
        private string loginMessage;

        public LoginViewModel(IAuthService authService, IClientService clientService, GlobalViewModel global)
        { //_authService = App.Services.GetServices<IAuthService>().FirstOrDefault();
            _authService = authService;
            _clientService = clientService;
            _global = global;
        }

        [RelayCommand]
        private void Create()
        {
            Email = "";
            Password = "";

            LoginVisible = false;
            CreateVisible = true;
        }

        [RelayCommand]
        private void LoginAfterCreate()
        {
            List<Client> clients = _clientService.GetAll();

            if (clients.Any(c => c.EmailAddress == Email))
            {
                CreateMessage = "E-mailadres al in gebruik";
                return;
            }

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
{
                CreateMessage = "Vul alle verplichte velden in";
                return;
            }

            Client newClient = _clientService.Create(Name, Email, PasswordHelper.HashPassword(Password));

            createMessage = $"Welkom {newClient.Name}!";
            _global.Client = newClient;
            Application.Current.MainPage = new AppShell();
        }


        [RelayCommand]
        private void Back()
        {
            Email = defaultEmail;
            Password = defaultPassword;

            LoginVisible = true;
            CreateVisible = false;
        }

        [RelayCommand]
        private void Login()
        {
            Client? authenticatedClient = _authService.Login(Email, Password);
            if (authenticatedClient != null)
            {
                LoginMessage = $"Welkom {authenticatedClient.Name}!";
                _global.Client = authenticatedClient;
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                LoginMessage = "Ongeldige inloggegevens.";
            }
        }
    }
}