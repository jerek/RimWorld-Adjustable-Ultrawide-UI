using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Verse;

namespace UltrawideUI
{
    [StaticConstructorOnStartup]
    public class ChooseYourMedicinePatch
    {
        static ChooseYourMedicinePatch()
        {
            var harmony = new Harmony("UltrawideUI.ChooseYourMedicinePatch");
            var assembly = Assembly.GetExecutingAssembly();
            harmony.PatchAll(assembly);
            Verse.Log.Message("Ocsar 0");
        }
/*
        [HarmonyPatch(typeof(ChooseYourMedicine.MainTabWindow_Medicine_HelperGui), "get_InitialSize")]
        public static class ChooseYourMecine_MainTabWindow_Medicine_HelpGui_get_InitialSize
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);

                for (var i = 0; i < codes.Count; i++)
                {
                    var opcode = codes[i].opcode;
                    var operand = codes[i].operand;

                    if (opcode == OpCodes.Ldsfld && operand is FieldInfo staticField)
                    {
                        if (staticField.Name == "screenWidth" && staticField.DeclaringType.FullName == "Verse.UI")
                        {
                            Verse.Log.Message("Ocsar 1");
                            codes.Insert(i + 2, new CodeInstruction(OpCodes.Ldsfld, UltrawideUI.UIWidthFieldInfo));
                            codes.Insert(i + 3, new CodeInstruction(OpCodes.Conv_R4));
                            codes.Insert(i + 4, new CodeInstruction(OpCodes.Mul));
                            break;
                        }
                    }
                }
                return codes.AsEnumerable();
            }
        }

        [HarmonyPatch(typeof(ChooseYourMedicine.MainTabWindow_Medicine_HelperGui), "DoWindowContents")]
        public static class ChooseYourMecine_MainTabWindow_Medicine_HelpGui_DoWindowContents
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);

                for (var i = 0; i < codes.Count; i++)
                {
                    var opcode = codes[i].opcode;
                    var operand = codes[i].operand;

                    if (opcode == OpCodes.Ldsfld && operand is FieldInfo staticField)
                    {
                        if (staticField.Name == "screenWidth" && staticField.DeclaringType.FullName == "Verse.UI")
                        {
                            Verse.Log.Message("Ocsar 2");
                            codes.Insert(i + 1, new CodeInstruction(OpCodes.Conv_R4));
                            codes.Insert(i + 2, new CodeInstruction(OpCodes.Ldsfld, UltrawideUI.UIWidthFieldInfo));
                            codes.Insert(i + 3, new CodeInstruction(OpCodes.Conv_R4));
                            codes.Insert(i + 4, new CodeInstruction(OpCodes.Mul));
                            codes.Insert(i + 5, new CodeInstruction(OpCodes.Conv_I4));
                        }
                    }
                }
                return codes.AsEnumerable();
            }
        }
*/
    }
}
