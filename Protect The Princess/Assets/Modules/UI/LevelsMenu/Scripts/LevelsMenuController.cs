using System;
using UnityEngine;
using UnityEngine.UI;


namespace Game.UI
{
    internal class LevelsMenuController : MonoBehaviour, ILevelsMenuView
    {
        public event Action OnBackToMainMenuGamePressed;

        [SerializeField]
        private Button my_BackToMainMenuButton = default;

        public event Action OnLevel1ButtonPressed;

        [SerializeField]
        private Button my_FirstLevelButton = default;

        private void Awake()
        {
            my_BackToMainMenuButton.onClick.AddListener(() =>
            {
                OnBackToMainMenuGamePressed?.Invoke();
            });

            my_FirstLevelButton.onClick.AddListener(() =>
            {
                OnLevel1ButtonPressed?.Invoke();
            });
        }
    }
}
