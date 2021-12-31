﻿using HarmonyLib;
using RimWorld;
using Verse;

namespace ConvertThenRecruit;

[HarmonyPatch(typeof(Pawn_IdeoTracker), "IdeoConversionAttempt")]
public static class Pawn_IdeoTracker_IdeoConversionAttempt
{
    public static void Postfix(bool __result, Pawn ___pawn)
    {
        if (!__result)
        {
            return;
        }

        if (___pawn.guest.interactionMode != ConvertThenRecruit.ConvertThenRecruitMode)
        {
            return;
        }

        ___pawn.guest.interactionMode = PrisonerInteractionModeDefOf.AttemptRecruit;
        var text = "CTR.pawnconverted".Translate(___pawn.NameFullColored);
        var messageType = MessageTypeDefOf.PositiveEvent;
        var message = new Message(text, messageType, new LookTargets(___pawn));
        Messages.Message(message);
    }
}