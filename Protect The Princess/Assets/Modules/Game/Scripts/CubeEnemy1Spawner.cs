using System.Collections;
using System.Collections.Generic;
using Game.Core;
using Game.GamePlay;
using StansAssets.Foundation.Editor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Gameplay
{

    internal class CubeEnemy1Spawner : MonoBehaviour
    {

        [SerializeField, Range(1, 10)]
        float m_SpawnRang = 1f;

        [SerializeField, Range(0.1f, 5f)]
        float m_SpawnRateMin = 1f;

        [SerializeField, Range(1f, 5f)]
        float m_SpawnRateMax = 1f;

        //[SerializeField]
        //List<CubeEnemy1> m_CubeEnemy1 = new List<CubeEnemy1>();


        [SerializeField]
        GameObject targetObject = default;
        [SerializeField]
        GameObject cubeEnemy = default;




        void Awake()
        {
            DestroyComponent<MeshRenderer>();
            DestroyComponent<MeshFilter>();

            StartCoroutine(SpawnLoop());
        }

        void DestroyComponent<T>() where T : Component
        {
            var component = GetComponent<T>();
            if (component != null)
                Destroy(component);
        }

        IEnumerator SpawnLoop()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(m_SpawnRateMin, m_SpawnRateMax));
                Spawn();
            }
        }

        [ContextMenu("Test Spawn")]
        void Spawn()
        {
            CreateCubeEnemy1();
            
        }

        

        void CreateCubeEnemy1()
        {


            var cubeEnemyObject = Instantiate(cubeEnemy);
            //var cubeEnemyObject = Serivces.Get<IPoolingService>().Instantiate<CubeEnemy1>(m_CubeEnemy1);

            var cubeEnemyGameObject = cubeEnemyObject.gameObject;
            var spawnSpread = Random.Range(-m_SpawnRang, m_SpawnRang);
            cubeEnemyGameObject.transform.SetParent(transform);
            cubeEnemyGameObject.transform.localPosition = new Vector3(spawnSpread, 0, 0);

           
            var v = targetObject.transform.position - transform.position;
            Debug.Log(-v.normalized);
            cubeEnemyGameObject.GetComponent<Rigidbody>().AddForce(v.normalized * 300f);
            

            Destroy(cubeEnemyGameObject, 10f);

        }

        

        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;

            var from = transform.position;
            from.x -= m_SpawnRang;

            var to = transform.position;
            to.x += m_SpawnRang;

            Gizmos.DrawLine(from, to);
        }
    }
}