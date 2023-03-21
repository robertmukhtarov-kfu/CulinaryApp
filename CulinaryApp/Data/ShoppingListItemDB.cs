using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CulinaryApp.Model;
using SQLite;

namespace CulinaryApp.Data
{
	public class ShoppingListItemDB
	{
        SQLiteAsyncConnection Database;

        public ShoppingListItemDB()
        {
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await Database.CreateTableAsync<ShoppingListItem>();
        }

        public async Task<List<ShoppingListItem>> GetShoppingListItemsAsync()
        {
            await Init();
            return await Database.Table<ShoppingListItem>().ToListAsync();
        }



        public async Task<ShoppingListItem> GetShoppingListItemAsync(int id)
        {
            await Init();
            return await Database.Table<ShoppingListItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveShoppingListItemAsync(ShoppingListItem item)
        {
            await Init();
            if (item.ID != 0)
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteShoppingListItemAsync(ShoppingListItem item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}

