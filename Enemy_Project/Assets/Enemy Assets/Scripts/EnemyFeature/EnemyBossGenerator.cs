using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossGenerator : MonoBehaviour
{
    public GameObject GenerateBoss;
    public int health = 3;

    //private void Start()
    //{
    //    StartCoroutine(c_DecreseHealth());
    //}

    //private IEnumerator c_DecreseHealth()
    //{
    //    while (health > 0)
    //    {
    //        health--;
    //        yield return new WaitForSeconds(1f);
    //    }
    //    Destroy(gameObject);
    //}

    private void OnDestroy()
    {
        Instantiate(GenerateBoss, transform.position, Quaternion.identity);
    }
}