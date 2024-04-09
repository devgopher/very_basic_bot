using System.Globalization;
using Botticelli.Client.Analytics;
using Botticelli.Framework.Commands.Processors;
using Botticelli.Framework.Commands.Validators;
using Botticelli.Framework.SendOptions;
using Botticelli.Interfaces;
using Botticelli.Shared.API.Client.Requests;
using Botticelli.Shared.ValueObjects;

namespace VeryBasicBot.BusinessLogic.Commands.Commands.Processors;


/// <summary>
/// A processor for "/GetUtc" command 
/// </summary>
/// <typeparam name="TReplyMarkupBase"></typeparam>
public class GetUtcCommandProcessor<TReplyMarkupBase> : CommandProcessor<GetUtcCommand> 
    where TReplyMarkupBase : class
{
    // /// <summary>
    // /// Reply markup options (such as reply keyboard in Telegram)
    // /// </summary>
    // private readonly SendOptionsBuilder<TReplyMarkupBase> _options;
    //
    
    public GetUtcCommandProcessor(ILogger<GetUtcCommandProcessor<TReplyMarkupBase>> logger,
        ICommandValidator<GetUtcCommand> validator,
        MetricsProcessor metricsProcessor)
        : base(logger, validator, metricsProcessor)
    {
    }

    protected override Task InnerProcessContact(Message message, string argsString, CancellationToken token)
    {
        return Task.CompletedTask;
    }

    protected override Task InnerProcessPoll(Message message, string argsString, CancellationToken token)
    {
        return Task.CompletedTask;
    }

    protected override Task InnerProcessLocation(Message message, string argsString, CancellationToken token)
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// All business logic is being called here...
    /// </summary>
    /// <param name="message"></param>
    /// <param name="args"></param>
    /// <param name="token"></param>
    protected override async Task InnerProcess(Message message, string args, CancellationToken token)
    {
        // Creates a message for sending
        var utcMessageRequest = new SendMessageRequest(Guid.NewGuid().ToString())
        {
            Message = new Message
            {
                Uid = Guid.NewGuid().ToString(),
                ChatIds = message.ChatIds,
                Body = $"Current UTC Time is: {DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)}",
            }
        };

        // Tries to send a message using a concrete implementation of Bot (TelegramBot, for example)
        await _bot.SendMessageAsync(request: utcMessageRequest, optionsBuilder: (ISendOptionsBuilder<TReplyMarkupBase>)null!, token: token);
    }
}