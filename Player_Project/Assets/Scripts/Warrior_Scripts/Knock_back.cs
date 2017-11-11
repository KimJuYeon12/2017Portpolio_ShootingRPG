using System;
using UnityEngine;
using System.Collections;

public class Knock_back : MonoBehaviour
{
    Collider Knock_back_col;
    MoveTest Enemy_Move_Scripts;
    Rigidbody My_rb;
    Rigidbody Enemy_rb;

    public void Awake()
    {
        My_rb = GetComponent<Rigidbody>();
        Knock_back_col = GetComponent<Collider>();
    }

    public IEnumerator Knock_back_()
    {
        float i = 0.1f;
        Knock_back_col.enabled = true;
        while (i < 10f)
        {

            //Knock_back_col.transform.localScale = new Vector3(i,i,i);
            i = i + 0.1f;
            yield return null;
        }
        Knock_back_col.enabled = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Enemy") return;
        Enemy_Move_Scripts = other.GetComponent<MoveTest>();
        Enemy_Move_Scripts.Is_Velocity = false;//적의 움직임을 중단시킨다.
        Rigidbody rb = other.GetComponent<Rigidbody>();
        Enemy_rb = rb;
        rb.velocity = Vector3.zero;
        Enemy_rb.AddExplosionForce(500f, transform.position, 5f);
        Debug.Log("aaa");
        Knock_back_col.enabled = false;

        //여기서 코루틴 써서 0.5초올라가고 0.5초기절후 다시 내려오는걸로
        StartCoroutine(After_Collider());
    }

    IEnumerator After_Collider()
    {//여기서 코루틴 써서 0.5초올라가고 0.5초기절후 다시 내려오는걸로
        yield return new WaitForSeconds(0.5f);//0.5초 동안 올라감
        Enemy_rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(1f);//1초기절
        Enemy_rb.velocity = -Vector3.forward;
    }
}


