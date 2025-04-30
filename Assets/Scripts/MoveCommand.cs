using Core.Interfaces;
using Gameplay.StackZone;
using UnityEngine;

namespace Gameplay.Moves
{
    public class MoveCommand : ICommand
    {
        private readonly CardBase card;
        private readonly StackZone.StackZone from, to;

        public MoveCommand(CardBase card, StackZone.StackZone from, StackZone.StackZone to)
        {
            this.card = card;
            this.from = from;
            this.to = to;
        }

        public void Do()
        {
            Apply(to);
        }

        public void Undo()
        {
            Apply(from);
        }

        private void Apply(StackZone.StackZone stack)
        {
            card.transform.SetParent(stack.transform);
            card.transform.position = new Vector3(stack.transform.position.x, stack.transform.position.y, -1);
            card.SetCardStack(stack);
        }
    }
}