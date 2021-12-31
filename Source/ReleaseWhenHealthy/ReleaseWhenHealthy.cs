using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace ReleaseWhenHealthy
{
    [StaticConstructorOnStartup]
    public static class ReleaseWhenHealthy
    {
        public static readonly PrisonerInteractionModeDef ReleaseWhenHealthyMode;

        static ReleaseWhenHealthy()
        {
            var harmony = new Harmony("Mlie.ReleaseWhenHealthy");

            harmony.PatchAll(Assembly.GetExecutingAssembly());
            ReleaseWhenHealthyMode = DefDatabase<PrisonerInteractionModeDef>.GetNamedSilentFail("ReleaseWhenHealthy");
        }
    }
}