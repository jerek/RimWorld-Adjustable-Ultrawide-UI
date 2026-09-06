using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;
using Verse;

namespace UltrawideUI
{
    [StaticConstructorOnStartup]
    public class VanillaGravshipExpandedPatch
    {
        static VanillaGravshipExpandedPatch()
        {
            var harmony = new Harmony("UltrawideUI.VanillaGravshipExpandedPatch");
            var assembly = Assembly.GetExecutingAssembly();
            harmony.PatchAll(assembly);
        }

        [HarmonyPatch(typeof(VanillaGravshipExpanded.ArchitectCategoryTab_DesignationTabOnGUI_Patch), "DrawBetterArchitectMenu")]
        public static class VanillaGravshipExpanded_ArchitectCategoryTab_DesignationTabOnGUI_Patch_DrawBetterArchitectMenu
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                var zeroCounter = 0;
                var xCounter = 0;

                for (var i = 0; i < codes.Count; i++)
                {
                    var opcode = codes[i].opcode;
                    var operand = codes[i].operand;

                    if (codes[i].opcode == OpCodes.Ldc_R4 && codes[i].operand.Equals(0f))
                    {
                        zeroCounter++;
                        if (zeroCounter == 1)
                        {

                            codes[i] = new CodeInstruction(OpCodes.Ldsfld, UltrawideUI.ScreenWidthFieldInfo);
                            codes.Insert(i + 1, new CodeInstruction(OpCodes.Conv_R4));
                            codes.Insert(i + 2, new CodeInstruction(OpCodes.Ldsfld, UltrawideUI.LeftMultiplierFieldInfo));
                            codes.Insert(i + 3, new CodeInstruction(OpCodes.Conv_R4));
                            codes.Insert(i + 4, new CodeInstruction(OpCodes.Mul));
                        }
                    }

                    if (opcode == OpCodes.Ldsfld && operand is FieldInfo staticField)
                    {
                        if (staticField.Name == "screenWidth" && staticField.DeclaringType.FullName == "Verse.UI")
                        {
                            codes.Insert(i + 2, new CodeInstruction(OpCodes.Ldsfld, UltrawideUI.UIWidthFieldInfo));
                            codes.Insert(i + 3, new CodeInstruction(OpCodes.Conv_R4));
                            codes.Insert(i + 4, new CodeInstruction(OpCodes.Mul));
                        }
                    }

                    if (opcode == OpCodes.Ldfld && operand is FieldInfo instanceField)
                    {
                        if (instanceField.Name == "x" && instanceField.DeclaringType.FullName == "UnityEngine.Vector2")
                        {
                            xCounter++;
                            if (xCounter == 2)
                            {
                                codes.Insert(i + 1, new CodeInstruction(OpCodes.Ldsfld, UltrawideUI.ScreenWidthFieldInfo));
                                codes.Insert(i + 2, new CodeInstruction(OpCodes.Conv_R4));
                                codes.Insert(i + 3, new CodeInstruction(OpCodes.Ldsfld, UltrawideUI.LeftMultiplierFieldInfo));
                                codes.Insert(i + 4, new CodeInstruction(OpCodes.Conv_R4));
                                codes.Insert(i + 5, new CodeInstruction(OpCodes.Mul));
                                codes.Insert(i + 6, new CodeInstruction(OpCodes.Add));
                                break;
                            }
                        }
                    }
                }
                return codes.AsEnumerable();
            }
        }
        [HarmonyPatch(typeof(VanillaGravshipExpanded.ArchitectCategoryTab_DesignationTabOnGUI_Patch), "DoInfoBox")]
        public static class VanillaGravshipExpanded_DoInfoBox_Patch
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                var infoRectGetter = AccessTools.PropertyGetter(typeof(RimWorld.ArchitectCategoryTab), "InfoRect");

                for (var i = 0; i < codes.Count; i++)
                {
                    if (codes[i].Calls(infoRectGetter))
                    {
                        codes.Insert(i + 1, new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(VanillaGravshipExpanded_DoInfoBox_Patch), nameof(ShiftMyRect))));
                        break;
                    }
                }

                return codes.AsEnumerable();
            }

            public static Rect ShiftMyRect(Rect rect)
            {
                rect.x += UI.screenWidth * UltrawideUI.LeftMultiplier;
                return rect;
            }
        }
    }
}

