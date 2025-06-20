// Decompiled with JetBrains decompiler
// Type: GodArtifactLimitRemove.GodArtifactLimitRemove
// Assembly: GodArtifactLimitRemove, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8910B3E3-1BAF-4A03-8C48-E87B84E8104C
// Assembly location: F:\Steam\steamapps\workshop\content\2135150\3364742845\GodArtifactLimitRemove.dll

using BepInEx;
using HarmonyLib;

#nullable disable
namespace GodArtifactLimitRemove;

[BepInPlugin("me.chilemiao.plugin.GodArtifactLimitRemove", "GodArtifactLimitRemove", "1.0.1")]
public class GodArtifactLimitRemove : BaseUnityPlugin
{
  private void Awake() => new Harmony(nameof (GodArtifactLimitRemove)).PatchAll();

  public static void Reforge(Thing t, int n)
  {
    foreach (Element element in ((ElementContainer) ((Card) t).elements).dict.Values)
    {
      if (element.id != 66 && element.id != 67 && element.id != 64 /*0x40*/ && element.id != 65 && element.id != 92)
      {
        switch (((Card) t).id)
        {
          case "blunt_earth":
            if (element.id == 70 || element.id == 55 || element.id == 56 || element.id == 954 || element.id == 423 || element.id == 421)
              element.vExp = n;
            ((Card) t).c_idDeity = ((Religion) EClass.game.religions.Earth).id;
            continue;
          case "cloak_mani":
            if (element.id == 427 || element.id == 957 || element.id == 105 || element.id == 466 || element.id == 664)
              element.vExp = n;
            ((Card) t).c_idDeity = ((Religion) EClass.game.religions.Machine).id;
            continue;
          case "gun_mani":
            ((Card) t).c_idDeity = ((Religion) EClass.game.religions.Machine).id;
            continue;
          case "kogitsunemaru":
            if (element.id != 656)
              element.vExp = n;
            ((Card) t).c_idDeity = ((Religion) EClass.game.religions.Trickery).id;
            continue;
          case "luckydagger":
            if (element.id != 426)
              element.vExp = n;
            ((Card) t).c_idDeity = ((Religion) EClass.game.religions.Luck).id;
            continue;
          case "pole_holy":
            if (element.id == 60 || element.id == 461 || element.id == 423)
              element.vExp = n;
            ((Card) t).c_idDeity = ((Religion) EClass.game.religions.Healing).id;
            continue;
          case "scythe_kumi":
            if (element.id == 6650 || element.id == 480 || element.id == 959 || element.id == 428 || element.id == 640 || element.id == 665)
              element.vExp = n;
            ((Card) t).c_idDeity = ((Religion) EClass.game.religions.Harvest).id;
            continue;
          case "shirt_wind":
            if (!(element is Resistance) && element.id != 226 && element.id != 152 && element.id != 77)
              element.vExp = n;
            ((Card) t).c_idDeity = ((Religion) EClass.game.religions.Wind).id;
            continue;
          case "staff_element":
            if (element.id == 411 || element is Resistance && element.id != 959)
              element.vExp = n;
            ((Card) t).c_idDeity = ((Religion) EClass.game.religions.Element).id;
            continue;
          case "sword_muramasa2":
            if (element.id == 401 || element.id == 916 || element.id == 661)
              element.vExp = n;
            ((Card) t).c_idDeity = ((Religion) EClass.game.religions.MoonShadow).id;
            continue;
          case "warmonger":
            if (element.id == 423 || element.id == 463 || element.id == 460 || element.id == 464 || element.id == 465)
              element.vExp = n;
            ((Card) t).c_idDeity = ((Religion) EClass.game.religions.Strife).id;
            continue;
          case "windbow":
            ((Card) t).c_idDeity = ((Religion) EClass.game.religions.Wind).id;
            continue;
          default:
            continue;
        }
      }
    }
  }
}
