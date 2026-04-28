using HabiCheck.Models;
using System.Threading.Tasks;

namespace HabiCheck.Services;

public interface IFabricAnalyzerService
{
    Task<FabricData> AnalyzeAsync(Stream imageStream, string hulasLevel);
}