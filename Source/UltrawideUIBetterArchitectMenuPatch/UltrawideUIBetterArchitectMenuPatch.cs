using HarmonyLib;
using System.Reflection;
using Verse;

namespace UltrawideUI
{
    [StaticConstructorOnStartup]
    public class UltrawideUIBetterArchitectMenuPatch
    {
        static UltrawideUIBetterArchitectMenuPatch()
        {
            var harmony = new Harmony("UltrawideUI.BetterArchitectMenuPatch");
            var assembly = Assembly.GetExecutingAssembly();
            harmony.PatchAll(assembly);
        }

        [HarmonyPatch(typeof(BetterArchitect.ExtensionMethods), "get_UIWidth")]
        public static class BetterArchitect_ExtensionMethods_get_UIWidth
        {
            [HarmonyPrefix]
            public static bool Prefix(ref float __result)
            {
                __result = UI.screenWidth * UltrawideUI.UIWidth;
                return false;
            }
        }

        [HarmonyPatch(typeof(BetterArchitect.ExtensionMethods), "get_LeftUIEdge")]
        public static class BetterArchitect_ExtensionMethods_get_LeftUIEdge
        {
            [HarmonyPrefix]
            public static bool Prefix(ref float __result)
            {
                __result = UI.screenWidth * UltrawideUI.LeftMultiplier;
                return false;
            }
        }
    }
}
