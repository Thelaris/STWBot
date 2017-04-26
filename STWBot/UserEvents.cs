using System;
using System.Collections.Generic;
using System.Linq;

namespace STWBot
{
	public class UserEvents
	{
		//static public string lineBreakStart = "---------------------\n";
		//static public string lineBreakEnd = "---------------------"; --now being used as global in stwb

		public UserEvents()
		{
		}

		static public void bot_UserBanned(object user, Discord.UserEventArgs e)
		{
			e.Server.FindChannels(stwb.logChanName).First().SendMessage(e.User.Mention + "\n```" + DateTime.Now.ToString("G") + "\n" + "- Above mentioned user has been BANNED from the " + e.Server.Name + " Discord server. User ID: " + e.User.Id + "```" + stwb.logLineBreak);
		}

		static public void bot_UserUnbanned(object user, Discord.UserEventArgs e)
		{
			e.Server.FindChannels(stwb.logChanName).First().SendMessage(e.User.Mention + "\n```" + DateTime.Now.ToString("G") + "\n" + "- Above mentioned user has been UNBANNED from the " + e.Server.Name + " Discord server. User ID: " + e.User.Id + "```" + stwb.logLineBreak);
		}

		static public void bot_UserLeft(object user, Discord.UserEventArgs e)
		{
			e.Server.FindChannels(stwb.logChanName).First().SendMessage(e.User.Mention + "\n```" + DateTime.Now.ToString("G") + "\n" + "- Above mentioned user has left the " + e.Server.Name + " Discord server. User ID: " + e.User.Id + "```" + stwb.logLineBreak);
		}

		static public void bot_UserJoined(object user, Discord.UserEventArgs e)
		{
			System.Threading.Thread.Sleep(3000);

			if (e.User.Roles.Count() < 2)
			{
				Discord.Role membersRole = e.Server.FindRoles("MEMBERS").FirstOrDefault();

				e.User.AddRoles(membersRole);
			}

			//e.Server.FindChannels(stwb.logChanName).First().SendMessage("```" + DateTime.Now.ToString("G") + "\n" + "- New user: @" + e.User.Name + " has joined the server. User ID: " + e.User.Id + "```");
			//Discord.Message message = e.Server.FindChannels(stwb.logChanName).First().SendMessage(e.User.Mention).Result;
			//string username = e.User.Id.ToString();
			e.Server.FindChannels(stwb.logChanName).First().SendMessage(e.User.Mention + "\n```" + DateTime.Now.ToString("G") + "\n" + "- Above mentioned user has JOINED the " + e.Server.Name + " Discord server. User ID: " + e.User.Id + "```" + stwb.logLineBreak);
		}

		static public void bot_UserUpdated(object user, Discord.UserUpdatedEventArgs e)
		{
			string usertype = "";
			if (e.After.Roles.Count() < 2)
			{
				SetRoleIfPug(user, e);
			}
			if (usertype != "" && usertype != "0" && usertype != "1")
			{
				e.Server.FindChannels("use-bots-here").FirstOrDefault().SendMessage(usertype);
			}
			//e.Server.FindChannels(stwb.logChanName).First().SendMessage(e.After.Mention);
			e.Server.FindChannels(stwb.logChanName).First().SendMessage(e.After.Mention + "\n```" + DateTime.Now.ToString("G") + "\n" + "- Above mentioned user has had their status updated. User ID: " + e.After.Id + "```" + stwb.logLineBreak);
		}

		static void SetRoleIfPug(object user, Discord.UserUpdatedEventArgs e)
		{
			//Discord.Role everyoneRole = e.Server.FindRoles("@everyone").FirstOrDefault();
			if (e.After.Roles.Count() > 1) return;

			Discord.Channel chan = e.Server.FindChannels("__").FirstOrDefault();
			Discord.Channel mainChannel = e.Server.FindChannels("██ SUM TING WONG￬").FirstOrDefault();
			//string userType = "1";
			if (e.After.VoiceChannel == null) return;
			if (e.After.VoiceChannel == chan)
			{

				Discord.Role pugsRole = e.Server.FindRoles("PUGS").FirstOrDefault();

				//e.After.AddRoles(pugsRole);

				//System.Threading.Thread.Sleep(1000);

				//e.Server.FindRoles("PUGS").FirstOrDefault();

				List<Discord.Role> roles = new List<Discord.Role>(new Discord.Role[] { e.Server.FindRoles("PUGS").FirstOrDefault() });

				e.After.Edit(voiceChannel: mainChannel, roles: roles);

				//userType = "PUG";
				return;
			}
			else
			{
				Discord.Role membersRole = e.Server.FindRoles("MEMBERS").FirstOrDefault();

				e.After.AddRoles(membersRole);
			}

			return;
		}
	}
}
