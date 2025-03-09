using HarmonyLib;

namespace FartGrenade.Patches
{
    [HarmonyPatch(typeof(ItemGrenadeExplosive), "Start")]
    public class ItemGrenadeExplosivePatch
    {
        [HarmonyPostfix]
        public static void Postfix(ParticleScriptExplosion ___particleScriptExplosion)
        {
            ___particleScriptExplosion.explosionPreset.explosionSoundBig.Sounds = Plugin.SoundFX.ToArray();
            ___particleScriptExplosion.explosionPreset.explosionSoundBigGlobal.Sounds = Plugin.SoundFX.ToArray();
        }
    }
}