using System;
using System.Linq;

namespace STWBot
{
	public class MessageEvents
	{
		public MessageEvents()
		{
		}

		static public void bot_MessageDeleted(object user, Discord.MessageEventArgs e)
		{
			e.Server.FindChannels(stwb.logChanName).First().SendMessage("```" + DateTime.Now.ToString("G") + "\n" + "- Deleted message in text channel: " + e.Message.Channel.Name + ". Message ID: " + e.Message.Id + "```" + stwb.logLineBreak);
		}

		static public void bot_MessageReceived(object sender, Discord.MessageEventArgs e)
		{
			if (e.Message.RawText.StartsWith("testing"))
			{
				//e.Channel.SendMessage(e.User.Mention + "Your reply");
			}
			else if (e.Message.RawText.StartsWith("tester"))
			{
				//e.User.SendMessage("Direct Messaging");
			}

		}

		static public void bot_MessageUpdated(object user, Discord.MessageUpdatedEventArgs e)
		{
			e.Server.FindChannels(stwb.logChanName).First().SendMessage("```" + DateTime.Now.ToString("G") + "\n" + "- Updated message in text channel: " + e.After.Channel.Name + ". Message ID: " + e.After.Id + "```" + stwb.logLineBreak);
		}

	}
}
