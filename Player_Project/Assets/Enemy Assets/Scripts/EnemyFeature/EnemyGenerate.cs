using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyGenerate : MonoBehaviour
    {
        public GameObject[] generateSpawn;
        public GameObject[] generatedEnemy;
        public int generateNum = 3;

        //private Vector3 bossSpawn;

        public float generateTime = 1f;
        // Use this for initialization

        //tmp
        //public int health = 3;

        private void Awake()
        {
            //bossSpawn = transform.position;
        }

        private void Start()
        {
            StartCoroutine(generatePattern());
        }

        private IEnumerator generatePattern()
        {
            while (gameObject.activeSelf)
            {
                if (!CheckingChildren())
                {
                    yield return new WaitForSeconds(2f);
                    StartCoroutine(createEnemy());
                }
                yield return null;
            }
        }

        private IEnumerator createEnemy()
        {
            for (int j = 0; j < generateNum; j++)
            {
                for (int i = 0; i < generateSpawn.Length; i++)
                {
                    var enemyJunior = Instantiate(generatedEnemy[i], generateSpawn[i].transform.position, Quaternion.identity, gameObject.transform);
        }

                yield return new WaitForSeconds(generateTime);
            }

            //while (gameObject.activeSelf)
            //{
            //    health--;
            //    if (health < 0)
            //    {
            //        Destroy(gameObject);
            //    }
            //    yield return new WaitForSeconds(1f);
            //}
        }

        public bool CheckingChildren()
        {
            BoxCollider[] childrenTf = GetComponentsInChildren<BoxCollider>();
            if (childrenTf.Length == 1) //자기 자신?
            {
                return false;
            }
            //Debug.Log(childrenTf.Length);
            return true;
        }
    }
}