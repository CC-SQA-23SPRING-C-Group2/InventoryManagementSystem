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

namespace InventoryManagementSystem
{
    /// <summary>
    /// Interaction logic for ControlWindow.xaml
    /// </summary>
    public partial class ControlWindow : Window
    {
        public ControlWindow()
        {
            InitializeComponent();
        }

        private void ViewProductButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new ProductListWindow();
            window.ShowDialog();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new ProductEditorWindow();
            window.ShowDialog();
        }
    }
}
