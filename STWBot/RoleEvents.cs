using System;
using System.Linq;

namespace STWBot
{
	public class RoleEvents
	{
		public RoleEvents()
		{
		}

		static public void bot_RoleCreated(object user, Discord.RoleEventArgs e)
		{
			e.Server.FindChannels(stwb.logChanName).First().SendMessage("```" + DateTime.Now.ToString("G") + "\n" + "- New role created: " + e.Role.Name + ". Role ID: " + e.Role.Id + "```" + stwb.logLineBreak);
		}

		static public void bot_RoleDeleted(object user, Discord.RoleEventArgs e)
		{
			e.Server.FindChannels(stwb.logChanName).First().SendMessage("```" + DateTime.Now.ToString("G") + "\n" + "- Deleted role \"" + e.Role.Name + "\". Role ID: " + e.Role.Id + "```" + stwb.logLineBreak);
		}

		static public void bot_RoleUpdated(object user, Discord.RoleUpdatedEventArgs e)
		{
			e.Server.FindChannels(stwb.logChanName).First().SendMessage("```" + DateTime.Now.ToString("G") + "\n" + "- Updated the role \"" + e.After.Name + "\". Role ID: " + e.After.Id + "```" + stwb.logLineBreak);
		}
	}
}
