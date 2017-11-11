using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2ShotTrunaround : MonoBehaviour
{
    public GameObject missile;
    public int missileCnt = 4;
    private float bossToMissileDist = 3f;
    private GameObject[] missileArray;
    private int existMissileCnt;

    public float straightSpeed = 3f;
    public float turningSpeed = 3f;

    // Use this for initialization
    private void Start()
    {
        missileArray = new GameObject[missileCnt];
        existMissileCnt = missileCnt;
        StartCoroutine(c_MovePattern());
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private IEnumerator c_MovePattern()
    {
        while (gameObject.activeSelf)
        {
            yield return StartCoroutine("c_MoveStraight");

            yield return StartCoroutine("c_MoveTrunaround");

            yield return new WaitForSeconds(2f);
        }
    }

    private IEnumerator c_MoveStraight()
    {
        float angle = 360f / missileCnt / 2f;
        for (int i = 0; i < missileCnt; i++)
        {
            missileArray[i] = Instantiate(missile, transform.position, Quaternion.Euler(0f, angle * i, 0f));
        }

        float moveDist = 0f;

        while (moveDist < bossToMissileDist)
        {
            for (int i = 0; i < missileCnt; i++)
            {
                missileArray[i].transform.Translate(missileArray[i].transform.forward * straightSpeed * Time.deltaTime);
            }

            moveDist += (missileArray[0].transform.forward * straightSpeed * Time.deltaTime).magnitude;

            yield return null;
        }
    }

    private IEnumerator c_MoveTrunaround()
    {
        while (existMissileCnt > 0)
        {
            for (int i = 0; i < missileCnt; i++)
            {
                if (missileArray[i] == null || missileArray[i].activeSelf == false)
                {
                    continue;
                }
                missileArray[i].transform.RotateAround(gameObject.transform.position, Vector3.up, turningSpeed);
            }
            yield return null;
        }
    }
}