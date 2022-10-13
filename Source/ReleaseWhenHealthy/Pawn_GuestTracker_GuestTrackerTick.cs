using HarmonyLib;
using RimWorld;
using Verse;

namespace ReleaseWhenHealthy;

[HarmonyPatch(typeof(Pawn_GuestTracker), "GuestTrackerTick")]
public static class Pawn_GuestTracker_GuestTrackerTick
{
    public static void Postfix(ref Pawn_GuestTracker __instance, ref Pawn ___pawn)
    {
        if (GenTicks.TicksGame % GenTicks.TickLongInterval != 0)
        {
            return;
        }

        if (__instance.interactionMode != ReleaseWhenHealthy.ReleaseWhenHealthyMode)
        {
            return;
        }

        if (___pawn == null)
        {
            return;
        }

        if (HealthAIUtility.ShouldSeekMedicalRest(___pawn))
        {
            return;
        }

        __instance.interactionMode = PrisonerInteractionModeDefOf.Release;
        var text = "RWH.pawnhealthy".Translate(___pawn.NameFullColored);
        var messageType = MessageTypeDefOf.PositiveEvent;
        var message = new Message(text, messageType, new LookTargets(___pawn));
        Messages.Message(message);
    }
}