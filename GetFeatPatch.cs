using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using HarmonyLib;

namespace PCEnhance
{
    internal class GetFeatPatch
    {
        public static void GetFeat()
        {
            SourceManager sources = Core.Instance.sources;
            foreach (SourceElement.Row row in sources.elements.rows)
            {
                if (row.group == "FEAT" && row.categorySub.IsEmpty())
                {
                    row.categorySub = "special";
                }
                if (row.group == "FEAT" && row.alias == "featAdam")
                {
                    row.cost.SetValue(1, 0);
                    row.SetField("max", 10);
                }
                if (row.group == "FEAT" && row.alias == "featGrowParts")
                {
                    row.cost.SetValue(1, 0);
                }
                if (row.group == "FEAT" && row.alias == "featLonelySoul")
                {
                    row.cost.SetValue(2, 0);
                    row.SetField("max", 999);
                }
            }
        }
    }
    // 将传入的种族和非宠物特有专长添加至可获取专长
    [HarmonyPatch(typeof(Chara), nameof(Chara.ListAvailabeFeats))]
    internal static class CharaListAvailabeFeatsPatch
    {
        [HarmonyTranspiler]
        // 这是转译器方法，它接收原始的IL指令和一个IL生成器，并返回修改后的IL指令。
        private static IEnumerable<CodeInstruction> OnDramaInviteIl(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
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
    
}
