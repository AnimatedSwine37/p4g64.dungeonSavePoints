using Reloaded.Memory.SigScan.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using System.Diagnostics;
using System.Text;

namespace p4g64.dungeonSavePoints.NuGet.templates.defaultPlus;
internal class Utils
{
    private static ILogger _logger;
    internal static nint BaseAddress { get; private set; }

    internal static bool Initialise(ILogger logger)
    {
        _logger = logger;
        return true;

    }

    internal static void Log(string message)
    {
        _logger.WriteLine($"[Dungeon Save Points] {message}");
    }

    internal static void LogError(string message, Exception e)
    {
        _logger.WriteLine($"[Dungeon Save Points] {message}: {e.Message}", System.Drawing.Color.Red);
    }

    internal static void LogError(string message)
    {
        _logger.WriteLine($"[Dungeon Save Points] {message}", System.Drawing.Color.Red);
    }

}
