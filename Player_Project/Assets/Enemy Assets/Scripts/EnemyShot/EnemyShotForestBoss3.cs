using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyShotForestBoss3 : MonoBehaviour
    {
        public float shotTIme = 1f;
        public GameObject[] enemyBoss;
        public GameObject missile;
        //private Transform[] shotSpawn;

        // Use this for initialization
        private void Start()
        {
            //enemyBoss = gameObject.GetComponentsInChildren<GameObject>();
            //for (int i = 0; i < enemyBoss.Length; i++)
            //{
            //    shotSpawn[i] = enemyBoss[i].transform.FindChild("ShotSpawn");
            //}
        }

        private IEnumerator attack()
        {
            while (gameObject.activeSelf)
            {
                //for (int i = 0; i < shotSpawn.Length; i++)
                //{
                //    Instantiate(missile, shotSpawn[i].transform.position, Quaternion.identity);
                //}
                yield return new WaitForSeconds(shotTIme);
            }
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}