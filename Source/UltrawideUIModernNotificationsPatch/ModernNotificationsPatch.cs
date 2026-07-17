using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Verse;


namespace UltrawideUI
{
    [StaticConstructorOnStartup]
    public class ModernNotificationsPatch
    {
        static ModernNotificationsPatch()
        {
            var harmony = new Harmony("UltrawideUI.ModernNotificationsPatch");
            var assembly = Assembly.GetExecutingAssembly();
            harmony.PatchAll(assembly);
        }


        [HarmonyPatch(typeof(ModernNotifications.AlertRenderer), "Draw")]
        public static class ModernNotifications_AlertRenderer_Draw
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                var counter = 0;
                for (var i = 0; i < codes.Count; i++)
                {
                    if (codes[i].opcode == OpCodes.Ldsfld && codes[i].operand is FieldInfo fieldInfo)
                    {
                        if (fieldInfo.Name == "screenWidth" && fieldInfo.DeclaringType.FullName == "Verse.UI")
                        {
                            counter++;
                            if (counter == 1)
                            {
                            codes.Insert(i + 2, new CodeInstruction(OpCodes.Ldsfld, UltrawideUI.ScreenWidthFieldInfo));
                            }
                            else
                            {
                            codes.Insert(i + 2, new CodeInstruction(OpCodes.Ldsfld, UltrawideUI.RightMultiplierFieldInfo));
                            }
                            codes.Insert(i + 3, new CodeInstruction(OpCodes.Conv_R4));
                            codes.Insert(i + 4, new CodeInstruction(OpCodes.Mul));
                            i += 4;
                        }
                    }
                }
                return codes.AsEnumerable();
            }
        }

        [HarmonyPatch(typeof(ModernNotifications.AlertRenderer), "DrawCard")]
        public static class ModernNotifications_AlertRenderer_DrawCard
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                for (var i = 0; i < codes.Count; i++)
                {
                    if (codes[i].opcode == OpCodes.Ldsfld && codes[i].operand is FieldInfo fieldInfo)
                    {
                        if (fieldInfo.Name == "screenWidth" && fieldInfo.DeclaringType.FullName == "Verse.UI")
                        {
                            codes.Insert(i + 2, new CodeInstruction(OpCodes.Ldsfld, UltrawideUI.RightMultiplierFieldInfo));
                            codes.Insert(i + 3, new CodeInstruction(OpCodes.Conv_R4));
                            codes.Insert(i + 4, new CodeInstruction(OpCodes.Mul));
                            break;
                        }
                    }
                }
                return codes.AsEnumerable();
            }
        }
    }

        [HarmonyPatch(typeof(ModernNotifications.MessageRenderer), "DrawDocked")]
        public static class ModernNotifications_MessageRenderer_DrawDocked
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
            var counter = 0;
                for (var i = 0; i < codes.Count; i++)
                {
                    if (codes[i].opcode == OpCodes.Ldsfld && codes[i].operand is FieldInfo fieldInfo)
                    {
                        if (fieldInfo.Name == "screenWidth" && fieldInfo.DeclaringType.FullName == "Verse.UI")
                        {
                            counter++;
                            if (counter == 1)
                            {
                            codes.Insert(i + 2, new CodeInstruction(OpCodes.Ldsfld, UltrawideUI.ScreenWidthFieldInfo));
                            }
                            else
                            {
                            codes.Insert(i + 2, new CodeInstruction(OpCodes.Ldsfld, UltrawideUI.RightMultiplierFieldInfo));
                            }
                            codes.Insert(i + 3, new CodeInstruction(OpCodes.Conv_R4));
                            codes.Insert(i + 4, new CodeInstruction(OpCodes.Mul));
                        i += 4;
                        }
                    }
                }
                return codes.AsEnumerable();
            }
        }


        [HarmonyPatch(typeof(ModernNotifications.MessageRenderer), "DockedReserveHeight")]
        public static class ModernNotifications_MessageRenderer_DockedReserveHeight
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                for (var i = 0; i < codes.Count; i++)
                {
                    if (codes[i].opcode == OpCodes.Ldsfld && codes[i].operand is FieldInfo fieldInfo)
                    {
                        if (fieldInfo.Name == "screenWidth" && fieldInfo.DeclaringType.FullName == "Verse.UI")
                        {
                            codes.Insert(i + 2, new CodeInstruction(OpCodes.Ldsfld, UltrawideUI.ScreenWidthFieldInfo));
                            codes.Insert(i + 3, new CodeInstruction(OpCodes.Conv_R4));
                            codes.Insert(i + 4, new CodeInstruction(OpCodes.Mul));
                    break;
                        }
                    }
                }
                return codes.AsEnumerable();
            }
        }

        [HarmonyPatch(typeof(ModernNotifications.MessageRenderer), "UpdateDrag")]
        public static class ModernNotifications_MessageRenderer_UpdateDrag
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                for (var i = 0; i < codes.Count; i++)
                {
                    if (codes[i].opcode == OpCodes.Ldsfld && codes[i].operand is FieldInfo fieldInfo)
                    {
                        if (fieldInfo.Name == "screenWidth" && fieldInfo.DeclaringType.FullName == "Verse.UI")
                        {
                            codes.Insert(i + 2, new CodeInstruction(OpCodes.Ldsfld, UltrawideUI.RightMultiplierFieldInfo));
                            codes.Insert(i + 3, new CodeInstruction(OpCodes.Conv_R4));
                            codes.Insert(i + 4, new CodeInstruction(OpCodes.Mul));
                    break;
                        }
                    }
                }
                return codes.AsEnumerable();
            }
        }

        [HarmonyPatch(typeof(ModernNotifications.LetterRenderer), "DrawButton")]
        public static class ModernNotifications_LetterRenderer_DrawButton
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                for (var i = 0; i < codes.Count; i++)
                {
                    if (codes[i].opcode == OpCodes.Ldsfld && codes[i].operand is FieldInfo fieldInfo)
                    {
                        if (fieldInfo.Name == "screenWidth" && fieldInfo.DeclaringType.FullName == "Verse.UI")
                        {
                            codes.Insert(i + 2, new CodeInstruction(OpCodes.Ldsfld, UltrawideUI.RightMultiplierFieldInfo));
                            codes.Insert(i + 3, new CodeInstruction(OpCodes.Conv_R4));
                            codes.Insert(i + 4, new CodeInstruction(OpCodes.Mul));
                    break;
                        }
                    }
                }
                return codes.AsEnumerable();
            }
        }

        [HarmonyPatch(typeof(ModernNotifications.GlobalControlsRenderer), "Draw")]
        public static class ModernNotifications_GlobalControlsRenderer_Draw
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                for (var i = 0; i < codes.Count; i++)
                {
                    if (codes[i].opcode == OpCodes.Ldsfld && codes[i].operand is FieldInfo fieldInfo)
                    {
                        if (fieldInfo.Name == "screenWidth" && fieldInfo.DeclaringType.FullName == "Verse.UI")
                        {
                            codes.Insert(i + 2, new CodeInstruction(OpCodes.Ldsfld, UltrawideUI.RightMultiplierFieldInfo));
                            codes.Insert(i + 3, new CodeInstruction(OpCodes.Conv_R4));
                            codes.Insert(i + 4, new CodeInstruction(OpCodes.Mul));
                        break;
                        }
                    }
                }
                return codes.AsEnumerable();
            }
        }

        [HarmonyPatch(typeof(ModernNotifications.GlobalControlsRenderer), "DrawWorld")]
        public static class ModernNotifications_GlobalControlsRenderer_DrawWorld
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                for (var i = 0; i < codes.Count; i++)
                {
                    if (codes[i].opcode == OpCodes.Ldsfld && codes[i].operand is FieldInfo fieldInfo)
                    {
                        if (fieldInfo.Name == "screenWidth" && fieldInfo.DeclaringType.FullName == "Verse.UI")
                        {
                            codes.Insert(i + 2, new CodeInstruction(OpCodes.Ldsfld, UltrawideUI.RightMultiplierFieldInfo));
                            codes.Insert(i + 3, new CodeInstruction(OpCodes.Conv_R4));
                            codes.Insert(i + 4, new CodeInstruction(OpCodes.Mul));
                    break;
                        }
                    }
                }
                return codes.AsEnumerable();
            }
        }

        [HarmonyPatch(typeof(ModernNotifications.HoverPane), "Draw")]
        public static class ModernNotifications_HoverPane_Draw
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                for (var i = 0; i < codes.Count; i++)
                {
                    if (codes[i].opcode == OpCodes.Ldsfld && codes[i].operand is FieldInfo fieldInfo)
                    {
                        if (fieldInfo.Name == "screenWidth" && fieldInfo.DeclaringType.FullName == "Verse.UI")
                        {
                            codes.Insert(i + 2, new CodeInstruction(OpCodes.Ldsfld, UltrawideUI.ScreenWidthFieldInfo));
                            codes.Insert(i + 3, new CodeInstruction(OpCodes.Conv_R4));
                            codes.Insert(i + 4, new CodeInstruction(OpCodes.Mul));
                        i += 4;
                        }
                    }
                }
                return codes.AsEnumerable();
            }
        }

    [HarmonyPatch]
    public static class ModernNotifications_RoomTempOverlay_Draw
    { 
        static MethodBase TargetMethod()
        {
            return AccessTools.Method("ModernNotifications.RoomTempOverlay:Draw");
        }

        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            for (var i = 0; i < codes.Count; i++)
            {
                if (codes[i].opcode == OpCodes.Ldsfld && codes[i].operand is FieldInfo fieldInfo)
                {
                    if (fieldInfo.Name == "screenWidth" && fieldInfo.DeclaringType.FullName == "Verse.UI")
                    {
                        codes.Insert(i + 1, new CodeInstruction(OpCodes.Conv_R4));
                        codes.Insert(i + 2, new CodeInstruction(OpCodes.Ldsfld, UltrawideUI.RightMultiplierFieldInfo));
                        codes.Insert(i + 3, new CodeInstruction(OpCodes.Conv_R4));
                        codes.Insert(i + 4, new CodeInstruction(OpCodes.Mul));
                        codes.Insert(i + 5, new CodeInstruction(OpCodes.Conv_I4));
                        break;
                    }
                }
            }
            return codes.AsEnumerable();
        }
    }

    [HarmonyPatch]
    public static class ModernNotifications_SmartSpeedCompat_SetInitialSizeAndPosition
    {
        static MethodBase TargetMethod()
        {
            return AccessTools.Method("ModernNotifications.SmartSpeedCompat+EventSpeedMenu:SetInitialSizeAndPosition");
        }

        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            for (var i = 0; i < codes.Count; i++)
            {
                if (codes[i].opcode == OpCodes.Ldsfld && codes[i].operand is FieldInfo fieldInfo)
                {
                    if (fieldInfo.Name == "screenWidth" && fieldInfo.DeclaringType.FullName == "Verse.UI")
                    {
                        codes.Insert(i + 2, new CodeInstruction(OpCodes.Ldsfld, UltrawideUI.RightMultiplierFieldInfo));
                        codes.Insert(i + 3, new CodeInstruction(OpCodes.Conv_R4));
                        codes.Insert(i + 4, new CodeInstruction(OpCodes.Mul));
                        break;
                    }
                }
            }
            return codes.AsEnumerable();
        }
    }
}

