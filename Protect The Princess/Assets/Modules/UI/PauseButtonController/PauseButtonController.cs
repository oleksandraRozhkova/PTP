using System;
using UnityEngine;
using UnityEngine.UI;


namespace Game.UI
{
    internal class PauseButtonController : MonoBehaviour, IPauseButttonView
    {
        public event Action OnPauseButtonPressed;

        [SerializeField]
        private Button my_PauseButton = default;

        
        private void Awake()
        {
            my_PauseButton.onClick.AddListener(() =>
            {
                OnPauseButtonPressed?.Invoke();
            });

        }
    }
}
