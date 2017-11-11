using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyMoveZigzagPos : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRigidbody;
    public Vector3[] turnPoint = new Vector3[3];

    private void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        StartCoroutine(move());
    }

    private IEnumerator move()
    {
        for (int i = 0; i < turnPoint.Length; i++)
        {
            while (transform.position != turnPoint[i])
            {
                transform.position = Vector3.MoveTowards(transform.position, turnPoint[i], speed * Time.deltaTime);
                yield return null;
            }
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