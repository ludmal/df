namespace DF.Infrastructure.CQRS
{
    public interface ICommandDispatcher
    {
        /// <summary>
        /// Dispatches a command to its handler
        /// </summary>
        /// <typeparam name="TParameter">Command Type</typeparam>
        /// <param name="command">The command to be passed to the handler</param>
        void Dispatch<TParameter>(TParameter command) where TParameter : ICommand;
    }
}