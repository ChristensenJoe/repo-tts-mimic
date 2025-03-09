using HarmonyLib;
using System;
using System.IO;

namespace TTSMimic.Patches
{
    [HarmonyPatch(typeof(RunManager))]
    public class RunManagerPatch
    {
        [HarmonyPatch("OnApplicationQuit")]
        [HarmonyPostfix]
        public static void Postfix()
        {
            File.WriteAllText(Plugin.TextFileLocation, String.Empty);
        }
    }

    [HarmonyPatch(typeof(PlayerAvatar))]
    public class PlayerAvatarPatch
    {
        [HarmonyPatch("ChatMessageSend")]
        [HarmonyPostfix]
        public static void Postfix(string _message)
        {
            File.AppendAllText(Plugin.TextFileLocation, _message + Environment.NewLine);
        }
    }
}