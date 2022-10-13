using Verse;

namespace ReleaseWhenHealthy;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class ReleaseWhenHealthySettings : ModSettings
{
    public bool AlwaysReleaseWhenHealthy;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref AlwaysReleaseWhenHealthy, "AlwaysReleaseWhenHealthy");
    }
}