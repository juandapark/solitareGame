using System.Collections.Generic;
using Core.Interfaces;

namespace Core.Managers
{
    public class UndoManager : IMoveCommand
    {
        private readonly Stack<ICommand> moveHistory = new();

        public void Execute(ICommand cmd)
        {
            cmd.Do();
            moveHistory.Push(cmd);
        }

        public void UndoLast()
        {
            if (moveHistory.Count > 0)
            {
                moveHistory.Pop().Undo();
            }
        }
    }
}