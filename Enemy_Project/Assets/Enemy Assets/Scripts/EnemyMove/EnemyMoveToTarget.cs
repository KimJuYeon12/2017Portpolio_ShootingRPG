using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveToTarget : MonoBehaviour
{
    private GameObject target;
    private float initTime;

    public float speed = 5f;
    public float waitTime = 1f;
    public float moveTime = 1f;
    public float minDist = 3f;
    public string playerTag = "Player";

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag(playerTag);
    }

    // Use this for initialization
    private void Start()
    {
        StartCoroutine(move());
    }

    private IEnumerator move()
    {
        while (gameObject.activeSelf)
        {
            Vector3 curTargetPos = target.transform.position;
            initTime = Time.time;

            while ((Time.time - initTime) < moveTime)
            {
                if (transform.position.z <= target.transform.position.z + minDist)
                {
                    transform.Translate(-Vector3.forward * speed * Time.deltaTime);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, curTargetPos, speed * Time.deltaTime);
                }
                yield return null;
            }
            yield return new WaitForSeconds(waitTime);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}