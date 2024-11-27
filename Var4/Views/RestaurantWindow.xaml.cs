﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Var4.ViewModels;

namespace Var4.Views
{
    /// <summary>
    /// Логика взаимодействия для RestaurantWindow.xaml
    /// </summary>
    public partial class RestaurantWindow : Window
    {
        public RestaurantWindow()
        {
            InitializeComponent();
            DataContext = new RestaurantViewModel();
        }
    }
}
