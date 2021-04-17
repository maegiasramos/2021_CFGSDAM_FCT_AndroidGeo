using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace TareasXamarin.Models
{
    [SQLite.Table("Eventos")]
    public class Eventos
    {
        [PrimaryKey, AutoIncrement]
        public int EventID
        {
            get;
            set;
        }

        public string EventName
        {
            get;
            set;
        }

        public string EventDescription
        {
            get;
            set;
        }

        public int OwnerID 
        { 
            get; 
            set; 
        }

        public string Visibility
        {
            get;
            set;
        }

        public string Coordinates
        {
            get;
            set;
        }
    }
}
