using UnityEngine;

namespace Game.Gameplay
{
    internal class MoveForwardPrincess : MonoBehaviour
    {

        [SerializeField, Range(1,10)]
        private float movmentSpeed = default;


        void Update()
        {
            transform.position += Vector3.forward * Time.deltaTime * movmentSpeed;

            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}

