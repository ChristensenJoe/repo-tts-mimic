using BepInEx;
using HarmonyLib;
using BepInEx.Logging;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace FartGrenade
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string modGUID = "Eteli.FartGrenade";
        public const string modName = "Fart Grenade";
        public const string modVersion = "0.0.1";

        private static Harmony _harmony;

        internal static new ManualLogSource Log;

        internal static List<AudioClip> SoundFX;
        internal static AssetBundle Bundle;

        public void Awake()
        {
            Log = base.Logger;
            Log.LogInfo($"{modGUID} has awoken!");

            _harmony = new Harmony(modGUID);
            _harmony.PatchAll();


            SoundFX = new List<AudioClip>();

            string FolderLocation = this.Info.Location;
            FolderLocation = FolderLocation.TrimEnd("FartGrenade.dll".ToCharArray());
            Bundle = AssetBundle.LoadFromFile(FolderLocation + "fartgrenade");
            if (Bundle != null)
            {
                SoundFX = Bundle.LoadAllAssets<AudioClip>().ToList();

                Log.LogInfo("Successfully loaded thge asset bundle");

            }
            else
            {
                Log.LogError("Failed to load asset bundle!");
            }
        }
    }
}