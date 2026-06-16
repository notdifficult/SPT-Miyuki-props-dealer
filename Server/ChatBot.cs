using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Helpers.Dialogue;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Dialog;
using SPTarkov.Server.Core.Models.Eft.Profile;
using SPTarkov.Server.Core.Models.Enums;
//using SPTarkov.Server.Core.Models.Spt.Mod;
using SPTarkov.Server.Core.Services;
using SPTarkov.Server.Core.Models.Utils;                                                                                // logger add


namespace MiyukiPropsDealer;

[Injectable]
public class MPDChatBot
    (
        ISptLogger<MPDBasicModInfo> logger,
        MailSendService mailSendService
    ) : IDialogueChatBot

{
    public UserDialogInfo GetChatBot()
    {
        return new UserDialogInfo
        {
            Id = "6a2b2d6fce04bf77dbda0df2",
            Aid = 9492292,
            Info = new UserDialogDetails
            {
                Nickname = "Miyuki",
                Side = "Bear",
                Level = 1,
                MemberCategory = MemberCategory.Sherpa,
                SelectedMemberCategory = MemberCategory.Sherpa
            }
        };
    }

    public ValueTask<string> HandleMessage(MongoId sessionId, SendMessageRequest request)
    {
        mailSendService.SendUserMessageToPlayer(
            sessionId,
            GetChatBot(),
            $"Im Miyuki! I just reply back what you typed to me!\n\n{request.Text}");

        return ValueTask.FromResult(request.DialogId);
    }
}