using InventoryManagementSystem.Models;
using Realms;
using System.Windows;

namespace InventoryManagementSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Realm Context;

        public App()
        {
            //Create an In-memory Database
            var config = new InMemoryConfiguration("some-identifier");
            Context = Realm.GetInstance(config);
            //Add default admin to the database
            User admin = new()
            {
                ID = "admin",
                Password = "Admin"
            };
            Context.Write(() =>
            {
                Context.Add(admin);
            });

            //Add sample data of product
            Product product = new()
            {
                Name = "Test",
                Price = 10.96,
                QuantityInHand = 100,
                QuantitySold = 100,
                ReorderThreshold = 10,
            };

            Context.Write(() =>
            {
                Context.Add(product);
            });
        }
    }
}
