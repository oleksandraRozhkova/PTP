
using UnityEngine;

namespace Game.Gameplay
{
    internal class MoveLeftRightPrincess : MonoBehaviour
    {

        [SerializeField, Range(30,60)]
        private float speed_Left_Right = default;

      
        void Update()
        {

            Vector3 acceleration = Input.acceleration;

            transform.Translate(acceleration.x * speed_Left_Right * Time.deltaTime, 0f, 0f);

            //transform.position += new Vector3(acceleration.x, 0f, 0f) * speed_Left_Right;
        }
    }
}

