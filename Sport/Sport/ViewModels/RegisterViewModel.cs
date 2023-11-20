using System;
using System.Windows.Input;
using Xamarin.Forms;
using Sport.Models;
using Sport.Services;
using System.Threading.Tasks;
using System.Diagnostics;
using Sport.Views;
using System.Text.RegularExpressions;

namespace Sport.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public string name;
        public string email;
        public string password;
        public string confirmPassword;


        public string Name
        {
            get { return this.name; }
            set { SetValue(ref this.name, value); }
        }

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

        public string ConfirmPassword
        {
            get { return this.confirmPassword; }
            set { SetValue(ref this.confirmPassword, value); }
        }

        #region Commands
        public ICommand RegisterCommand => new Command(RegisterMethod);
        #endregion

        private async void RegisterMethod()
        {
            if (string.IsNullOrEmpty(this.name) || (string.IsNullOrEmpty(this.email) || string.IsNullOrEmpty(this.password)))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes llenar todos los campos.",
                    "Accept");
                return;
            }


            // Validar el formato del correo electrónico
            if (!IsValidEmail(this.email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El correo electrónico no es válido.",
                    "Accept");
                return;
            }

            if (this.password != this.confirmPassword)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "La contraseña no coincide.",
                    "Accept");
                return;
            }
            bool isEmailRegistered = await App.Database.GetUserDatabase.IsEmailRegisteredAsync(this.email);


            if (isEmailRegistered)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El correo electrónico ya está registrado.",
                    "Accept");
                return;
            }

            var user = new User
            {
                Name = name,
                Email = email,
                Password = password,
                Creation_Date = DateTime.Now,
            };

            await App.Database.GetUserDatabase.SaveUserModelAsync(user);

            await Application.Current.MainPage.DisplayAlert("Successfully", "Registro exitoso", "Ok");

            Application.Current.MainPage = new AppShell();

        }


        private bool IsValidEmail(string email)
        {
            // Expresión regular para validar un correo electrónico
            string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            return Regex.IsMatch(email, emailPattern);
        }

    }
}
