using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sport.Models;

namespace Sport.Services
{
    public class UserDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public UserDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);


            #region Creacion - Tablas

            _database.CreateTableAsync<User>().Wait();

            #endregion
        }


        #region CRUD - USER TABLE

        /* METOD-O SELECT SEARCH BAR()*/
        public Task<User> GetUserModelAynsc(int id)
        {
            return _database.Table<User>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        /* METOD-O SELECT ()*/
        public Task<List<User>> GetUserModel()
        {
            return _database.Table<User>().ToListAsync();
        }

        /* METOD-O GUARDAR Y ACTUALIZAR ()*/
        public Task<int> SaveUserModelAsync(User userModel)
        {
            if (userModel.Id != 0)
            {
                return _database.UpdateAsync(userModel);
            }
            else
            {
                return _database.InsertAsync(userModel);
            }
        }

        /* METOD-O ELIMINAR () */
        public Task<int> DeleteUserModelAsync(User userModel)
        {
            return _database.DeleteAsync(userModel);
        }

        public Task<List<User>> GetUsersValidate(string email, string password)
        {
            return _database.QueryAsync<User>("SELECT * FROM User WHERE Email = '" + email + "' AND Password = '" + password + "'");
        }
        #endregion
        public Task<List<User>> GetUsersByEmailAsync(string email)
        {
            return _database.Table<User>().Where(x => x.Email == email).ToListAsync();
        }
        public async Task<bool> IsEmailRegisteredAsync(string email)
        {
            List<User> existingUsers = await GetUsersByEmailAsync(email);
            return existingUsers.Count > 0;
        }
    }
}
