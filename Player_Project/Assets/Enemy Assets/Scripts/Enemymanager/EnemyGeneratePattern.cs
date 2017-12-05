using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyGeneratePattern : MonoBehaviour
{
    [Header("- Enemy Object")]
    public GameObject[] fireEnemy;

    public GameObject[] iceEnemy;
    public GameObject[] forestEnemy;

    [Tooltip("적 생성 위치(카메라 기준)")]
    public float initZ = 8f;

    private float initX;

    [Header("- Boss Object")]
    public GameObject fireBoss;

    public GameObject iceBoss;
    public GameObject forestBoss;

    [Tooltip("보스 탐지 위치(world pos 기준)")]
    public float bossDetectPosZ = 20f;

    [Tooltip("보스 생성 위치(카메라 기준)")]
    public float bossGeneratePosZ = 16f;

    [Tooltip("게임 시작 후, 해당 시간 동안 카메라의 높이를 측정하지 않는다.")]
    public float bossStartWaitTime = 30f;

    [Tooltip("보스가 나타날 카메라의 높이를 측정하는 시간의 간격")]
    public float bossIntervalWaitTime = 1f;

    public float bossMoveSpeed = 10f;
    
    private GameObject[] enemy;
    private GameObject boss;
    
    public float[] enemyRespawnTime = { 1f, 2f, 3f }; //수정

    private GameObject mainCamera;

    public enum Map_Type
    {
        Fire, Forest, //Ice
    }

    [Header("- Generate Type")]
    public Map_Type mapType;

    public bool generateRandom = true;

    public float patternIntervalTime = 1f;
    private float patternGenerateInterval;
    private int[][] patternMatrix;

    public int[][] firePatternMatrix =
    {
        new int[] {0, -1, 0, -1, 0, -1, 0, -1, 0, -1},
        new int[] {0, -1, 0, -1, 0, -1, 0, -1, 0, -1},
        new int[] {0, -1, 0, -1, 0, -1, 0, -1, 0, -1},
        new int[] {0, -1, 0, -1, 0, -1, 0, -1, 0, -1}
    };

    private int[][] icePatternMatrix =
    {
        new int[] {1, -1, 1, -1, 1, -1, 1, -1, 1, -1},
        new int[] {1, -1, 1, -1, 1, -1, 1, -1, 1, -1},
        new int[] {1, -1, 1, -1, 1, -1, 1, -1, 1, -1},
        new int[] {1, -1, 1, -1, 1, -1, 1, -1, 1, -1}
    };

    private int[][] forestPatternMatrix =
    {
        new int[] {2, -1, 2, -1, 2, -1, 2, -1, 2, -1},
        new int[] {2, -1, 2, -1, 2, -1, 2, -1, 2, -1},
        new int[] {2, -1, 2, -1, 2, -1, 2, -1, 2, -1},
        new int[] {2, -1, 2, -1, 2, -1, 2, -1, 2, -1},
    };

    private void Awake()
    {
        mainCamera = Camera.main.gameObject;
    }

    // Use this for initialization
    private void OnEnable()
    {
        switch (mapType)
        {
            case Map_Type.Fire:
                patternMatrix = firePatternMatrix;
                enemy = fireEnemy;
                boss = fireBoss;
                break;

            //case Map_Type.Ice:
            //    patternMatrix = icePatternMatrix;
            //    enemy = iceEnemy;
            //    boss = iceBoss;
            //    break;

            case Map_Type.Forest:
                patternMatrix = forestPatternMatrix;
                enemy = forestEnemy;
                boss = forestBoss;
                break;
        }

        if (generateRandom)
        {
            StartCoroutine(c_GenerateRandom());
        }
        else
        {
            StartCoroutine(c_GeneratePattern());
        }

        StartCoroutine(c_GenerateBoss());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator c_GeneratePattern()
    {
        Debug.Log("Enemy Pattern Generate");
        patternGenerateInterval = 1f; //(float)gameObject.transform.localScale.x / (float)(patternMatrix[0].Length - 1);
        float genPosZ;
        while (gameObject.activeSelf)
        {
            for (int i = 0; i < patternMatrix.Length; i++)
            {
                initX = mainCamera.transform.position.x - 4.5f;

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
                        else
                        {
                            genPosZ = mainCamera.transform.position.z + initZ;
                            Instantiate(enemy[patternMatrix[i][j]], new Vector3(initX, 0f, genPosZ),
                                Quaternion.identity);
                        }
                    }
                    initX += patternGenerateInterval;
                }
                yield return new WaitForSeconds(patternIntervalTime);
            }
        }
    }

    private IEnumerator c_GenerateRandom()
    {
        Debug.Log("Enemy Random Generate");
        float timer = 0f;
        float genPosZ;

        while (gameObject.activeSelf)
        {
            timer++;

            for (int i = 0; i < enemyRespawnTime.Length; i++)
            {
                if (timer % enemyRespawnTime[i] == 0)
                {
                    initX = Random.Range(mainCamera.transform.position.x - 4.5f, mainCamera.transform.position.x + 4.5f);
                    genPosZ = mainCamera.transform.position.z + initZ;
                    Instantiate(enemy[i], new Vector3(initX, 0f, genPosZ), Quaternion.identity);
                }
            }

            if (timer == 10f)
            {
                timer = 0f;
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator c_GenerateBoss()
    {
        yield return new WaitForSeconds(bossStartWaitTime);

        while (mainCamera.transform.position.z <= bossDetectPosZ)
        {
            yield return new WaitForSeconds(bossIntervalWaitTime);
        }

        GameObject bossObj = Instantiate(boss, mainCamera.transform.position + new Vector3(0f, -mainCamera.transform.position.y, bossGeneratePosZ),
            Quaternion.identity);

        //StartCoroutine(c_MoveBossVertical(bossObj));
    }

    private IEnumerator c_MoveBossVertical(GameObject bossObj)
    {
        Vector3 bossCenterPos;

        while (bossObj)
        {
            bossCenterPos = mainCamera.transform.position
            + new Vector3(0f, -mainCamera.transform.position.y, 0f);

            bossObj.transform.position = Vector3.MoveTowards(bossObj.transform.position,
                bossCenterPos, bossMoveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}