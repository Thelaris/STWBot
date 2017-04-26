using System;
using System.Collections.Generic;
using System.Linq;

namespace STWBot
{
	public class UserEvents
	{
		public UserEvents()
		{
		}

		public void bot_UserJoined(object user, Discord.UserEventArgs e)
		{
			System.Threading.Thread.Sleep(3000);

			if (e.User.Roles.Count() < 2)
			{
				Discord.Role membersRole = e.Server.FindRoles("MEMBERS").FirstOrDefault();

				e.User.AddRoles(membersRole);
			}
		}

		public void bot_UserUpdated(object user, Discord.UserUpdatedEventArgs e)
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
