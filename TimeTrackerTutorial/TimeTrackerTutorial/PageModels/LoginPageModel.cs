using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TimeTrackerTutorial.PageModels.Base;
using TimeTrackerTutorial.Service.Account;
using TimeTrackerTutorial.Services.Navigation;
using TimeTrackerTutorial.ViewModels.Buttons;
using Xamarin.Forms;

namespace TimeTrackerTutorial.PageModels
{
    public class LoginPageModel : PageModelBase
    {
        private ICommand _logInCommand;

        public ICommand LogInCommand
        {
            get => _logInCommand;
            set => SetProperty(ref _logInCommand, value);
        }

        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private readonly INavigationService _navigationService;
        private readonly IAccountService _accountService;

        public ButtonModel LogInModel { get; set; }


        public LoginPageModel(INavigationService navigationService, IAccountService accountService)
        {
            _navigationService = navigationService;
            _accountService = accountService;

            // init our Login command
//            LogInCommand = new Command(DoLogInAction);
            LogInModel = new ButtonModel("LOG IN 2", OnLogin);
        }

        private void OnLogin()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Perform login validation and navigation if applicable
        /// </summary>
        private async void DoLogInAction()
        {
            var loginAttempt = await _accountService.LoginAsync(Username, Password);
            if (loginAttempt)
            {
                // navigate to Dashboard
                await _navigationService.NavigateToAsync<DashboardPageModel>();
            }
            else
            {
                // TODO - display an alert for failure!
            }
        }
    }
}
