using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HarmonyLib;
using static ActPlan;

[HarmonyPatch]
class CharaListAvailabeFeatsPatch
{
    [HarmonyTranspiler]
    [HarmonyPatch(typeof(Chara), nameof(Chara.ListAvailabeFeats))]
    internal static IEnumerable<CodeInstruction> OnDramaInviteIl(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        return new CodeMatcher(instructions, generator)
            .MatchStartForward(
                new CodeMatch(OpCodes.Ldarg_1),
                new CodeMatch(OpCodes.Brfalse),
                new CodeMatch(OpCodes.Ldloc_3),
                new CodeMatch(OpCodes.Ldstr, "noPet"))
            .CreateLabel(out var label)
            .MatchStartBackwards(
                new CodeMatch(OpCodes.Ldloc_3),
                new CodeMatch(OpCodes.Ldstr, "class"))
            .InsertAndAdvance(
                new CodeInstruction(OpCodes.Br, label))
            .InstructionEnumeration();
    }
}

