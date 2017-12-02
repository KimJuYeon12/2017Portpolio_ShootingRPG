using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class BossPatternAttack : MonoBehaviour
    {
        public GameObject patternMissile;

        public int[][] patternMatrix =
        {
        new int[] {1, 0, 1, 1, 1},
        new int[] {1, 1, 0, 1, 1},
        new int[] {1, 1, 1, 0, 1},
        new int[] {1, 0, 0, 1, 1}
    };

        public float patternIntervalTime = 1f;

        // Use this for initialization
        private void Start()
        {
            StartCoroutine(PatternAttack());
        }

        private IEnumerator PatternAttack()
        {
            float patternAttackInterval = (float)gameObject.transform.localScale.x / (float)(patternMatrix[0].Length - 1);

            while (gameObject.activeSelf)
            {
                for (int i = 0; i < patternMatrix.Length; i++)
                {
                    for (int j = 0; j < patternMatrix[0].Length; j++)
                    {
                        if (patternMatrix[i][j] == 0)
                        {
                            continue;
                        }
                        else
                        {
                            Instantiate(patternMissile,
                                new Vector3(transform.position.x - transform.localScale.x / 2 + j * patternAttackInterval
                                , transform.position.y, transform.position.z + transform.localScale.z / 2f),
                                Quaternion.identity
                                );
                        }
                    }
                    yield return new WaitForSeconds(patternIntervalTime);
                }
            }
        }
    }
}