using HarmonyLib;
using RimWorld;
using Verse;

namespace ReleaseWhenHealthy
{
    [HarmonyPatch(typeof(Pawn_GuestTracker), "SetGuestStatus", typeof(Faction), typeof(bool))]
    public static class Pawn_GuestTracker_SetGuestStatus
    {
        public static void Postfix(ref bool prisoner, ref Pawn_GuestTracker __instance, ref Pawn ___pawn)
        {
            if (!prisoner || !ReleaseWhenHealthyMod.instance.Settings.AlwaysReleaseWhenHealthy ||
                ___pawn.questTags?.Count > 0)
            {
                return;
            }

            __instance.interactionMode = ReleaseWhenHealthy.ReleaseWhenHealthyMode;
        }
    }
}