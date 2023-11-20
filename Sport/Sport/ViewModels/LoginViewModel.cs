using System;
using System.Windows.Input;
using Xamarin.Forms;
using Sport.Models;
using Sport.Services;
using System.Threading.Tasks;
using System.Diagnostics;
using Sport.Views;
using System.Collections.Generic;

namespace Sport.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Attribute
        public string email;
        public string password;
        #endregion

        #region Properties
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }


        #endregion

        #region Commands
        public ICommand LoginCommand => new Command(LoginMethod);
        #endregion

        #region Methods
        public async void LoginMethod()
        {
            if (string.IsNullOrEmpty(this.email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingresa tu correo electrónico.",
                    "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingresa tu contraseña.",
                    "Accept");
                return;
            }

 

            List<User> users = App.Database.GetUserDatabase.GetUsersValidate(email, password).Result;

            if (users.Count == 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                  "Error",
                  "El correo o contraseña son incorrectos.",
                  "Accept");
            }
            else if (users.Count > 0)
            {
                Application.Current.MainPage = new AppShell();
            }
        }

        
        #endregion

        #region Constructor
        public LoginViewModel()
        {

        }
        #endregion
    }

}
