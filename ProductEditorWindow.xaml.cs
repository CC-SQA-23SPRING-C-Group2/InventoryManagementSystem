using InventoryManagementSystem.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for ProductEditorWindow.xaml
    /// </summary>
    public partial class ProductEditorWindow : Window
    {
        private Realm context;
        public ProductEditorWindow()
        {
            context = ((App)Application.Current).Context;
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            NameErrorTextB.Text = "";
            PriceErrorTextB.Text = "";
            StockErrorTextB.Text = "";
            ThresholdErrorTextB.Text = "";
            SaveErrorTextB.Text = "";
            bool errorExist = false;

            string name = NameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(name) )
            {
                NameErrorTextB.Text = "Please enter a name.";
                errorExist = true;
            }
            else
            {
                var product = context.All<Product>().FirstOrDefault(p => p.Name == name);
                if (product != null)
                {
                    NameErrorTextB.Text = "Name already exists.";
                    errorExist = true;
                }
            }


            double price;
            if(!double.TryParse(PriceTextBox.Text, out price)) {
                PriceErrorTextB.Text = "Please enter a valid price.";
                errorExist = true;
            }
            else if(price < 0)
            {
                PriceErrorTextB.Text = "Please enter a valid price.";
                errorExist = true;
            }


            int stock;
            if (!int.TryParse(StockTextBox.Text, out stock))
            {
                StockErrorTextB.Text = "Please enter a valid stock.";
                errorExist = true;
            }
            else if (stock < 0)
            {
                StockErrorTextB.Text = "Please enter a valid stock."; 
                errorExist = true;
            }


            int threshold;
            if (!int.TryParse(ThresholdTextBox.Text, out threshold))
            {
                ThresholdErrorTextB.Text = "Please enter a valid threshold.";
                errorExist = true;
            }
            else if (threshold < 0)
            {
                ThresholdErrorTextB.Text = "Please enter a valid threshold.";
                errorExist = true;
            }

            Product newProduct = new()
            {
                Name = name,
                Price = price,
                QuantityInHand = stock,
                ReorderThreshold = threshold,
                QuantitySold = 0
            };

            if (errorExist)
            {
                return;
            }

            try
            {
                context.Write(() =>
                {
                    context.Add(newProduct);
                });
                this.Close();
            }
            catch (Exception ex)
            {
                SaveErrorTextB.Text = ex.Message;
                errorExist = true;
            }
        }
    }
}
