using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using testWpf1.Commands;
using testWpf1.ViewModels;
using Var4.Models;
using Var4.Views;

namespace Var4.ViewModels
{
    class DishListViewModel : ViewModelBase
    {
        
        private string? _title;
        public string? Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private double? _weight;
        public double? Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        private int? _categoryId;
        public int? CategoryId
        {
            get => _categoryId;
            set
            {
                _categoryId = value;
                OnPropertyChanged(nameof(CategoryId));
            }
        }

        private double? _cost;
        public double? Cost
        {
            get => _cost;
            set
            {
                _cost = value;
                OnPropertyChanged(nameof(Cost));
            }
        }

        private string? _availability;
        public string? Availability
        {
            get => _availability;
            set
            {
                _availability = value;
                OnPropertyChanged(nameof(Availability));
            }
        }
        private ObservableCollection<Dish>? _dishes;
        public ObservableCollection<Dish>? Dishes
        {
            get => _dishes;
            set
            {
                _dishes = value;
                OnPropertyChanged(nameof(Dishes));
            }
        }
        public ObservableCollection<Category>? Categories { get; set; }

        public ICommand GoToAddDishWindowCommand { get; }

        public DishListViewModel()
        {
            LoadCategories();
            LoadDishes();
            GoToAddDishWindowCommand = new RelayCommand(GoToAddDishWindow);
        }

        private void LoadCategories()
        {
            using (RestaurantDbContext db = new RestaurantDbContext())
            {
                Categories = new ObservableCollection<Category>(db.Categories.ToList());
                OnPropertyChanged(nameof(Categories));
            }
                
        }
        private void LoadDishes()
        {
            using (RestaurantDbContext db = new RestaurantDbContext())
            {
                Dishes = new ObservableCollection<Dish>(db.Dishes.Include(d => d.Category).ToList());
            }
        }

        private void GoToAddDishWindow(object obj)
        {
            AddDishWindow addDishWindow = new AddDishWindow();
            addDishWindow.Show();
        }
    }
}
