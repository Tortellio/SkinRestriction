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
            AllowItemSkin = false;
            AllowHatSkin = false;
            AllowMaskSkin = false;
            AllowGlassesSkin = false;
            AllowBackpackSkin = false;
            AllowShirtSkin = false;
            AllowVestSkin = false;
            AllowPantsSkin = false;
        }
    }
}