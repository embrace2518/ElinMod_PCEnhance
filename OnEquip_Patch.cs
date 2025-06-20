// Decompiled with JetBrains decompiler
// Type: GodArtifactLimitRemove.OnEquip_Patch
// Assembly: GodArtifactLimitRemove, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8910B3E3-1BAF-4A03-8C48-E87B84E8104C
// Assembly location: F:\Steam\steamapps\workshop\content\2135150\3364742845\GodArtifactLimitRemove.dll

using HarmonyLib;
using System;

#nullable disable
namespace GodArtifactLimitRemove;

[HarmonyPatch(typeof (ElementContainerFaction), "OnEquip", new Type[] {typeof (Thing)})]
internal static class OnEquip_Patch
{
  public static bool Prefixed;

  [HarmonyPrefix]
  public static bool Prefix(Thing t)
  {
    if (((Card) t).HasTag((CTAG) 29))
      GodArtifactLimitRemove.GodArtifactLimitRemove.Reforge(t, -1);
    return true;
  }

  [HarmonyPostfix]
  public static void Postfix(Thing t)
  {
    if (!OnEquip_Patch.Prefixed || !((Card) t).HasTag((CTAG) 29))
      return;
    GodArtifactLimitRemove.GodArtifactLimitRemove.Reforge(t, 0);
  }
}
