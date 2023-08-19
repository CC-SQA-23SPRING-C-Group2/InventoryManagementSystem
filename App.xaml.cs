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
        public Realm context;

        public App()
        {
            //Create an In-memory Database
            var config = new InMemoryConfiguration("some-identifier");
            context = Realm.GetInstance(config);
            //Add default admin to the database
            User admin = new()
            {
                ID = "admin",
                Password = "Admin"
            };
            context.Write(() =>
            {
                context.Add(admin);
            });
            
        }
    }
}
