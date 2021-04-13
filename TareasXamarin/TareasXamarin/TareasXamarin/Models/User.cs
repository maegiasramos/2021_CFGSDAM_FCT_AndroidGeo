using SQLite;

namespace TareasXamarin.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserID
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string UserPassword
        {
            get;
            set;
        }
    }
}
