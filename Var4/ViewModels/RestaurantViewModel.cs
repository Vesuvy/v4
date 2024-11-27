using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using testWpf1.Commands;
using testWpf1.ViewModels;
using Var4.Models;
using Var4.Views;

namespace Var4.ViewModels
{
    class RestaurantViewModel : ViewModelBase
    {
        private ObservableCollection<OrderContent>? _orderContents;

        public ObservableCollection<OrderContent>? OrderContents
        {
            get => _orderContents;
            set
            {
                _orderContents = value;
                OnPropertyChanged(nameof(OrderContents));
            }
        }

        public ICommand ShowDishCommand { get; }

        public RestaurantViewModel()
        {
            ShowDishCommand = new RelayCommand(ShowDish);
            LoadOrderContents();
        }

        private void LoadOrderContents()
        {
            using (RestaurantDbContext db = new RestaurantDbContext())
            {
                OrderContents = new ObservableCollection<OrderContent>(db.OrderContents
                    .Include(o => o.Order)
                    .Include(o => o.Dish)
                    //.Include(o => o.Status)
                    .ToList()
                    );
            }
        }

        private void ShowDish(object obj)
        {
            DishListWindow dishListWindow = new DishListWindow();
            dishListWindow.ShowDialog();
        }
    }
}
