using Mlie;
using UnityEngine;
using Verse;

namespace ReleaseWhenHealthy
{
    [StaticConstructorOnStartup]
    internal class ReleaseWhenHealthyMod : Mod
    {
        /// <summary>
        ///     The instance of the settings to be read by the mod
        /// </summary>
        public static ReleaseWhenHealthyMod instance;

        private static string currentVersion;

        /// <summary>
        ///     The private settings
        /// </summary>
        private ReleaseWhenHealthySettings settings;

        /// <summary>
        ///     Cunstructor
        /// </summary>
        /// <param name="content"></param>
        public ReleaseWhenHealthyMod(ModContentPack content) : base(content)
        {
            instance = this;
            currentVersion =
                VersionFromManifest.GetVersionFromModMetaData(
                    ModLister.GetActiveModWithIdentifier("Mlie.ReleaseWhenHealthy"));
        }

        /// <summary>
        ///     The instance-settings for the mod
        /// </summary>
        public ReleaseWhenHealthySettings Settings
        {
            get
            {
                if (settings == null)
                {
                    settings = GetSettings<ReleaseWhenHealthySettings>();
                }

                return settings;
            }
            set => settings = value;
        }

        /// <summary>
        ///     The title for the mod-settings
        /// </summary>
        /// <returns></returns>
        public override string SettingsCategory()
        {
            return "Release When Healthy";
        }

        /// <summary>
        ///     The settings-window
        ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
        /// </summary>
        /// <param name="rect"></param>
        public override void DoSettingsWindowContents(Rect rect)
        {
            var listing_Standard = new Listing_Standard();
            listing_Standard.Begin(rect);
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("RWH.defaultaction.label".Translate(),
                ref Settings.AlwaysReleaseWhenHealthy, "RWH.defaultaction.description".Translate());
            if (currentVersion != null)
            {
                GUI.contentColor = Color.gray;
                listing_Standard.Label("RWH.version.label".Translate(currentVersion));
                GUI.contentColor = Color.white;
            }

            listing_Standard.End();
            Settings.Write();
        }
    }
}