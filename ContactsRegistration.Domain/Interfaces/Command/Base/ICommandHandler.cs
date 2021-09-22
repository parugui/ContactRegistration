namespace ContactsRegistration.Domain.Interfaces.Command.Base
{
    /// <summary>
    /// Execute command handle
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(ICommand command);
    }
}
