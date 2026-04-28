using SQLite;
using System;

namespace HabiCheck.Models;

public class ScanRecord
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string FabricName { get; set; } = string.Empty;
    public string Grade { get; set; } = string.Empty;
    public string FiberType { get; set; } = string.Empty;
    public DateTime ScannedAt { get; set; } = DateTime.Now;
    public string ImagePath { get; set; } = string.Empty;
}