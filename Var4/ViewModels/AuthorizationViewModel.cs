using Microsoft.EntityFrameworkCore.Migrations;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using testWpf1.Commands;
using testWpf1.ViewModels;
using Var4.Models;
using Var4.Views;

namespace Var4.ViewModels
{
    class AuthorizationViewModel : ViewModelBase
    {

        private string? _login;
        private string? _password;

        public string? Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string? Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand AuthorizationCommand { get; }


        public AuthorizationViewModel()
        {
            AuthorizationCommand = new RelayCommand(Auth);
        }

        private void Auth(object obj)
        {
            using (RestaurantDbContext db = new RestaurantDbContext())
            {
                if (db.Employees.Any(e => e.Login == Login && e.Password == Password))
                {
                    //BondarevMT Ie2muJ_CyX
                    // Scaffold-DbContext "Server=DESKTOP-LRLPTTK\SQLEXPRESS;Database=testdb;
                    // Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer
                    // -OutputDir Models -Context CleanDbContext -f
                    MessageBox.Show($"Здравствуйте, {Login}!");
                    RestaurantWindow restaurantWindow = new RestaurantWindow();
                    restaurantWindow.Show();
                }
                else
                    MessageBox.Show("Ошибка при вводе");
            }
        }
    }
}
