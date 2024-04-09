using Botticelli.Framework.Telegram;
using Botticelli.Interfaces;
using Microsoft.Extensions.Options;
using VeryBasicBot.Telegram.Settings;

namespace VeryBasicBot;

/// <summary>
///     This hosted service intended keeping an application alive till the termination
/// </summary>
public class VeryBasicBotService : IHostedService
{
    private readonly IOptionsMonitor<VeryBasicBotSettings> _settings;
    private readonly IBot<TelegramBot> _telegramBot;

    public VeryBasicBotService(IBot<TelegramBot> telegramBot, IOptionsMonitor<VeryBasicBotSettings> settings)
    {
        _telegramBot = telegramBot;
        _settings = settings;
    }
    
    public Task StartAsync(CancellationToken token)
    {
        Console.WriteLine("Start serving...");
 
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Stop serving...");

        return Task.CompletedTask;
    }
}