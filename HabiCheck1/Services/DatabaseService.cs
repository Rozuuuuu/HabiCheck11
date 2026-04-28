using HabiCheck.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HabiCheck.Services;

public class DatabaseService
{
    private SQLiteAsyncConnection? _db;

    private async Task InitAsync()
    {
        if (_db is not null) return;
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "habicheck.db3");
        _db = new SQLiteAsyncConnection(dbPath);
        await _db.CreateTableAsync<ScanRecord>();
    }

    public async Task SaveScanAsync(ScanRecord record)
    {
        await InitAsync();
        await _db!.InsertAsync(record);
    }

    public async Task<List<ScanRecord>> GetScansAsync()
    {
        await InitAsync();
        return await _db!.Table<ScanRecord>()
                         .OrderByDescending(r => r.ScannedAt)
                         .ToListAsync();
    }

    public async Task DeleteScanAsync(ScanRecord record)
    {
        await InitAsync();
        await _db!.DeleteAsync(record);
    }
}
