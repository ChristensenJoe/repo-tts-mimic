using HarmonyLib;

namespace FartMine.Patches
{
    //[HarmonyPatch(typeof(ParticleScriptExplosion), "Spawn")]
    //public class ParticleScriptExplosionPatch
    //{
    //    public static void Prefix(ParticleScriptExplosion __instance)
    //    {

    //    }
    //}

    //[HarmonyPatch(typeof(ItemMineExplosive), "OnTriggered")]
    //public class ItemMineExplosivePatch
    //{
    //    [HarmonyPrefix]
    //    public static bool Prefix(ItemMineExplosive __instance, ParticleScriptExplosion ___particleScriptExplosion)
    //    {
    //        Plugin.Log.LogInfo("Mine triggered! :)");
    //        Plugin.Log.LogInfo($"Position: {__instance.transform.position}");

    //        ___particleScriptExplosion.Spawn(__instance.transform.position, 1.2f, 75, 200, 4f, false, true, 1f);
    //        return false;
    //    }
    //}

    [HarmonyPatch(typeof(ItemMineExplosive), "Start")]
    public class ItemMineExplosivePatch
    {
        [HarmonyPostfix]
        public static void Postfix(ItemMineExplosive __instance, ParticleScriptExplosion ___particleScriptExplosion)
        {
            Plugin.Log.LogInfo("Mine triggered! :)");
            Plugin.Log.LogInfo($"Position: {__instance.transform.position}");

            ___particleScriptExplosion.explosionPreset.explosionSoundBig.Sounds = Plugin.SoundFX.ToArray();
            ___particleScriptExplosion.explosionPreset.explosionSoundBigGlobal.Sounds = Plugin.SoundFX.ToArray();
        }
    }
}