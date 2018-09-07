# Chaos-agent
# What is it?
Sorry for my english..

This is a plugin for SCP: Secret Laboratory, thanks Squalalah his scp181 gave me inspiration.
# Plugin content
One Class-D will became Chaos agent when the game start. 
The agent looks like a Class-D, but he has more health and items.
When the Chaos Agent escapes, the Chaos Insurgency will reward the agent, he will become a Chaos Insurgent with more HP and items.
# How do I use it?
Download the dll from https://github.com/cushaw1/Chaos-agent/releases/tag/1.0.3 
Put it in the folder titled sm_plugins.
You should set `online_mode: true` ,because it uses steamID
>PS: Some small grammar errors i dont know how to fix
# Config Options
Config Option | Value Type | Default Value | Description
--- | :---: | :---: | ---
chaos_agent_enable | Boolean | True | Chaos agent plugin enable/disable
chaos_agent_classd | Integer | 3 | Chaos Agent will present at least Class-D players number
chaos_agent_player | Integer | 10 | Chaos Agent will present at least all players number
chaos_agent_health | Integer | 200 | Chaos Agent HP
chaos_agent_item   | List | 0, 27 | Chaos Agent item in game start item(s)
chaos_agent_reward | List | 16, 25 | Chaos Agent escaped reward item(s)
