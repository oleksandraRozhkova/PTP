
using UnityEngine;

namespace Game.Gameplay
{
    internal class CameraFolowThePrincess : MonoBehaviour
    {
        [SerializeField]
        private GameObject player = default;
        

        void Update()
        {
          
            transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - 11f);
        }
    }
}

