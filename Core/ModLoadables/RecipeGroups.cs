using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Illuminum.Core.ModLoadables {
    public static class RecipeGroups {
        public const string EVILBAR = "Illuminum:EvilBar";
        public const string EVILMAT = "Illuminum:EvilMaterial";
        internal static void Load() {
            RecipeGroup EvilBar = new RecipeGroup(() => Lang.misc[37] + " Evil Bar", new int[]
            {
                ItemID.DemoniteBar,
                ItemID.CrimtaneBar
            });
            RecipeGroup.RegisterGroup(EVILBAR, EvilBar);

            RecipeGroup EvilMaterial = new RecipeGroup(() => Lang.misc[37] + " Evil Material", new int[]
            {
                ItemID.ShadowScale,
                ItemID.TissueSample
            });
            RecipeGroup.RegisterGroup(EVILMAT, EvilMaterial);
        }
    }
}
