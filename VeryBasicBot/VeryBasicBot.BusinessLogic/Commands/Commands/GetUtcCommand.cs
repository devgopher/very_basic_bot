using Botticelli.Framework.Commands;

namespace VeryBasicBot.BusinessLogic.Commands.Commands;

public class GetUtcCommand : ICommand
{
    public Guid Id { get; }
}