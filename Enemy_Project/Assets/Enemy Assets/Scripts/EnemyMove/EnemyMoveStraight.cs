using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveStraight : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 1f;
    public string outerTagName = "Outer";

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        //rb.transform.Rotate(new Vector3(0f, 10f, 0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == outerTagName)
        {
            Destroy(gameObject, 3f);
        }
    }
}