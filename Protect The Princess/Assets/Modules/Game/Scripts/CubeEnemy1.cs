using System;
using Game.Core;
using UnityEngine;


namespace Game.GamePlay
{

    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]

    class CubeEnemy1 : PoolableGameObject
    {

        public event Action OnDestroy;
        public event Action<Collision> OnTouch;


        void Awake()
        {
            gameObject.layer = LayerMask.NameToLayer(GameLayers.CubeEnemy1);
        }


        private void OnMouseDown()
        {

            Destroy(gameObject);

        }




        public override void Init(Action onRelease)
        {
            GameServices.Get<CubeEnemy1Service>().Register(this);
            
            OnDestroy += onRelease;
        }

        public override void Release()
        {
            GameServices.Get<CubeEnemy1Service>().Unregister(this);
        }
    }
}

