using System;
using UnityEngine;
using UnityEngine.UI;


namespace Game.UI
{
    internal class PauseMenuController : MonoBehaviour, IPauseMenuView
    {
        public event Action OnBackToGameButtonPressed;

        [SerializeField]
        private Button my_BackToGameButton = default;

        public event Action OnMainManuButtonPressed;

        [SerializeField]
        private Button my_MainManuButton = default;

        private void Awake()
        {
            my_BackToGameButton.onClick.AddListener(() =>
            {
                OnBackToGameButtonPressed?.Invoke();
            });

            my_MainManuButton.onClick.AddListener(() =>
            {
                OnMainManuButtonPressed?.Invoke();
            });
        }
    }
}
