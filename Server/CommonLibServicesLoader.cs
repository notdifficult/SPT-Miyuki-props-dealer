//====================================================================================================================//
//=================================== By NoT-Difficult! ==============================================================//
//====================================================================================================================//
using Range = SemanticVersioning.Range;
using Path = System.IO.Path;

using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Helpers;
//using SPTarkov.Server.Core.Models.Eft.Common.Tables;
//using SPTarkov.Server.Core.Models.Spt.Config;
//using SPTarkov.Server.Core.Models.Spt.Mod;
//using SPTarkov.Server.Core.Routers;
//using SPTarkov.Server.Core.Servers;
//using SPTarkov.Server.Core.Utils;
using System.Reflection;
//using WTTServerCommonLib;
using WTTServerCommonLib.Models;
//====================================================================================================================//
namespace MiyukiPropsDealer
{
    [Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 2)]
    public class CommonLibServicesLoader
    (
        WTTServerCommonLib.WTTServerCommonLib wtt,
        ModHelper modHelper
    ) : IOnLoad
//====================================================================================================================//    
    {      
        //public const string _MiyukiTraderId = "6a2b2d6fce04bf77dbda0df2";
        
        public async Task OnLoad()
        {
            var assembly = Assembly.GetExecutingAssembly();                                                             // Get your current assembly
            var pathToMod = modHelper.GetAbsolutePathToModFolder(Assembly.GetExecutingAssembly());                // mod helper add db path
            //var modRoot = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
            
            TraderIds.Add("Miyuki", "6a2b2d6fce04bf77dbda0df2");                                    // trader add
            
            //==========================================================================================================//  soon 
            //await wttCommon.CustomBuffService.CreateCustomBuffs(assembly);
            //==========================================================================================================//  soon 
            //string hideoutRecipesDirectory = Path.Combine("db", "HideoutRecipes");
            //await wtt.CustomHideoutRecipeService.CreateHideoutRecipes(assembly, hideoutRecipesDirectory);
            //==========================================================================================================//  soon 
            //string lootSpawnDirectory = Path.Combine("db", "LootSpawns");
            //await wtt.CustomLootspawnService.CreateCustomLootSpawns(assembly, lootSpawnDirectory);
            //==========================================================================================================//  soon 
            //string lootSpawnQuestsDirectory = Path.Combine("db", "LootSpawnsQuests");
            //await wtt.CustomLootspawnService.CreateCustomLootSpawns(assembly);
            //await wtt.CustomLootspawnService.CreateCustomLootSpawns(assembly, lootSpawnQuestsDirectory);
            //==========================================================================================================//  soon 
            
            
            //string itemConfigsDirectory = Path.Combine("db", "Items");                                                // CustomItems
            await wtt.CustomItemServiceExtended.CreateCustomItems(assembly);                                            // CustomItems
            //await wtt.CustomItemServiceExtended.CreateCustomItems(assembly, itemConfigsDirectory);                    // CustomItems
            
            
            //string CustomLocalesDirectory = Path.Combine("db", "CustomLocales");                                      // CustomLocal
            await wtt.CustomLocaleService.CreateCustomLocales(assembly);                                                // CustomLocal
            //await wtt.CustomLocaleService.CreateCustomLocales(assembly, CustomLocalesDirectory);                      // CustomLocal
            

            //string miyukiQuestsDirectory = Path.Combine("db", "Miyuki");                                              // QuestService
            await wtt.CustomQuestService.CreateCustomQuests(assembly);                                                  // QuestService 
            //await wtt.CustomQuestService.CreateCustomQuests(assembly, miyukiQuestsDirectory);                         // QuestService 
            
            
            //string questZonesDirectory = Path.Combine("db", "QuestZones");                                            // QuestZones
            //await wtt.CustomQuestZoneService.CreateCustomQuestZones(assembly);                                        // QuestZones
            //await wtt.CustomQuestZoneService.CreateCustomQuestZones(assembly, questZonesDirectory);                   // QuestZones

            await Task.CompletedTask;
        }
    }
}
//====================================================================================================================//