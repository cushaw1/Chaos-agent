using Smod2;
using Smod2.Attributes;
using Chaos_agent_plugin;

namespace Chaos_agent
{
    [PluginDetails(
    author = "cushaw",
    name = "Chaos_agent",
    description = "One Classe-D became Chaos agent when game start",
    id = "cushaw.chaos_agent",
    version = "1.0.3",
    SmodMajor = 3,
    SmodMinor = 1,
    SmodRevision = 12
    )]
    class Chaos_agent : Plugin
    {
        public override void OnDisable()
        {
            this.Info("Chaos agent not load");
        }

        public override void OnEnable()
        {
            this.Info("Chaos agent loaded successfully");
        }

        public override void Register()
        {
            this.AddEventHandlers(new EventHandler(this));
            this.AddConfig(new Smod2.Config.ConfigSetting("chaos_agent_enable", true, Smod2.Config.SettingType.BOOL, true, "open Chaos agent plugin"));
            this.AddConfig(new Smod2.Config.ConfigSetting("chaos_agent_classd", new int { }, Smod2.Config.SettingType.NUMERIC, true, "Chaos agent will present at least Classe-D players number"));
            this.AddConfig(new Smod2.Config.ConfigSetting("chaos_agent_player", new int { }, Smod2.Config.SettingType.NUMERIC, true, "Chaos agent will present at least all players number"));
            this.AddConfig(new Smod2.Config.ConfigSetting("chaos_agent_health", new int { }, Smod2.Config.SettingType.NUMERIC, true, "Chaos agent HP"));
            this.AddConfig(new Smod2.Config.ConfigSetting("chaos_agent_item", new int[] { 0, 27 }, Smod2.Config.SettingType.NUMERIC_LIST, true, "Chaos agent birth item"));
            this.AddConfig(new Smod2.Config.ConfigSetting("chaos_agent_reward", new int[] { 16, 25 }, Smod2.Config.SettingType.NUMERIC_LIST, true, "Chaos agent escaped reward item"));
        }
    }
}
