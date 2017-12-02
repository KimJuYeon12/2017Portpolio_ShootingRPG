using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Enemy
{
    public class EnemyShotLaser : MonoBehaviour
    {
        public GameObject missile;
        public GameObject[] shotSpawn;
        public GameObject chargeObj;
        public float chargeTime = 1f;
        public float durationTime = 2f;
        public float reduceTime = 0.1f;
        public float reloadTime = 2f;

        public int shotLoopCnt = 1;
        private int shotLoopCntInit;
        public bool shotLoop = true;
        GameObject[] missileTmp;

        private void Awake()
        {
        }

        // Use this for initialization
        private void Start()
        {
            //StartCoroutine(Attack());
        }

        private void OnEnable()
        {
            shotLoopCntInit = shotLoopCnt;
            StartCoroutine(Attack());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
            for (int i = 0; i < shotSpawn.Length; i++)
            {
                Destroy(missileTmp[i]);
            }

        }

        private IEnumerator Attack()
        {
            while (shotLoopCntInit > 0 || shotLoop == true)
            {
                yield return StartCoroutine(Charge());
                yield return StartCoroutine(Shot());

                if (!shotLoop)
                {
                    shotLoopCntInit--;
                }
            }
        }

        private IEnumerator Charge()
        {
            GameObject[] chargeTmp = new GameObject[shotSpawn.Length];

            for (int i = 0; i < shotSpawn.Length; i++)
            {
                chargeTmp[i] = Instantiate(chargeObj, shotSpawn[i].transform.position, Quaternion.identity);
                chargeTmp[i].transform.SetParent(gameObject.transform);
            }

            yield return new WaitForSeconds(chargeTime);

            for (int i = 0; i < shotSpawn.Length; i++)
            {
                Destroy(chargeTmp[i]);
            }
        }

        private IEnumerator Shot()
        {
            Vector3 initScale;
            float reducedSizeX = missile.transform.localScale.x * 0.1f;
            missileTmp = new GameObject[shotSpawn.Length];

            for (int i = 0; i < shotSpawn.Length; i++)
            {
                missileTmp[i] = Instantiate(missile, shotSpawn[i].transform.position, Quaternion.identity);
                missileTmp[i].transform.SetParent(gameObject.transform);

            }

            yield return new WaitForSeconds(durationTime);

            while (true)
            {
                initScale = missileTmp[0].transform.localScale;
                initScale.x -= reducedSizeX;
                if (initScale.x < 0)
                {
                    break;
                }

                for (int i = 0; i < shotSpawn.Length; i++)
                {
                    missileTmp[i].transform.localScale = initScale;
                }
                yield return new WaitForSeconds(reduceTime);
            }

            for (int i = 0; i < shotSpawn.Length; i++)
            {
                Destroy(missileTmp[i]);
            }
            yield return new WaitForSeconds(reloadTime);
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}