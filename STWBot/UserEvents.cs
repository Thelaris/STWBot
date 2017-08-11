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
			e.Server.FindChannels(stwb.announcementsChanName).First().SendMessage(e.User.Mention + " has been BANNED from the " + e.Server.Name + " Discord server - The Ban Hammer is in full swing.\nThis user cannot be invited back to this server!");
		}

		static public void bot_UserUnbanned(object user, Discord.UserEventArgs e)
		{
			e.Server.FindChannels(stwb.logChanName).First().SendMessage(e.User.Mention + "\n```" + DateTime.Now.ToString("G") + "\n" + "- Above mentioned user has been UNBANNED from the " + e.Server.Name + " Discord server. User ID: " + e.User.Id + "```" + stwb.logLineBreak);
			e.Server.FindChannels(stwb.announcementsChanName).First().SendMessage(e.User.Mention + " has been UNBANNED from the " + e.Server.Name + " Discord server - Welcome back!\nRemember, second chances do not come lightly...");
		}

		static public void bot_UserLeft(object user, Discord.UserEventArgs e)
		{
			e.Server.FindChannels(stwb.logChanName).First().SendMessage(e.User.Mention + "\n```" + DateTime.Now.ToString("G") + "\n" + "- Above mentioned user has LEFT the " + e.Server.Name + " Discord server. User ID: " + e.User.Id + "```" + stwb.logLineBreak);
			e.Server.FindChannels(stwb.announcementsChanName).First().SendMessage(e.User.Mention + " has LEFT the " + e.Server.Name + " Discord server - We are sorry to see you leave :(");
		}

		static public void bot_UserJoined(object user, Discord.UserEventArgs e)
		{
			System.Threading.Thread.Sleep(1000);

			/* Conflicting
			if (e.User.Roles.Count() < 2)
			{
				Discord.Role membersRole = e.Server.FindRoles("MEMBERS").FirstOrDefault();

				e.User.AddRoles(membersRole);
			}
			*/

			//e.Server.FindChannels(stwb.logChanName).First().SendMessage("```" + DateTime.Now.ToString("G") + "\n" + "- New user: @" + e.User.Name + " has joined the server. User ID: " + e.User.Id + "```");
			//Discord.Message message = e.Server.FindChannels(stwb.logChanName).First().SendMessage(e.User.Mention).Result;
			//string username = e.User.Id.ToString();
			e.Server.FindChannels(stwb.logChanName).First().SendMessage(e.User.Mention + "\n```" + DateTime.Now.ToString("G") + "\n" + "- Above mentioned user has JOINED the " + e.Server.Name + " Discord server. User ID: " + e.User.Id + "```" + stwb.logLineBreak);
			e.Server.FindChannels(stwb.announcementsChanName).First().SendMessage(e.User.Mention + " has JOINED the " + e.Server.Name + " Discord server - Welcome!");
		}

		static public void bot_UserUpdated(object user, Discord.UserUpdatedEventArgs e)
		{
			string usertype = "";
			System.Threading.Thread.Sleep(1000);
			if (e.After.Roles.Count() < 2)
			{
				
				SetRole(user, e);
			}
			if (usertype != "" && usertype != "0" && usertype != "1")
			{
				e.Server.FindChannels("use-bots-here").FirstOrDefault().SendMessage(usertype);
			}

			string rolesBefore = "";
			string rolesAfter = "";
			int i = 1;

			foreach (Discord.Role role in e.Before.Roles)
			{
				if (role.Name != "nvoice-303997237011152896" && role.Name!= "nvoice-303999495501381633" && role.Name != "nvoice-304496811442176003" && role.Name != "nvoice-303999622299254784" && role.Name != "nvoice-304498914445492224" && role.Name != "nvoice-305904009414311936" && role.Name != "nvoice-303999693145374722")
				{
					if (i == 1)
					{
						rolesBefore += role.Name;
					}
					else
					{
						rolesBefore += ", " + role.Name;
					}
					i++;
				}
			}

			i = 1;

			foreach (Discord.Role role in e.After.Roles)
			{
				if (role.Name != "nvoice-303997237011152896" && role.Name != "nvoice-303999495501381633" && role.Name != "nvoice-304496811442176003" && role.Name != "nvoice-303999622299254784" && role.Name != "nvoice-304498914445492224" && role.Name != "nvoice-305904009414311936" && role.Name != "nvoice-303999693145374722")
				{
					if (i == 1)
					{
						rolesAfter += role.Name;
					}
					else
					{
						rolesAfter += ", " + role.Name;
					}
					i++;
				}
			}

			//e.Server.FindChannels(stwb.logChanName).First().SendMessage(e.After.Mention);
			//e.Server.FindChannels(stwb.logChanName).First().SendMessage(e.After.Mention + "\n```" + DateTime.Now.ToString("G") + "\n" + "- Above mentioned user has had their status updated. User ID: " + e.After.Id + "```" + stwb.logLineBreak);
			//e.Server.FindChannels(stwb.logChanName).First().SendMessage("```Nickname: " + e.Before.Nickname + "\nRoles: " + rolesBefore + "\nStatus: " + e.Before.Status + "\nCurrent Game: " + e.Before.CurrentGame.Value.Name + "\nVoice Channel: " + e.Before.VoiceChannel + "```");
			//e.Server.FindChannels(stwb.logChanName).First().SendMessage("```Nickname: " + e.After.Nickname + "\nRoles: " + rolesAfter + "\nStatus: " + e.After.Status + "\nCurrent Game: " + e.After.CurrentGame.Value.Name + "\nVoice Channel: " + e.After.VoiceChannel + "```");

			if (e.Before.Nickname != e.After.Nickname)
			{
				e.Server.FindChannels(stwb.logChanName).First().SendMessage(e.After.Mention + "\n```" + DateTime.Now.ToString("G") + "\n" + "- Above mentioned user's NICKNAME updated.\nOLD Nickname: " + e.Before.Nickname + "\nNEW Nickname: " + e.After.Nickname + "```" + stwb.logLineBreak);
			}


			if (rolesBefore != rolesAfter)
			{
				e.Server.FindChannels(stwb.logChanName).First().SendMessage(e.After.Mention + "\n```" + DateTime.Now.ToString("G") + "\n" + "- Above mentioned user's ROLES updated.\nOLD Roles: " + rolesBefore + "\nNEW Roles: " + rolesAfter + "```" + stwb.logLineBreak);
			}


			if (e.Before.Status != e.After.Status)
			{
				e.Server.FindChannels(stwb.logChanName).First().SendMessage(e.After.Mention + "\n```" + DateTime.Now.ToString("G") + "\n" + "- Above mentioned user's STATUS updated.\nOLD Status: " + e.Before.Status + "\nNEW Status: " + e.After.Status + "```" + stwb.logLineBreak);
			}


			string beforeCurrentGame = "";
			string afterCurrentGame = "";
			bool isBot = false;
			ulong userID = Convert.ToUInt64(000000000000000000);
			ulong nadekoID = Convert.ToUInt64(116275390695079945);

			if (e.Before.CurrentGame.HasValue)
			{
				beforeCurrentGame = e.Before.CurrentGame.Value.Name;
				isBot = e.Before.IsBot;
				userID = e.Before.Id;
			}

			if (e.After.CurrentGame.HasValue)
			{
				afterCurrentGame = e.After.CurrentGame.Value.Name;
			}

			if (beforeCurrentGame != afterCurrentGame && userID != nadekoID)
			{
				e.Server.FindChannels(stwb.logChanName).First().SendMessage(e.After.Mention + "\n```" + DateTime.Now.ToString("G") + "\n" + "- Above mentioned user's CURRENT GAME updated.\nOLD Game: " + beforeCurrentGame + "\nNEW Game: " + afterCurrentGame + "```" + stwb.logLineBreak);
			}

			if (e.Before.VoiceChannel != e.After.VoiceChannel)
			{
				e.Server.FindChannels(stwb.logChanName).First().SendMessage(e.After.Mention + "\n```" + DateTime.Now.ToString("G") + "\n" + "- Above mentioned user's VOICE CHANNEL updated.\nOLD Voice Channel: " + e.Before.VoiceChannel.Name + "\nNEW Voice Channel: " + e.After.VoiceChannel.Name + "```" + stwb.logLineBreak);
			} 
		}




		static void SetRole(object user, Discord.UserUpdatedEventArgs e)
		{
			//Discord.Role everyoneRole = e.Server.FindRoles("@everyone").FirstOrDefault();
			if (e.After.Roles.Count() > 1) return;

			Discord.Channel chan = e.Server.FindChannels("__").FirstOrDefault();
			Discord.Channel mainChannel = e.Server.FindChannels("Sum Ting Wong￬").FirstOrDefault();
			//string userType = "1";
			Discord.Role pugsRole = e.Server.FindRoles("PUGS").FirstOrDefault();



			if (e.After.VoiceChannel == null) return;
			if (e.After.VoiceChannel == chan)
			{

				//e.After.AddRoles(pugsRole);

				//e.Server.FindRoles("PUGS").FirstOrDefault();

				List<Discord.Role> roles = new List<Discord.Role>(new Discord.Role[] { e.Server.FindRoles("PUGS").FirstOrDefault() });

				//System.Threading.Thread.Sleep(500);

				e.After.Edit(voiceChannel: mainChannel, roles: roles);

				//userType = "PUG";
				return;
			}
			else
			{
				System.Threading.Thread.Sleep(500);
				if (e.After.Roles.Equals(pugsRole)) return;
				if (e.After.Roles.Count() > 0) return;
				Discord.Role membersRole = e.Server.FindRoles("MEMBERS").FirstOrDefault();

				e.After.AddRoles(membersRole);
			}

			return;
		}
	}
}
