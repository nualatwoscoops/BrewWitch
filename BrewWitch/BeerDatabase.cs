using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BrewWitch
{
    public class BeerDatabase
    {
        SQLiteAsyncConnection _database;

        public BeerDatabase(string databasePath)
        {
            _database = new SQLiteAsyncConnection(databasePath);
            _database.CreateTableAsync<Beer>().Wait(); //Resolve this using aysnc instead 
        }

        public async Task<List<Beer>> Browse()
        {
            return await _database.Table<Beer>().ToListAsync();
        }

        public async Task<int> Add(Beer beer)
        {
            return await _database.InsertAsync(beer);
        }

        public async Task<int> Edit(Beer beer)
        {
            return await _database.UpdateAsync(beer);
        }

        public async Task<int> Delete(Beer beer)
        {
            return await _database.DeleteAsync(beer);
        }
        public async Task<Beer> Read(int id)
        {
            return await _database.FindAsync<Beer>(id); //test this 
        }
    }
}
