using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyAttackRotate : EnemyAttack
{
    public int num;
    public float time;
    public Vector3 dist;
    public Vector3 rotationAdd;

    private void Awake()
    {
        StartCoroutine(attack());
    }

    private IEnumerator attack()
    {
        //shotSpawn.transform.position = shotSpawn.transform.position - ((float)(num - 1) / 2f * dist);

        //shotSpawn.transform.rotation.Set(rotateAddX, 0f, rotateAddZ, 0f);
        shotSpawn.transform.Rotate(rotationAdd * (float)(num - 1) / 2f);
        Quaternion initRoation = shotSpawn.transform.rotation;

        while (gameObject.activeSelf)
        {
            for (float i = 0f; i < num; i++)
            {
                Instantiate(missile, shotSpawn.transform.position/* + (dist * i)*/, shotSpawn.transform.rotation);
                shotSpawn.transform.Rotate(rotationAdd);
            }
            shotSpawn.transform.rotation = initRoation;
            yield return new WaitForSeconds(1f);
        }
    }
}