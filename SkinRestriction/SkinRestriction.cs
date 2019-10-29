using Rocket.Core.Plugins;
using Rocket.Unturned.Permissions;
using SDG.Unturned;
using Steamworks;
using Logger = Rocket.Core.Logging.Logger;

namespace Tortellio.SkinRestriction
{
    public class SkinRestriction : RocketPlugin<Config>
    {
        public static SkinRestriction Instance;
        protected override void Load()
        {
            Instance = this;
            Logger.Log("SkinRestriction has been loaded!");
            UnturnedPermissions.OnJoinRequested += new UnturnedPermissions.JoinRequested(OnPlayerConnect);
        }

        protected override void Unload()
        {
            Instance = null;
            Logger.Log("SkinRestriction has been unloaded!");
            UnturnedPermissions.OnJoinRequested -= new UnturnedPermissions.JoinRequested(this.OnPlayerConnect);
        }

        public void OnPlayerConnect(CSteamID Player, ref ESteamRejection? Rej)
        {
            foreach (SteamPending Players in Provider.pending)
            {
                bool checkPlayer = Players.playerID.steamID == Player;
                if (checkPlayer)
                {
                    #region SkinType
                    if (Configuration.Instance.AllowItemSkin)
                    {
                        Players.skinItems = new int[0];
                        Players.packageSkins = new ulong[0];
                    }
                    if (Configuration.Instance.AllowHatSkin)
                    {
                        Players.packageHat = 0UL;
                        Players.hatItem = 0;
                    }
                    if (Configuration.Instance.AllowMaskSkin)
                    {
                        Players.maskItem = 0;
                        Players.packageMask = 0UL;
                    }
                    if (Configuration.Instance.AllowGlassesSkin)
                    {
                        Players.packageGlasses = 0UL;
                        Players.glassesItem = 0;
                    }
                    if (Configuration.Instance.AllowShirtSkin)
                    {
                        Players.shirtItem = 0;
                        Players.packageShirt = 0UL;
                    }
                    if (Configuration.Instance.AllowVestSkin)
                    {
                        Players.vestItem = 0;
                        Players.packageVest = 0UL;
                    }
                    if (Configuration.Instance.AllowBackpackSkin)
                    {
                        Players.packageBackpack = 0UL;
                        Players.backpackItem = 0;
                    }
                    if (Configuration.Instance.AllowPantsSkin)
                    {
                        Players.pantsItem = 0;
                        Players.packagePants = 0UL;
                    }
                    #endregion
                }
            }
        }

    }
}
