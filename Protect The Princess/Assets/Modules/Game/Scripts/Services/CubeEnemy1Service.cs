using System.Collections.Generic;
using Modules.Game.UI;
using StansAssets.Foundation;
using UnityEngine;

namespace Game.GamePlay
{

    class CubeEnemy1Service
    {
        const int k_TotalLives = 5;

        int m_Coins;
        int m_Lives;
        readonly IGamePlayUIView m_GamePlayUI;
        readonly List<CubeEnemy1> m_CubeEnemy1 = new List<CubeEnemy1>();

        public void Register(CubeEnemy1 cubeEnemy1)
        {
            m_CubeEnemy1.Add(cubeEnemy1);
            cubeEnemy1.OnTouch += OnCubeEnemyTouch;
        }

        public void Unregister(CubeEnemy1 cubeEnemy1)
        {
            m_CubeEnemy1.Remove(cubeEnemy1);
            cubeEnemy1.OnTouch -= OnCubeEnemyTouch;
        }


        void OnCubeEnemyTouch(Collision collision)
        {
           // здусь нужно описать как на OnMouseDown задается coin и lives
        }
    }
}