using SPTarkov.Server.Core.Models.Utils;

namespace MiyukiPropsDealer.Utils;

public static class Logging
{
    static string prefix = "[NoTDifficult_MiyukiPropsDealer] ";
    
    public static void Log(ISptLogger<MPDBasicModInfo> log, string message)
    {
        log.LogWithColor(prefix + message, SPTarkov.Server.Core.Models.Logging.LogTextColor.Magenta);
    }

    public static void Warning(ISptLogger<MPDBasicModInfo> log, string message)
    {
        log.Warning(prefix + message);
    }

    public static void Info(ISptLogger<MPDBasicModInfo> log, string message)
    {
        log.Info(prefix + message);
    }

    public static void Error(ISptLogger<MPDBasicModInfo> log, string message)
    {
        log.Error(prefix + message);
    }

    public static void Success(ISptLogger<MPDBasicModInfo> log, string message)
    {
        log.Success(prefix + message);
    }
}