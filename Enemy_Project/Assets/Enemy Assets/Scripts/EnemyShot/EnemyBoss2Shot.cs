using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyBoss2Shot : MonoBehaviour
{
    //aiming 동안 missile2 회전 시키기, 2048 coroutine 밑에 시간당 움직임 참고하기
    private GameObject target;

    public string targetTag = "Player";
    public LayerMask exceptLayerMask;

    public GameObject missile1;
    public GameObject missile2;
    public float missile1Speed = 20f;
    public float missile2Speed = 20f;
    public float withdrawSpeed = 50f;
    public float speed = 2f;

    private float dist;
    private float min = 100000f;
    private LineRenderer targetLine;
    private Rigidbody missile2Rb;
    private float aimingTIme = 2f;
    private float initTIme;

    public float aimWaitTime = 1f;
    public float shotTime = 1f;
    public float attackWaitTIme = 1f;

    public Quaternion targetRotation;
    public float rotateSmooth = 0.03f;

    private RaycastHit hit;

    private void Awake()
    {
        Physics.gravity = new Vector3(0f, 0f, -9.8f);
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        targetLine = GetComponent<LineRenderer>();
        missile2Rb = GetComponent<Rigidbody>();
        //missile1 = getChildObj("Missile1");
        //missile2 = getChildObj("Missile2");

        targetRotation = missile2.transform.rotation;
        targetRotation *= Quaternion.AngleAxis(90, Vector3.up);

        StartCoroutine(cAttack());
    }

    private IEnumerator cAttack()
    {
        while (gameObject.activeSelf)
        {
            yield return StartCoroutine(cAiming());

            yield return StartCoroutine("cShot");

            yield return StartCoroutine("cTurnShot");

            yield return StartCoroutine("cWithdraw");

            yield return new WaitForSeconds(attackWaitTIme);
        }
    }

    private IEnumerator cAiming()
    {
        initTIme = Time.time;
        targetLine.enabled = true;
        while (Time.time - initTIme < aimingTIme)
        {
            aiming();
            rotating();
            yield return null;
        }
        yield return new WaitForSeconds(aimWaitTime);
        targetLine.enabled = false;
    }

    public void aiming()
    {
        missile1.transform.LookAt(target.transform.position);

        targetLine.SetPosition(0, transform.position);
        targetLine.SetPosition(1, missile1.transform.forward * 50f);
    }

    public void rotating()
    {
        //Debug.Log(Quaternion.Angle(Quaternion.Euler(0f, 90f, 0f), Quaternion.Euler(0f, 0f, 0f)));
        ////Debug.Log(missile2.transform.rotation.y + " " + (transform.rotation.y + 90f));
        //if (missile2.transform.rotation.y < transform.rotation.y * 90f)
        //{
        //    missile2.transform.Rotate(0f, rotateSmooth, 0f);
        //}
        //missile2.transform.rotation = Quaternion.Lerp(missile2.transform.rotation, targetRotation, rotateSmooth * Time.deltaTime);

        missile2.transform.rotation = Quaternion.Slerp(missile2.transform.rotation, Quaternion.Euler(0f, 96.5f, 0f), rotateSmooth);
        //if (missile2.transform.rotation != Quaternion.Euler(0f, 90f, 0f))
        //{
        //}
        //Quaternion.Euler(0f, 90f, 0f);
        //missile2 Quaternion.Slerp(Quaternion.identity, Quaternion.Euler(0f, 90f, 0f), 3f);
    }

    private IEnumerator cShot()
    {
        Physics.Raycast(targetLine.GetPosition(0), missile1.transform.forward, out hit, Mathf.Infinity, ~exceptLayerMask);

        while (shot())
        {
            yield return null;
        }
    }

    public bool shot()
    {
        missile1.transform.position = Vector3.MoveTowards(missile1.transform.position, hit.point, missile1Speed * Time.deltaTime);
        if (missile1.transform.position == hit.point)
        {
            return false;
        }
        return true;
    }

    private IEnumerator cTurnShot()
    {
        dist = 20f;

        //missile2Target.transform.localPosition += new Vector3(0f, 0f, dist);
        //Debug.Log(missile2Target.transform.localPosition);
        Vector3 destPos = transform.position;
        destPos.z += dist;

        while (turnShotVertical(destPos))
        {
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        missile2.transform.rotation = Quaternion.identity;
        if (target.transform.position.x > missile1.transform.position.x)
        {
            missile2.transform.position = new Vector3(missile1.transform.position.x + 10f, missile1.transform.position.y, missile1.transform.position.z);
        }
        else
        {
            missile2.transform.position = new Vector3(missile1.transform.position.x - 10f, missile1.transform.position.y, missile1.transform.position.z);
        }

        while (turnShotHorizontal())
        {
            yield return null;
        }
    }

    public bool turnShotVertical(Vector3 destPos)
    {
        missile2.transform.position = Vector3.MoveTowards(missile2.transform.position, destPos, missile2Speed * Time.deltaTime);
        if (missile2.transform.position == destPos)
        {
            return false;
        }
        return true;
    }

    public bool turnShotHorizontal()
    {
        missile2.transform.position = Vector3.MoveTowards(missile2.transform.position, missile1.transform.position, missile2Speed * Time.deltaTime);
        if (missile2.transform.position == missile1.transform.position)
        {
            return false;
        }

        return true;
    }

    private IEnumerator cWithdraw()
    {
        while (withdraw())
        {
            yield return null;
        }
    }

    public bool withdraw()
    {
        missile1.transform.position = Vector3.MoveTowards(missile1.transform.position, transform.position, withdrawSpeed * Time.deltaTime);
        missile2.transform.position = Vector3.MoveTowards(missile1.transform.position, transform.position, withdrawSpeed * Time.deltaTime);

        if (missile1.transform.position == transform.position && missile2.transform.position == transform.position)
        {
            //missile2.transform.rotation = Quaternion.identity;
            return false;
        }
        return true;
    }

    public void idleMotion()
    {
        missile1.transform.RotateAround(transform.position, Vector3.down, speed * Time.deltaTime);
        missile2.transform.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);
    }

    public GameObject getChildObj(string name)
    {
        Transform[] tmp = GetComponentsInChildren<Transform>();

        foreach (var obj in tmp)
        {
            if (obj.name == name)
            {
                return obj.gameObject;
            }
        }

        return null;
    }
}