namespace DF.Infrastructure.CQRS
{
    public interface ICommandHandler<in TParameter> where TParameter : ICommand
    {
        void Execute(TParameter command);
    }
}