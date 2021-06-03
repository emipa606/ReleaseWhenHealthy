using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace ReleaseWhenHealthy
{
    [HarmonyPatch(typeof(Pawn_GuestTracker), "GuestTrackerTick")]
    public static class Pawn_GuestTracker_GuestTrackerTick
    {
        public static void Postfix(ref Pawn_GuestTracker __instance)
        {
            if (GenTicks.TicksGame % GenTicks.TickLongInterval != 0)
            {
                return;
            }

            if (__instance.interactionMode != ReleaseWhenHealthy.ReleaseWhenHealthyMode)
            {
                return;
            }

            var bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
                            | BindingFlags.Static;
            var field = typeof(Pawn_GuestTracker).GetField("pawn", bindFlags);

            var currentPawn = (Pawn) field?.GetValue(__instance);
            if (currentPawn == null)
            {
                return;
            }

            if (HealthAIUtility.ShouldSeekMedicalRest(currentPawn))
            {
                return;
            }

            __instance.interactionMode = PrisonerInteractionModeDefOf.Release;
            var text = "RWH.pawnhealthy".Translate(currentPawn.NameFullColored);
            var messageType = MessageTypeDefOf.PositiveEvent;
            var message = new Message(text, messageType, new LookTargets(currentPawn));
            Messages.Message(message);
        }
    }
}