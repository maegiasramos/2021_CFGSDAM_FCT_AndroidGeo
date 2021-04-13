using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TareasXamarin
{
    public class UserDatabase
    {
        readonly SQLiteAsyncConnection database;
        public UserDatabase(string dbPath)
        {
            // Creamos conexión con la base de datos interna SQLite
            database = new SQLiteAsyncConnection(dbPath);
            // Creamos tablas dentro de la BD. En caso de ser más de una, usar CreateTablesAsync
            database.CreateTableAsync<Models.User>().Wait();
            // TODO Añadir tabla Eventos a la BD
        }

        // Método para obtener todos los Usuarios de la tabla
        public Task<List<Models.User>> GetUsersAsync()
        {
            return database.Table<Models.User>().ToListAsync();
        }

        // Método para obtener un único usuario según su ID
        public Task<Models.User> GetUserAsync(int id)
        {
            return database.Table<Models.User>().Where(i => i.UserID == id).FirstOrDefaultAsync();
        }

        // Método para guardar usuario en la tabla de la BD. Si no existe lo inserta, si existe lo actualiza
        public Task<int> SaveUserAsync(Models.User user)
        {
            if(user.UserID == 0)
            {
                return database.InsertAsync(user);
            }
            else
            {
                return database.UpdateAsync(user);
            }
        }

        // Método para eliminar un empleado
        public Task<int> DeleteUserAsync(Models.User user)
        {
            return database.DeleteAsync(user);
        }
    }
}
