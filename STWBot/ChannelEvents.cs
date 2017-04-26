using System;
using System.Linq;

namespace STWBot
{
	public class ChannelEvents
	{
		public ChannelEvents()
		{
		}

		static public void bot_ChannelCreated(object channel, Discord.ChannelEventArgs e)
		{
			if (stwb.logCreatedChan == true)
			{
				e.Server.FindChannels(stwb.logChanName).First().SendMessage("```" + DateTime.Now.ToString("G") + "\n" + "- Created new " + e.Channel.Type + " channel: " + e.Channel.Name + "```" + stwb.logLineBreak);
			}
		}

		static public void bot_ChannelDestroyed(object channel, Discord.ChannelEventArgs e)
		{
			if (stwb.logDestroyedChan == true)
			{
				e.Server.FindChannels(stwb.logChanName).First().SendMessage("```" + DateTime.Now.ToString("G") + "\n" + "- Deleted " + e.Channel.Type + " channel: " + e.Channel.Name + "```" + stwb.logLineBreak);
			}
		}

		static public void bot_ChannelUpdated(object channel, Discord.ChannelUpdatedEventArgs e)
		{
			if (stwb.logDestroyedChan == true)
			{
				 e.Server.FindChannels(stwb.logChanName).First().SendMessage("```" + DateTime.Now.ToString("G") + "\n" + "- " + e.After.Type + " channel: " + e.After.Name + " has been updated```" + stwb.logLineBreak);
			}
		}
	}
}
