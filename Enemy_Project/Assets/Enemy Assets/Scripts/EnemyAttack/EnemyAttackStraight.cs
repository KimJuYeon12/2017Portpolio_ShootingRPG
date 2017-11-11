using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyAttackStraight : EnemyAttack
{
    public int num;
    public float time = 1f;
    public Vector3 dist;

    private void Start()
    {
        StartCoroutine(attack());
    }

    private IEnumerator attack()
    {
        shotSpawn.transform.position = shotSpawn.transform.position - ((float)(num - 1) / 2f * dist);

        while (gameObject.activeSelf)
        {
            for (float i = 0f; i < num; i++)
            {
                var m = Instantiate(missile, shotSpawn.transform.position + (dist * i), shotSpawn.transform.rotation);
            }
            yield return new WaitForSeconds(time);
        }
    }
}