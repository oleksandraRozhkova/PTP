using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    internal class MainMenuController : MonoBehaviour, IMainMenuView
    {
        public event Action OnStartGameButtonPressed;

        [SerializeField]
        private Button my_GameStartButton = default;

        private void Awake()
        {
            my_GameStartButton.onClick.AddListener(() =>
            {
                OnStartGameButtonPressed?.Invoke();
            });
        }
    }
}
