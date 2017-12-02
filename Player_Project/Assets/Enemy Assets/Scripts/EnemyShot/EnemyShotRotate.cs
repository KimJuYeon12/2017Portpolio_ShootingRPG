using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Enemy
{
    public class EnemyShotRotate : MonoBehaviour
    {
        public GameObject missile;
        public GameObject[] shotSpawn;
        public Vector3 angle = new Vector3(0f, 10f, 0f);
        public float shotTime = 1f;
        public int shotNum = 3;
        public float shotFreq = 0.5f;
        public int shotFreqNum = 3;

        public enum ShotRotate
        {
            Right, Straight, Left
        }

        public ShotRotate rotationDirect;

        // Use this for initialization
        private void Start()
        {
            //StartCoroutine(attack());
        }

        private void OnEnable()
        {
            StartCoroutine(attack());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private IEnumerator attack()
        {
            Vector3 initAngle = (float)(shotNum - 1) / 2f * angle;

            if (rotationDirect == ShotRotate.Left)
            {
                angle.y *= -1f;
            }

            for (int i = 0; i < shotSpawn.Length; i++)
            {
                shotSpawn[i].transform.Rotate(-initAngle);
            }
            Quaternion initRotation = shotSpawn[0].transform.rotation;

            while (gameObject.activeSelf)
            {
                for (int k = 0; k < shotFreqNum; k++)
                {
                    for (int i = 0; i < shotNum; i++)
                    {
                        for (int j = 0; j < shotSpawn.Length; j++)
                        {
                            Instantiate(missile, shotSpawn[j].transform.position, shotSpawn[j].transform.rotation);
                            shotSpawn[j].transform.Rotate(angle);
                        }
                    }

                    if (rotationDirect == ShotRotate.Straight)
                    {
                        InitShotSpawnRotation(initRotation);
                    }

                    yield return new WaitForSeconds(shotFreq);
                }
                yield return new WaitForSeconds(shotTime);

                InitShotSpawnRotation(initRotation);
            }
        }

        public void InitShotSpawnRotation(Quaternion initValue)
        {
            for (int i = 0; i < shotSpawn.Length; i++)
            {
                shotSpawn[i].transform.rotation = initValue;
            }
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}