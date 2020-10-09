using System;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Game.UI
{

    public class GamePlayUIView : MonoBehaviour, IGamePlayUIView
    {

        [SerializeField]
        private Text m_CoinsTextField = default;

        [SerializeField]
        private Text m_LivesTextField = default;


        public void SetCoins (int coins)
        {
            m_CoinsTextField.text = $"Coins {coins}";
        }

        public void SetLivesCount(int count)
        {
            m_LivesTextField.text = $"Life: {count}";
        }


    }



}



