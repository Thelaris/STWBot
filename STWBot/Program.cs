using System;
using System.Collections.Generic;
using System.Linq;


namespace STWBot
{

	public static class stwb
	{
		//public static Discord.DiscordClient bot = new Discord.DiscordClient();
		public static ChannelEvents ce = new ChannelEvents();
		public static ServerEvents s = new ServerEvents();
		public static InputCommands ic = new InputCommands();
		public static UserEvents ue = new UserEvents();
		public static MessageEvents me = new MessageEvents();



	}

	class MainClass
	{
		public static void Main(string[] args)
		{
			var bot = new Discord.DiscordClient();

			string token = "MzA1OTc1MTg4NTA2NDExMDA4.C9-UcA.zgPoklYWBun9_Mxr9j0WSnduL-I";

			//Events

			/* --CHANNEL EVENTS-- */
			//stwb.bot.ChannelCreated;
			//stwb.bot.ChannelDestroyed;
			//stwb.bot.ChannelUpdated;

			/* --MESSAGE EVENTS-- */
			//stwb.bot.MessageDeleted;
			bot.MessageReceived += stwb.me.bot_MessageReceived;
			//stwb.bot.MessageUpdated;

			/* --ROLE EVENTS-- */
			//stwb.bot.RoleCreated;
			//stwb.bot.RoleDeleted;
			//stwb.bot.RoleUpdated;

			/* --SERVER EVENTS-- */
			//stwb.bot.JoinedServer;
			//stwb.bot.LeftServer;
			//stwb.bot.Ready;
			//stwb.bot.ServerAvailable;
			//stwb.bot.ServerUnavailable;
			//stwb.bot.ServerUpdated;

			/* --USER EVENTS-- */
			//stwb.bot.ProfileUpdated;
			//stwb.bot.UserBanned;
			//stwb.bot.UserIsTyping;
			bot.UserJoined += stwb.ue.bot_UserJoined;
			//stwb.bot.UserLeft;
			//stwb.bot.UserUnbanned;
			bot.UserUpdated += stwb.ue.bot_UserUpdated;


			// Connect to Discord
			bot.ExecuteAndWait(async () =>
			{
				await bot.Connect(token, Discord.TokenType.Bot);

			});

		}







	}
}