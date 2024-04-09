using BotDataSecureStorage.Settings;
using Botticelli.Framework.Commands.Validators;
using Botticelli.Framework.Extensions;
using Botticelli.Framework.Options;
using Botticelli.Framework.Telegram;
using Botticelli.Framework.Telegram.Extensions;
using Botticelli.Framework.Telegram.Options;
using Telegram.Bot.Types.ReplyMarkups;
using VeryBasicBot;
using VeryBasicBot.BusinessLogic.Commands.Commands;
using VeryBasicBot.BusinessLogic.Commands.Commands.Processors;
using VeryBasicBot.Telegram.Settings;

var builder = WebApplication.CreateBuilder(args);

var settings = builder.Configuration
    .GetSection(nameof(VeryBasicBotSettings))
    .Get<VeryBasicBotSettings>();


builder.Services.AddTelegramBot(builder.Configuration,
    new BotOptionsBuilder<TelegramBotSettings>()
        .Set(s => s.SecureStorageSettings = new SecureStorageSettings
        {
            ConnectionString = settings?.SecureStorageConnectionString
        })
        .Set(s => s.Name = settings?.BotName));


builder.Services.AddHostedService<VeryBasicBotService>()
    .AddScoped<GetUtcCommandProcessor<ReplyKeyboardMarkup>>()
    .AddBotCommand<GetUtcCommand, GetUtcCommandProcessor<ReplyKeyboardMarkup>, PassValidator<GetUtcCommand>>();


var app = builder.Build();
app.Services.RegisterBotCommand<GetUtcCommand, GetUtcCommandProcessor<ReplyKeyboardMarkup>, TelegramBot>();

app.Run();

