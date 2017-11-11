using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveBoss3 : MonoBehaviour
{
    private GameObject[] Boss;

    //private GameObject[] ShotSpawn;
    private EnemyShotLaser[] enemyShotLaser;

    public float horizontalSpeed = 2f;

    public int[][] patternMatrix =
   {
        new int[] {1, 1},
        new int[] {1, 0},
        new int[] {0, 1}
    };

    // Use this for initialization
    private void Start()
    {
        Boss = new GameObject[2];
        //ShotSpawn = new GameObject[2];
        enemyShotLaser = new EnemyShotLaser[2];

        for (int i = 0; i < 2; i++)
        {
            Boss[i] = GetChildObject("EnemyBoss3_" + (i + 1) + "(Forest)");
            enemyShotLaser[i] = Boss[i].GetComponent<EnemyShotLaser>();
        }

        StartCoroutine(cBossPattern());
    }

    private IEnumerator cBossPattern()
    {
        yield return StartCoroutine(cMoveHorizontal());
        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(cPatternAttack());
    }

    private IEnumerator cMoveHorizontal()
    {
        bool check1 = true, check2 = true;
        while (check1 || check2)
        {
            check1 = moveHorizontal(Boss[0], 0);
            check2 = moveHorizontal(Boss[1], 1);
            yield return null;
        }
    }

    public bool moveHorizontal(GameObject go, int pos)
    { //이동 거리 수정, 델리게이트로 수정
        if (pos == 0)
        {
            if (go.transform.position == transform.position + new Vector3(-go.transform.localScale.x / 2f - 0.2f, 0f, 0f))
            {
                return false;
            }
            go.transform.position = Vector3.MoveTowards(go.transform.position, transform.position + new Vector3(-go.transform.localScale.x / 2f - 0.2f, 0f, 0f), horizontalSpeed * Time.deltaTime);
        }
        else if (pos == 1)
        {
            if (go.transform.position == transform.position + new Vector3(go.transform.localScale.x / 2f + 0.2f, 0f, 0f))
            {
                return false;
            }
            go.transform.position = Vector3.MoveTowards(go.transform.position, transform.position + new Vector3(go.transform.localScale.x / 2f + 0.2f, 0f, 0f), horizontalSpeed * Time.deltaTime);
        }

        return true;
    }

    private IEnumerator cPatternAttack()
    {
        //for (int i = 0; i < 2; i++)
        //{
        //    var tf = Boss[i].transform.FindChild("ShotSpawn");
        //    ShotSpawn[i] = tf.gameObject;
        //}

        //Attack(0);
        //Attack(1);

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
                        enemyShotLaser[j].enabled = true;
                    }
                }

                yield return new WaitForSeconds(enemyShotLaser[0].chargeTime + enemyShotLaser[0].durationTime + enemyShotLaser[0].reduceTime * 10f);

                for (int j = 0; j < patternMatrix[0].Length; j++)
                {
                    if (patternMatrix[i][j] == 0)
                    {
                        continue;
                    }
                    else
                    {
                        enemyShotLaser[j].enabled = false;
                    }
                }

                yield return new WaitForSeconds(2f);
            }
        }

        //yield return new WaitForSeconds(2f);
    }

    //public void Attack(int pos)
    //{
    //    EnemyShotLaser esl;

    //    esl = Boss[pos].AddComponent<EnemyShotLaser>();
    //    esl.missile = Resources.Load("Missile/MissileLaser") as GameObject;
    //    //esl.shotSpawn = ShotSpawn[pos];
    //}

    public GameObject GetChildObject(string name)
    {
        Transform[] tf = GetComponentsInChildren<Transform>();
        foreach (var tmp in tf)
        {
            if (tmp.name == name)
            {
                return tmp.gameObject;
            }
        }

        return null;
    }
}