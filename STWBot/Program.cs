using System;
using System.Collections.Generic;
using System.Linq;


namespace STWBot
{

	public static class stwb
	{
		//public static Discord.DiscordClient bot = new Discord.DiscordClient();
		//public static ChannelEvents ce = new ChannelEvents();
		//public static ServerEvents se = new ServerEvents();
		//public static InputCommands ic = new InputCommands();
		//public static UserEvents ue = new UserEvents();
		//public static MessageEvents me = new MessageEvents();




		public static string logChanName = "server-log";
		public static string logLineBreak = "---------------------";

		public static string announcementsChanName = "announcements";


		public static bool logCreatedChan = true;
		public static bool logDestroyedChan = true;
		public static bool logUpdatedChan = true;



	}

	class MainClass
	{
		public static Token tokenRef = new Token();
		
		public static void Main(string[] args)
		{
			var bot = new Discord.DiscordClient();

			string token = tokenRef.token;

			//Events

			/* --CHANNEL EVENTS-- */
			bot.ChannelCreated += ChannelEvents.bot_ChannelCreated;
			bot.ChannelDestroyed += ChannelEvents.bot_ChannelDestroyed;
			bot.ChannelUpdated += ChannelEvents.bot_ChannelUpdated;

			/* --MESSAGE EVENTS-- */
			bot.MessageDeleted += MessageEvents.bot_MessageDeleted;
			bot.MessageReceived += MessageEvents.bot_MessageReceived;
			bot.MessageUpdated += MessageEvents.bot_MessageUpdated;

			/* --ROLE EVENTS-- */
			bot.RoleCreated += RoleEvents.bot_RoleCreated;
			bot.RoleDeleted += RoleEvents.bot_RoleDeleted;
			bot.RoleUpdated += RoleEvents.bot_RoleUpdated;

			/* --SERVER EVENTS-- */
			//stwb.bot.JoinedServer;
			//stwb.bot.LeftServer;
			//stwb.bot.Ready;
			//stwb.bot.ServerAvailable;
			//stwb.bot.ServerUnavailable;
			//stwb.bot.ServerUpdated;

			/* --USER EVENTS-- */
			//stwb.bot.ProfileUpdated;
			bot.UserBanned += UserEvents.bot_UserBanned;
			//stwb.bot.UserIsTyping;
			bot.UserJoined += UserEvents.bot_UserJoined;
			bot.UserLeft += UserEvents.bot_UserLeft;
			bot.UserUnbanned += UserEvents.bot_UserUnbanned;
			bot.UserUpdated += UserEvents.bot_UserUpdated;


			// Connect to Discord
			bot.ExecuteAndWait(async () =>
			{
				await bot.Connect(token, Discord.TokenType.Bot);

			});

		}







	}
}