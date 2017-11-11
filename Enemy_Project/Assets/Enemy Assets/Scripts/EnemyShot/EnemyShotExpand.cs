using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotExpand : MonoBehaviour
{
    public float detectRangeRadius = 1.5f;
    public Vector3 attackRange = new Vector3(3f, 0.15f, 3f);
    public float expandSizePercent = 0.1f;
    public float expandTime = 0.1f;
    public string targetTag = "Player";

    // Use this for initialization
    private void Start()
    {
        GetComponent<SphereCollider>().radius = detectRangeRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == targetTag)
        {
            StartCoroutine(c_Expand());
        }
    }

    private IEnumerator c_Expand()
    {
        bool checkX = false;
        bool checkZ = false;

        float addSizeX = transform.localScale.x * expandSizePercent;
        float addSizeZ = transform.localScale.z * expandSizePercent;

        while (!checkX || !checkZ)
        {
            if (transform.localScale.x > attackRange.x)
            {
                checkX = true;
            }
            else
            {
                Vector3 tmp = transform.localScale;
                tmp.x += addSizeX;
                transform.localScale = tmp;
            }
            if (transform.localScale.z > attackRange.z)
            {
                checkZ = true;
            }
            else
            {
                Vector3 tmp = transform.localScale;
                tmp.z += addSizeZ;
                transform.localScale = tmp;
            }

            yield return new WaitForSeconds(expandTime);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}