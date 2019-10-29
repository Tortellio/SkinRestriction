using Rocket.API;

namespace Tortellio.SkinRestriction
{
    public class Config : IRocketPluginConfiguration
    {
        public bool IgnoreAdmins;
        public bool AllowItemSkin;
        public bool AllowHatSkin;
        public bool AllowMaskSkin;
        public bool AllowGlassesSkin;
        public bool AllowBackpackSkin;
        public bool AllowShirtSkin;
        public bool AllowVestSkin;
        public bool AllowPantsSkin;
        public void LoadDefaults()
        {
            IgnoreAdmins = true;
            AllowItemSkin = true;
            AllowHatSkin = true;
            AllowMaskSkin = true;
            AllowGlassesSkin = true;
            AllowBackpackSkin = true;
            AllowShirtSkin = true;
            AllowVestSkin = true;
            AllowPantsSkin = true;
        }
    }
}