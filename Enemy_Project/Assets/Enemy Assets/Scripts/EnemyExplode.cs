using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyExplode : MonoBehaviour
{
    public GameObject explosion;
    public string playerTag = "Player";
    public float lastTime = 1f;

    // Use this for initialization
    private void Start()
    {
        //Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == playerTag)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        var tmp = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(tmp, lastTime);
    }
}