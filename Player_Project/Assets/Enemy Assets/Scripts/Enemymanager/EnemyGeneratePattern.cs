using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratePattern : MonoBehaviour
{
    public GameObject[] fireEnemy;
    public GameObject[] iceEnemy;
    public GameObject[] forestEnemy;

    private GameObject[] enemy;

    public GameObject mainCamera;

    public enum Map_Type
    {
        Fire, Forest, Ice
    }

    public Map_Type mapType;

    private float patternGenerateInterval;
    private int[][] patternMatrix;

    public int[][] firePatternMatrix =
    {
        new int[] {0, -1, 0, -1, 0, -1, 0, -1, 0, -1},
        new int[] {1, -1, 1, -1, 1, -1, 1, -1, 1, -1},
        new int[] {2, -1, 2, -1, 2, -1, 2, -1, 2, -1},
    };

    public int[][] icePatternMatrix =
    {
        new int[] {1, -1, 1, -1, 1, -1, 1, -1, 1, -1},
        new int[] {1, -1, 1, -1, 1, -1, 1, -1, 1, -1},
        new int[] {1, -1, 1, -1, 1, -1, 1, -1, 1, -1},
        new int[] {1, -1, 1, -1, 1, -1, 1, -1, 1, -1}
    };

    public int[][] forestPatternMatrix =
    {
        new int[] {2, -1, 2, -1, 2, -1, 2, -1, 2, -1},
        new int[] {2, -1, 2, -1, 2, -1, 2, -1, 2, -1},
        new int[] {2, -1, 2, -1, 2, -1, 2, -1, 2, -1},
        new int[] {2, -1, 2, -1, 2, -1, 2, -1, 2, -1},
    };

    public float patternIntervalTime = 1f;
    public float initZ = 16f;

    // Use this for initialization
    private void Start()
    {
        switch (mapType)
        {
            case Map_Type.Fire:
                patternMatrix = firePatternMatrix;
                enemy = fireEnemy;
                break;

            case Map_Type.Ice:
                patternMatrix = icePatternMatrix;
                enemy = iceEnemy;
                break;

            case Map_Type.Forest:
                patternMatrix = forestPatternMatrix;
                enemy = forestEnemy;
                break;
        }

        StartCoroutine(c_GeneratePattern());
    }

    private IEnumerator c_GeneratePattern()
    {
        patternGenerateInterval = 1f; //(float)gameObject.transform.localScale.x / (float)(patternMatrix[0].Length - 1);

        while (gameObject.activeSelf)
        {
            for (int i = 0; i < patternMatrix.Length; i++)
            {
                float initX = mainCamera.transform.position.x - 4.5f;
                //Camera mainCamera2 = mainCamera.GetComponent<Camera>();
                //initZ == mainCamera2.

                for (int j = 0; j < patternMatrix[0].Length; j++)
                {
                    if (patternMatrix[i][j] == -1)
                    {
                        initX += patternGenerateInterval;
                        continue;
                    }
                    else
                    {
                        if (enemy[patternMatrix[i][j]] == null)
                        {
                            Debug.LogWarning("enemy[" + patternMatrix[i][j] + "]이 없음");
                        }

                        Instantiate(enemy[patternMatrix[i][j]], new Vector3(initX, 0f, initZ),
                            Quaternion.identity);
                    }

                    initX += patternGenerateInterval;
                }
                yield return new WaitForSeconds(patternIntervalTime);
            }
        }
    }
}