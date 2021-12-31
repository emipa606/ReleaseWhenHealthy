using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace ConvertThenRecruit;

[StaticConstructorOnStartup]
public static class ConvertThenRecruit
{
    public static readonly PrisonerInteractionModeDef ConvertThenRecruitMode;

    static ConvertThenRecruit()
    {
        var harmony = new Harmony("Mlie.ConvertThenRecruit");

        harmony.PatchAll(Assembly.GetExecutingAssembly());
        ConvertThenRecruitMode = DefDatabase<PrisonerInteractionModeDef>.GetNamedSilentFail("ConvertThenRecruit");
    }
}