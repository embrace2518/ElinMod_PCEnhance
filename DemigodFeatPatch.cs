using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PCEnhance
{
    //
    internal class DemigodFeatPatch
    {
        public static void Reforge(Thing t, int n)
        {
            foreach (Element element in ((ElementContainer)((Card)t).elements).dict.Values)
            {
                if (element.id != 66 && element.id != 67 && element.id != 64 /*0x40*/ && element.id != 65 && element.id != 92)
                {
                    switch (((Card)t).id)
                    {
                        case "blunt_earth":
                            if (element.id == 70 || element.id == 55 || element.id == 56 || element.id == 954 || element.id == 423 || element.id == 421)
                                element.vExp = n;
                            ((Card)t).c_idDeity = ((Religion)EClass.game.religions.Earth).id;
                            continue;
                        case "cloak_mani":
                            if (element.id == 427 || element.id == 957 || element.id == 105 || element.id == 466 || element.id == 664)
                                element.vExp = n;
                            ((Card)t).c_idDeity = ((Religion)EClass.game.religions.Machine).id;
                            continue;
                        case "gun_mani":
                            ((Card)t).c_idDeity = ((Religion)EClass.game.religions.Machine).id;
                            continue;
                        case "kogitsunemaru":
                            if (element.id != 656)
                                element.vExp = n;
                            ((Card)t).c_idDeity = ((Religion)EClass.game.religions.Trickery).id;
                            continue;
                        case "luckydagger":
                            if (element.id != 426)
                                element.vExp = n;
                            ((Card)t).c_idDeity = ((Religion)EClass.game.religions.Luck).id;
                            continue;
                        case "pole_holy":
                            if (element.id == 60 || element.id == 461 || element.id == 423)
                                element.vExp = n;
                            ((Card)t).c_idDeity = ((Religion)EClass.game.religions.Healing).id;
                            continue;
                        case "scythe_kumi":
                            if (element.id == 6650 || element.id == 480 || element.id == 959 || element.id == 428 || element.id == 640 || element.id == 665)
                                element.vExp = n;
                            ((Card)t).c_idDeity = ((Religion)EClass.game.religions.Harvest).id;
                            continue;
                        case "shirt_wind":
                            if (!(element is Resistance) && element.id != 226 && element.id != 152 && element.id != 77)
                                element.vExp = n;
                            ((Card)t).c_idDeity = ((Religion)EClass.game.religions.Wind).id;
                            continue;
                        case "staff_element":
                            if (element.id == 411 || element is Resistance && element.id != 959)
                                element.vExp = n;
                            ((Card)t).c_idDeity = ((Religion)EClass.game.religions.Element).id;
                            continue;
                        case "sword_muramasa2":
                            if (element.id == 401 || element.id == 916 || element.id == 661)
                                element.vExp = n;
                            ((Card)t).c_idDeity = ((Religion)EClass.game.religions.MoonShadow).id;
                            continue;
                        case "warmonger":
                            if (element.id == 423 || element.id == 463 || element.id == 460 || element.id == 464 || element.id == 465)
                                element.vExp = n;
                            ((Card)t).c_idDeity = ((Religion)EClass.game.religions.Strife).id;
                            continue;
                        case "windbow":
                            ((Card)t).c_idDeity = ((Religion)EClass.game.religions.Wind).id;
                            continue;
                        default:
                            continue;
                    }
                }
            }
        }
    }
    //
    [HarmonyPatch(typeof(ElementContainerFaction), "OnEquip", new Type[] { typeof(Thing) })]
    internal static class OnEquipPatch
    {
        public static bool Prefixed;

        [HarmonyPrefix]
        public static bool Prefix(Thing t)
        {
            if (((Card)t).HasTag((CTAG)29))
                DemigodFeatPatch.Reforge(t, -1);
            return true;
        }

        [HarmonyPostfix]
        public static void Postfix(Thing t)
        {
            if (!OnEquipPatch.Prefixed || !((Card)t).HasTag((CTAG)29))
                return;
            DemigodFeatPatch.Reforge(t, 0);
        }
    }
    // 特定指令不执行
    [HarmonyPatch(typeof(ElementContainer), "AddNote")]
    internal static class AddNotePatch
    {
        [HarmonyTranspiler]
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> codeInstructionList = new List<CodeInstruction>(instructions);
            int index1 = -1;
            for (int index2 = 0; index2 < codeInstructionList.Count - 1; ++index2)
            {
                if (codeInstructionList[index2].opcode == OpCodes.Brtrue && codeInstructionList[index2 + 1].opcode == OpCodes.Ldc_I4_S)
                {
                    index1 = index2;
                    break;
                }
            }
            codeInstructionList[index1].opcode = OpCodes.Nop;
            return (IEnumerable<CodeInstruction>)codeInstructionList;
        }
    }
    // 
    [HarmonyPatch(typeof(ElementContainerFaction), "IsEffective")]
    internal static class IsEffectivePatch
    {
        [HarmonyPrefix]
        public static bool Prefix(ref bool result)
        {
            result = true;
            return false;
        }
    }
    //
    [HarmonyPatch(typeof(Game), "OnGameInstantiated")]
    internal static class OnGameInstantiated_Patch
    {
        [HarmonyPostfix]
        public static void Postfix(Game __instance)
        {
            Patches patchInfo = Harmony.GetPatchInfo((MethodBase)typeof(ElementContainer).GetMethod("AddNote"));
            if (patchInfo == null || patchInfo.Prefixes.Count <= 0)
                return;
            OnEquipPatch.Prefixed = true;
        }
    }
    //
    [HarmonyPatch(typeof(Game), "OnLoad")]
    internal static class OnLoad_Patch
    {
        [HarmonyPostfix]
        public static void Postfix(Game __instance)
        {
            Patches patchInfo = Harmony.GetPatchInfo((MethodBase)typeof(ElementContainer).GetMethod("AddNote"));
            if (patchInfo == null || patchInfo.Prefixes.Count <= 0)
                return;
            OnEquipPatch.Prefixed = true;
        }
    }
    //
    [HarmonyPatch(typeof(ElementContainerFaction), "OnUnequip", new Type[] { typeof(Thing) })]
    internal static class OnUnequip_Patch
    {
        [HarmonyPrefix]
        public static bool Prefix(Thing t)
        {
            if (((Card)t).HasTag((CTAG)29))
                DemigodFeatPatch.Reforge(t, -1);
            return true;
        }
    }
}
