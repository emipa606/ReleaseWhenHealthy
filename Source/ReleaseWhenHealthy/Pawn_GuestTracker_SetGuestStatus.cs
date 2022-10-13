using HarmonyLib;
using RimWorld;
using Verse;

namespace ReleaseWhenHealthy;

[HarmonyPatch(typeof(Pawn_GuestTracker), "SetGuestStatus", typeof(Faction), typeof(GuestStatus))]
public static class Pawn_GuestTracker_SetGuestStatus
{
    public static void Postfix(ref GuestStatus guestStatus, ref Pawn_GuestTracker __instance, ref Pawn ___pawn)
    {
        if (guestStatus != GuestStatus.Prisoner ||
            !ReleaseWhenHealthyMod.instance.Settings.AlwaysReleaseWhenHealthy ||
            ___pawn.questTags?.Count > 0)
        {
            return;
        }

        __instance.interactionMode = ReleaseWhenHealthy.ReleaseWhenHealthyMode;
    }
}