using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotRandom : MonoBehaviour {
    public GameObject missile;
    public float shotTime = 1f;
    public float shotNum = 3f;

	// Use this for initialization
	void Start () {
        StartCoroutine(attack());
    }

    IEnumerator attack()
    {
        float randomXMin = transform.position.x - transform.localScale.x / 2;
        float randomXMax = transform.position.x + transform.localScale.x / 2;
        float randomZ = transform.position.z + transform.localScale.z / 2;

        while (gameObject.activeSelf)
        {            
            for(int i = 0; i < shotNum; i++)
            {
                Vector3 shotPos = new Vector3(Random.Range(randomXMin, randomXMax), 0f, randomZ);
                Instantiate(missile, shotPos, Quaternion.identity);
            }
            
            yield return new WaitForSeconds(shotTime);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
