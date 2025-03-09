using BepInEx;
using HarmonyLib;
using BepInEx.Logging;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

namespace TTSMimic
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string modGUID = "Eteli.TTSMimic";
        public const string modName = "TTS Mimic";
        public const string modVersion = "0.0.1";

        private static Harmony _harmony;

        internal static new ManualLogSource Log;

        internal static string TextFileLocation;

        public void Awake()
        {
            Log = base.Logger;
            Log.LogInfo($"{modGUID} has awoken!");

            _harmony = new Harmony(modGUID);
            _harmony.PatchAll();

            TextFileLocation = this.Info.Location;
            TextFileLocation = TextFileLocation.TrimEnd("TTSMimic.dll".ToCharArray());
            TextFileLocation += "/TTSMimic.txt";

            File.AppendAllText(TextFileLocation, "TTSMimic has started!" + Environment.NewLine);
        }
    }
}