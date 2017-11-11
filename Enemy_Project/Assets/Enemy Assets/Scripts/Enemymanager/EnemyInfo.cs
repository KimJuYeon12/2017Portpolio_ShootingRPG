using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public float maxHealth = 10f;
    private float curHealth;
    public float damage = 10f;

    // Use this for initialization
    private void Start()
    {
        curHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        curHealth -= damage;
        if (curHealth < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Outer")
        {
            Destroy(gameObject);
        }
    }
}