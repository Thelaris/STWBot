using System;
using System.Collections.Generic;
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


		static public List<string> activeBPermRoles = new List<string>();
		static public List<string> activeAPermRoles = new List<string>();

		static public void bot_ChannelUpdated(object channel, Discord.ChannelUpdatedEventArgs e)
		{
			if (stwb.logUpdatedChan == true)
			{
				 e.Server.FindChannels(stwb.logChanName).First().SendMessage("```" + DateTime.Now.ToString("G") + "\n" + "- " + e.After.Type + " channel: " + e.After.Name + " has been updated```" + stwb.logLineBreak);

				if (e.Before.Name != e.After.Name)
				{
					e.Server.FindChannels(stwb.logChanName).First().SendMessage("```" + DateTime.Now.ToString("G") + "\n" + "- " + e.After.Type + " channel NAME changed.\nOLD Name: " + e.Before.Name + "\nNEW Name: " + e.After.Name + "```" + stwb.logLineBreak);
				}

				string beforePerms = "";
				string afterPerms = "";

				string bAttachFiles = "";
				string bConnect = "";
				string bCreateInstantInvites = "";
				string bDeafenMembers = "";
				string bEmbedLinks = "";
				string bManageChannel = "";
				string bManageMessages = "";
				string bManagePermissions = "";
				string bMentionEveryone = "";
				string bMoveMembers = "";
				string bMuteMembers = "";
				string bReadMessageHistory = "";
				string bReadMessages = "";
				string bSendMessages = "";
				string bSendTTSMessages = "";
				string bSpeak = "";
				string bUseVoiceActivation = "";

				string aAttachFiles = "";
				string aConnect = "";
				string aCreateInstantInvites = "";
				string aDeafenMembers = "";
				string aEmbedLinks = "";
				string aManageChannel = "";
				string aManageMessages = "";
				string aManagePermissions = "";
				string aMentionEveryone = "";
				string aMoveMembers = "";
				string aMuteMembers = "";
				string aReadMessageHistory = "";
				string aReadMessages = "";
				string aSendMessages = "";
				string aSendTTSMessages = "";
				string aSpeak = "";
				string aUseVoiceActivation = "";

				int i = 12;

				activeBPermRoles.Clear();
				activeAPermRoles.Clear();

				List<String> bPermFlags = new List<string>();

				foreach (Discord.Channel.PermissionOverwrite perm in e.Before.PermissionOverwrites)
				{
					activeBPermRoles.Add(e.Server.GetRole(perm.TargetId).Name);
					e.Server.FindChannels(stwb.logChanName).First().SendMessage(e.Server.GetRole(perm.TargetId).Name);

					bAttachFiles = perm.Permissions.AttachFiles.ToString();
					bConnect = perm.Permissions.Connect.ToString();
					bCreateInstantInvites = perm.Permissions.CreateInstantInvite.ToString();
					bDeafenMembers = perm.Permissions.DeafenMembers.ToString();
					bEmbedLinks = perm.Permissions.EmbedLinks.ToString();
					bManageChannel = perm.Permissions.ManageChannel.ToString();
					bManageMessages = perm.Permissions.ManageMessages.ToString();
					bManagePermissions = perm.Permissions.ManagePermissions.ToString();
					bMentionEveryone = perm.Permissions.MentionEveryone.ToString();
					bMoveMembers = perm.Permissions.MoveMembers.ToString();
					bMuteMembers = perm.Permissions.MuteMembers.ToString();
					bReadMessageHistory = perm.Permissions.ReadMessageHistory.ToString();
					bReadMessages = perm.Permissions.ReadMessages.ToString();
					bSendMessages = perm.Permissions.SendMessages.ToString();
					bSendTTSMessages = perm.Permissions.AttachFiles.ToString();
					bSpeak = perm.Permissions.Speak.ToString();
					bUseVoiceActivation = perm.Permissions.UseVoiceActivation.ToString();

					bPermFlags.AddRange(new List<string>(new string[] { bAttachFiles, bConnect, bCreateInstantInvites, bDeafenMembers, bEmbedLinks, bManageChannel, bManageMessages, bManagePermissions, bMentionEveryone, bMoveMembers, bMuteMembers, bReadMessageHistory, bReadMessages, bSendMessages, bSendTTSMessages, bSpeak, bUseVoiceActivation }));

					e.Server.FindChannels(stwb.logChanName).First().SendMessage(bPermFlags[i]);
					i += 12;
				}

				foreach (Discord.Channel.PermissionOverwrite perm in e.Before.PermissionOverwrites)
				{
					ChannelEvents.activeAPermRoles.Add(e.Server.GetRole(perm.TargetId).Name);
					e.Server.FindChannels(stwb.logChanName).First().SendMessage(e.Server.GetRole(perm.TargetId).Name);

					aAttachFiles = perm.Permissions.AttachFiles.ToString();
					aConnect = perm.Permissions.Connect.ToString();
					aCreateInstantInvites = perm.Permissions.CreateInstantInvite.ToString();
					aDeafenMembers = perm.Permissions.DeafenMembers.ToString();
					aEmbedLinks = perm.Permissions.EmbedLinks.ToString();
					aManageChannel = perm.Permissions.ManageChannel.ToString();
					aManageMessages = perm.Permissions.ManageMessages.ToString();
					aManagePermissions = perm.Permissions.ManagePermissions.ToString();
					aMentionEveryone = perm.Permissions.MentionEveryone.ToString();
					aMoveMembers = perm.Permissions.MoveMembers.ToString();
					aMuteMembers = perm.Permissions.MuteMembers.ToString();
					aReadMessageHistory = perm.Permissions.ReadMessageHistory.ToString();
					aReadMessages = perm.Permissions.ReadMessages.ToString();
					aSendMessages = perm.Permissions.SendMessages.ToString();
					aSendTTSMessages = perm.Permissions.AttachFiles.ToString();
					aSpeak = perm.Permissions.Speak.ToString();
					aUseVoiceActivation = perm.Permissions.UseVoiceActivation.ToString();

					e.Server.FindChannels(stwb.logChanName).First().SendMessage(perm.Permissions.Speak.ToString());
				}

				if (e.Before.Name != e.After.Name)
				{
					e.Server.FindChannels(stwb.logChanName).First().SendMessage("```" + DateTime.Now.ToString("G") + "\n" + "- " + e.After.Type + " channel NAME changed.\nOLD Name: " + e.Before.Name + "\nNEW Name: " + e.After.Name + "```" + stwb.logLineBreak);
				}


					//e.Before.PermissionOverwrites;
				//e.Before.Position;
				//e.Before.Topic;
			}
		}
	}
}
