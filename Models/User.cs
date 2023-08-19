using Realms;


namespace InventoryManagementSystem.Models
{
    public partial class User : RealmObject
    {
        [PrimaryKey]
        public string ID { get; set; }
        public string Password { get; set; }

    }
}
