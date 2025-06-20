using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using HarmonyLib;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;
using static Gross;

namespace PCEnhance
{
    internal class FeatPatch
    {
        public static void OnStartCore()
        {
            SourceManager sources = Core.Instance.sources;
            foreach (SourceElement.Row row in sources.elements.rows)
            {
                FeatPatch.FeatRewrite(row);
            }
        }
        private static void FeatRewrite(SourceElement.Row ele)
        {
            if (ele.group == "FEAT" && ele.categorySub.IsEmpty())
            {
                ele.categorySub = "special";
            }
            if (ele.group == "FEAT" && ele.alias == "featAdam")
            {
                ele.cost.SetValue(1, 0);
                ele.SetField("max", 10);
            }
            if (ele.group == "FEAT" && ele.alias == "featGrowParts")
            {
                ele.cost.SetValue(1, 0);
            }
            if (ele.group == "FEAT" && ele.alias == "featLonelySoul")
            {
                ele.cost.SetValue(2, 0);
                ele.SetField("max", 999);
            }
        }
    }
}
