using System.Collections;
using UnityEngine;

public class EnemyShotToTarget : MonoBehaviour
{
    public string playerTag = "Player";
    private GameObject target;

    public GameObject[] shotSpawn;
    public GameObject guidedMissileObj;

    public int shotNum = 1;
    public float shotReloadTime = 1f;
    public float shotFreq = 3f;
    public float shotFreqTime = 1f;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag(playerTag);
    }

    // Use this for initialization
    private void Start()
    {
        StartCoroutine(TargetAttack());
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private IEnumerator TargetAttack()
    {
        while (gameObject.activeSelf)
        {
            for (int j = 0; j < shotFreq; j++)
            {
                for (int i = 0; i < shotSpawn.Length; i++)
                {
                    ShotToTarget(i);
                }
                yield return new WaitForSeconds(shotFreqTime);
            }

            yield return new WaitForSeconds(shotReloadTime);
        }
    }

    public void ShotToTarget(int num)
    {
        shotSpawn[num].transform.LookAt(target.transform);

        GameObject m = Instantiate(guidedMissileObj, shotSpawn[num].transform.position, shotSpawn[num].transform.rotation);
        m.transform.forward = -m.transform.forward;
    }
}