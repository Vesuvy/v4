using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using testWpf1.Commands;
using testWpf1.ViewModels;
using Var4.Models;
using System.Collections.ObjectModel;

namespace Var4.ViewModels
{
    class AddDishViewModel : ViewModelBase
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

        public ObservableCollection<Category> Categories { get; set; }
        
        public ICommand FinishAddDishCommand { get; }

        public AddDishViewModel()
        {
            LoadCategories();
            FinishAddDishCommand = new RelayCommand(FinishAddDish);
        }

        private void LoadCategories()
        {
            using (RestaurantDbContext db = new RestaurantDbContext()) 
            {
                Categories = new ObservableCollection<Category>(db.Categories.ToList());
                OnPropertyChanged(nameof(Categories));
            }               
        }

        private void FinishAddDish(object obj)
        {
            using (RestaurantDbContext db = new RestaurantDbContext())
            {
                bool checkIsExist = db.Dishes.Any(ad => ad.Title == Title);
                if (!checkIsExist)
                {
                    Dish dish = new Dish
                    {
                        Title = Title,
                        Weight = Weight,
                        CategoryId = CategoryId,
                        Cost = Cost,
                        Availability = Availability
                    };
                    db.Dishes.Add(dish);
                    db.SaveChanges();
                    MessageBox.Show($"Еда '{Title}' - успешно добавлена");
                }
                else
                    MessageBox.Show("Ошибка при добавлении");
            }
        }
    }
}
