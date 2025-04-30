using System;
using Core.Interfaces;
using UnityEngine;

namespace Core.Managers
{
    public class GameManager : MonoBehaviour, IMoveCommand
    {
        public static GameManager Instance;

        [SerializeField] private GameObject cardPrefab, uiButton;
        [SerializeField] private StackZoneManager stackZoneManager;

        private UndoManager undoManager;

        private void Awake()
        {
            //Simple Singleton
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            stackZoneManager.Initialise(cardPrefab);
            undoManager = new UndoManager();
        }

        public void Execute(ICommand cmd)
        {
            undoManager.Execute(cmd);
            uiButton.SetActive(true);
        }

        public void UndoLast()
        {
            undoManager.UndoLast();
        }
    }
}
