using Rocket.API;
using Rocket.Core.Plugins;
using Rocket.Unturned.Permissions;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using Logger = Rocket.Core.Logging.Logger;

namespace Tortellio.SkinRestriction
{
    public class SkinRestriction : RocketPlugin<Config>
    {
        public static SkinRestriction Instance;
        public static string PluginName = "SkinRestriction";
        public static string PluginVersion = "1.0.0";
        protected override void Load()
        {
            Instance = this;
            Logger.Log("SkinRestriction has been loaded!");
            Logger.Log(PluginName + PluginVersion, ConsoleColor.Yellow);
            Logger.Log("Made by Tortellio", ConsoleColor.Yellow);
            UnturnedPermissions.OnJoinRequested += new UnturnedPermissions.JoinRequested(OnPlayerConnect);
        }

        protected override void Unload()
        {
            Instance = null;
            Logger.Log("SkinRestriction has been unloaded!");
            Logger.Log("Visit Tortellio Discord for more! https://discord.gg/pzQwsew");
            UnturnedPermissions.OnJoinRequested -= new UnturnedPermissions.JoinRequested(this.OnPlayerConnect);
        }

        public void OnPlayerConnect(CSteamID Player, ref ESteamRejection? Rej)
        {
            foreach (SteamPending Players in Provider.pending)
            {
                bool checkPlayer = Players.playerID.steamID == Player;
                if (checkPlayer)
                {
                    UnturnedPlayer uPlayer = UnturnedPlayer.FromCSteamID(Player);
                    bool CheckBypass = (Configuration.Instance.IgnoreAdmins && uPlayer.IsAdmin) || uPlayer.HasPermission(Configuration.Instance.IgnorePermission); ;
                    if (CheckBypass) { return; }
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
