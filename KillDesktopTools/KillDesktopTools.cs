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
        public override string Link => "";
        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("net.eia485.KillDesktopTools");
            Debug(Assembly.GetExecutingAssembly().FullName);
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