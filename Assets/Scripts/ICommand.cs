namespace Core.Interfaces
{
    public interface ICommand
    {
        void Do();
        void Undo();
    }

}