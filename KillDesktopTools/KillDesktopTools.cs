using HarmonyLib;
using NeosModLoader;
using System.Reflection;
using System.Threading.Tasks;
using FrooxEngine;


namespace KillDesktopTools
{
    public class KillDesktopTools : NeosMod
    {
        public override string Name => "KillDesktopTools";
        public override string Author => "eia485";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/EIA485/NeosKillDesktopTools/";
        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("net.eia485.KillDesktopTools");
            harmony.PatchAll();

        }
		
		[HarmonyPatch(typeof(CommonTool), "SpawnAndEquip")]
        class KillDesktopToolsPatch
        {
            public static bool Prefix(ref Task __result)
            {
                __result = new TaskCompletionSource<bool>().Task;
                return false;

            }
        
        }
    }
}
