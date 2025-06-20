// Decompiled with JetBrains decompiler
// Type: GodArtifactLimitRemove.AddNote_Patch
// Assembly: GodArtifactLimitRemove, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8910B3E3-1BAF-4A03-8C48-E87B84E8104C
// Assembly location: F:\Steam\steamapps\workshop\content\2135150\3364742845\GodArtifactLimitRemove.dll

using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;

#nullable disable
namespace GodArtifactLimitRemove;

[HarmonyPatch(typeof (ElementContainer), "AddNote")]
internal static class AddNote_Patch
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
    return (IEnumerable<CodeInstruction>) codeInstructionList;
  }
}
