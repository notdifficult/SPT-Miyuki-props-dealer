//====================================================================================================================//
//=================================== By NoT-Difficult! ==============================================================//
//====================================================================================================================//
using Range = SemanticVersioning.Range;
using Path = System.IO.Path;
//====================================================================================================================//
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Helpers;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Spt.Config;
using SPTarkov.Server.Core.Models.Spt.Mod;
using SPTarkov.Server.Core.Routers;
using SPTarkov.Server.Core.Servers;
using SPTarkov.Server.Core.Utils;
using System.Reflection;
//using System.Text.Json;
using SPTarkov.Server.Core.Models.Utils;
//using SPTarkov.Server.Core.Models.Logging;
//using Microsoft.Extensions.Logging;
//using SPTarkov.Server.Core.Models.Common;
//using SPTarkov.Server.Core.Services;
using WTTServerCommonLib.Models;
using WTTServerCommonLib.Services;
//====================================================================================================================//

namespace MiyukiPropsDealer;

public record ModMetadata : AbstractModMetadata
{
    public override string ModGuid { get; init; } = "com.NoTDifficult.MiyukiPropsDealer";
    public override string Name { get; init; } = "MiyukiPropsDealer";
    public override string Author { get; init; } = "NoTDifficult";
    public override List<string>? Contributors { get; init; } = [];
    public override SemanticVersioning.Version Version { get; init; } = new("2.0.1");
    public override Range SptVersion { get; init; } = new("~4.0.13");
    public override List<string>? Incompatibilities { get; init; } = [];
    public override Dictionary<string, Range>? ModDependencies { get; init; } = new() { { "com.wtt.commonlib", new Range("~2.0") } };
    public override string? Url { get; init; } = "https://github.com/notdifficult/SPT-Miyuki-props-dealer";
    public override bool? IsBundleMod { get; init; } = true;
    public override string License { get; init; } = "MIT";
}

//====================================================================================================================//

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]                                                            
public class MPDBasicModInfo
(
    WTTServerCommonLib.WTTServerCommonLib wtt,
    ModHelper modHelper,
    ImageRouter imageRouter,
    ISptLogger<MPDBasicModInfo> logger,
    ConfigServer cfgServer,
    TimeUtil timeUtil,
    AddCustomTraderHelper addCth                                                                                        // This is a custom class we add for this mod, we made it injectable so it can be accessed like other classes here
    //CustomItemService customItemService
)
    : IOnLoad
{
    private readonly TraderConfig _traderConfig = cfgServer.GetConfig<TraderConfig>();
    private readonly RagfairConfig _ragfairConfig = cfgServer.GetConfig<RagfairConfig>();
    // private ItemConfig itemConfig = configServer.GetConfig<ItemConfig>();                                            // soon
    
    public Task OnLoad()
    {
        var assembly = Assembly.GetExecutingAssembly();                                                                 // Get your current assembly (WTT)
        var pathToMod = modHelper.GetAbsolutePathToModFolder(Assembly.GetExecutingAssembly());                     // A path to the mods files we use below
        var traderImagePath = Path.Combine(pathToMod, "db/Miyuki/images/Miyuki.png");                                   // A relative path to the trader icon to show
        var traderBase = modHelper.GetJsonDataFromFile<TraderBase>(pathToMod, "db/Miyuki/base.json");           // The base json containing trader settings we will add to the server
        
        imageRouter.AddRoute(traderBase.Avatar!.Replace(".png", ""), traderImagePath);                                  // Create a helper class and use it to register our traders image/icon + set its stock refresh time
        addCth.SetTraderUpdateTime(_traderConfig, traderBase, timeUtil.GetHoursAsSeconds(1), timeUtil.GetHoursAsSeconds(2));
        
        _ragfairConfig.Traders.TryAdd(traderBase.Id, true);                                                             // Add our trader to the config file, this lets it be seen by the flea market
        { logger.Warning($"Trader {traderBase.Id} already in Rag fair config.");}
        addCth.AddTraderWithEmptyAssortToDb(traderBase);
        
        //addCth.AddTraderToLocales(traderBase, "Miyuki", "Secret experiment number C416. developed at TerraGroup Labs.");
        
        var assort = modHelper.GetJsonDataFromFile<TraderAssort>(pathToMod, "db/Miyuki/assort.json");           // Get the assort data from JSON
        
        addCth.OverwriteTraderAssort(traderBase.Id, assort);                                                         // Save the data we loaded above into the trader we've made
        
        logger.Info($"Trader {traderBase.Nickname} loaded successfully.");                                              // log 
        
        return Task.CompletedTask;                                                                                      // Send back a success to the server to say our trader is good to go
    }
}
//====================================================================================================================// end