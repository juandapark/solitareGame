using Core.Managers;
using UnityEngine;

namespace Gameplay.UI
{
    public class UndoMoveButton : MonoBehaviour
    {
        public void UndoMove()
        {
            GameManager.Instance.UndoLast();
        }
    }
}
