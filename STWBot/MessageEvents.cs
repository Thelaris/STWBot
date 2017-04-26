using System;
namespace STWBot
{
	public class MessageEvents
	{
		public MessageEvents()
		{
		}

		public void bot_MessageReceived(object sender, Discord.MessageEventArgs e)
		{
			if (e.Message.RawText.StartsWith("testing"))
			{
				e.Channel.SendMessage(e.User.Mention + "Your reply");
			}
			else if (e.Message.RawText.StartsWith("tester"))
			{
				e.User.SendMessage("Direct Messaging");
			}

		}
	}
}
