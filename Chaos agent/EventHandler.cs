using Smod2;
using Smod2.Events;
using Smod2.API;
using Smod2.EventHandlers;
using System.Collections.Generic;


namespace Chaos_agent_plugin
{
    class EventHandler : IEventHandlerRoundStart, IEventHandlerRoundEnd, IEventHandlerPlayerDie, IEventHandlerSetRole
    {
        private Plugin plugin;
        public Player Chaos;
        private List<Player> players;
        public int heal = 200;
        public int[] item = { 0, 27 };
        public int[] reward = { 16, 25 };
        private int minimum_chaos = 3;
        private int minimum_players = 10;
        private bool enabled = true;

        public EventHandler(Plugin plugin)
        {
            this.plugin = plugin;
            players = new List<Player>();
        }
        public void OnRoundStart(RoundStartEvent ev)
        {
            players = ev.Server.GetPlayers();
            enabled = plugin.GetConfigBool("chaos_agent_enable");
            if (enabled == true)
            {
                heal = plugin.GetConfigInt("chaos_agent_health");
                minimum_chaos = plugin.GetConfigInt("chaos_agent_classd");
                minimum_players = plugin.GetConfigInt("chaos_agent_player");
                List<Player> list = new List<Player>();
                if (players.Count == 0 || players.Count < minimum_players) plugin.Info("Not enough players to chaos agent");
                else
                {
                    foreach (Player p in players)
                    {
                        if (p.TeamRole.Role == Role.CLASSD) list.Add(p);
                    }
                    if (list.Count < minimum_chaos) plugin.Info("Not enough ClassD to chaos agent");
                    else
                    {
                        int index = UnityEngine.Random.Range(0, list.Count);
                        Chaos = list[index];
                        plugin.Info(Chaos.Name + " is chaos agent.");
                        Chaos.SetHealth(heal, DamageType.NONE);
                        int[] item = plugin.GetConfigIntList("chaos_agent_item");
                        foreach (int id in item)
                        {
                            Chaos.GiveItem((ItemType)id);
                        }
                    }
                }
                list.Clear();
            }
         }
        public void OnRoundEnd(RoundEndEvent ev)
        {
                if (enabled == true)
                {
                    players.Clear();
                    Chaos = null;
                }
        }
        public void OnPlayerDie(PlayerDeathEvent ev)
        {
            if (enabled == true)
            {
                if (ev.Player.SteamId == Chaos.SteamId) Chaos = null;
                players.Clear();
            }
        }
        public void OnSetRole(PlayerSetRoleEvent ev)
        {
            if (enabled == true)
            {
                if (ev.Player.SteamId == Chaos.SteamId && ev.TeamRole.Role == Role.CHAOS_INSUGENCY)
                {
                    int[] reward = plugin.GetConfigIntList("chaos_agent_reward");
                    foreach (int id in reward)
                    {
                        Chaos.GiveItem((ItemType)id);
                    }
                    Chaos.SetHealth(heal, DamageType.NONE);
                    players.Clear();
                    Chaos = null;
                }
            }
        }
    }
}