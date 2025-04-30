
namespace Core.Interfaces
{
    public interface IMoveCommand
    {
        public void Execute(ICommand cmd);
        public void UndoLast();
    }
}
