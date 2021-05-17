using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TareasXamarin
{
    public class DatabaseCrud
    {
        readonly SQLiteAsyncConnection database;
        public DatabaseCrud(string dbPath)
        {
            // Creamos conexión con la base de datos interna SQLite
            database = new SQLiteAsyncConnection(dbPath);
            // Creamos tablas dentro de la BD.
            database.CreateTableAsync<Models.User>().Wait();
            database.CreateTableAsync<Models.Eventos>().Wait();
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

        // Método para obtener todos los eventos de la tabla
        public Task<List<Models.Eventos>> GetEventsAsync()
        {
            return database.Table<Models.Eventos>().ToListAsync();
        }

        // Método para obtener un único evento según su ID
        public Task<Models.Eventos> GetEventsAsync(int id)
        {
            return database.Table<Models.Eventos>().Where(i => i.EventID == id).FirstOrDefaultAsync();
        }

        // Método para guardar evento en la tabla de la BD. Si no existe lo inserta, si existe lo actualiza
        public Task<int> SaveEventAsync(Models.Eventos evento)
        {
            if (evento.EventID == 0)
            {
                return database.InsertAsync(evento);
            }
            else
            {
                return database.UpdateAsync(evento);
            }
        }

        // Método para eliminar un evento
        public Task<int> DeleteEventAsync(Models.Eventos evento)
        {
            return database.DeleteAsync(evento);
        }

        // Método para saber si existe un usuario con una contraseña concretos
        public bool GetExistingUser(string user, string pass)
        {
            Task<int> existingUser = database.Table<Models.User>().Where(i => i.UserName == user && i.UserPassword == pass).CountAsync();

            return (existingUser.Result > 0);
        }

        // Método para obtener el usuario escogido
        public Models.User GetSelectedUser(string user, string pass)
        {
            Task<Models.User> selectedUser = database.Table<Models.User>().Where(i => i.UserName == user && i.UserPassword == pass).FirstOrDefaultAsync();

            return selectedUser.Result;
        }
    }
}
