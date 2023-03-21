using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CulinaryApp.Model;
using SQLite;

namespace CulinaryApp.Data
{
	public class UserRecipeDB
	{
        SQLiteAsyncConnection Database;

        public UserRecipeDB()
        {
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await Database.CreateTableAsync<UserRecipe>();
        }

        public async Task<List<UserRecipe>> GetUserRecipesAsync()
        {
            await Init();
            return await Database.Table<UserRecipe>().ToListAsync();
        }



        public async Task<UserRecipe> GetUserRecipeAsync(int id)
        {
            await Init();
            return await Database.Table<UserRecipe>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveUserRecipeAsync(UserRecipe item)
        {
            await Init();
            if (item.ID != 0)
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteUserRecipeAsync(UserRecipe item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}

