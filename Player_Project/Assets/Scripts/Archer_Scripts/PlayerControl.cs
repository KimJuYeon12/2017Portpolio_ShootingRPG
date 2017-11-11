using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed = 10f;
    public float moveLimit = 400f;
    public float gravity = 1f;
    public float jumpPower = 5f;
    public bool jumpDelay;

    private Vector3 initMousePos;
    public float touchDelay;
    private float firstTouchTime;
    private bool firstTouch;
    public Rigidbody rb;
    
    void Awake()
    {
        touchDelay = 1f;
    }

    // Use this for initialization
    void Start()
    {
        jumpDelay = false;
        firstTouch = false;
        //rb.gravityScale = gravity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))//마우스 버튼을 눌렀을 시(왼쪽이 0오른쪽이 1 중간이 2)
        {
            // touch
            initMousePos = Input.mousePosition;
            initMousePos.z = 10;
            initMousePos = Camera.main.ScreenToWorldPoint(initMousePos);
            
            if (!firstTouch)//첫 터치시 들어옴
            {
                Debug.Log("첫터치다");
                firstTouchTime = Time.time;
                firstTouch = true;
            }


            else if (firstTouch && !jumpDelay) // double Touch//////// 첫 터치가 아니고 점프딜레이가 아닐때
            {
                Debug.Log("Double Click!");
                rb.AddForce(new Vector3(0f, 0f,jumpPower), ForceMode.Impulse);
                jumpDelay = true;
            }
        }

        if (firstTouch && ((Time.time - firstTouchTime) > touchDelay))//첫터치를 한 상태에서 일정시간이 지나면 다시 첫터치를 안한걸로
        {
            Debug.Log("왼쪽 = "+ (Time.time - firstTouchTime) +"오른쪽 = "+ touchDelay);
            //Debug.Log("Time.time = " + Time.time);
            //Debug.Log("firstTouchTime = " + firstTouchTime);


            Debug.Log("여기 계속 들어감");
            firstTouch = false;
        }



        if (Input.GetMouseButton(0))
        {


            // drag
            Vector3 worldPoint = Input.mousePosition;
            worldPoint.z = 10;
            worldPoint = Camera.main.ScreenToWorldPoint(worldPoint);
           
            Vector3 diffPos = worldPoint - initMousePos;//두개의 벡터값을 동시에 받아서 그 차이를 뺀 벡터
            diffPos.z = 0;
            diffPos.y = 0;

            initMousePos = Input.mousePosition;
            initMousePos.z = 10;
            initMousePos = Camera.main.ScreenToWorldPoint(initMousePos);

            //UnityEngine.Debug.Log("trigger Exit");
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x + diffPos.x, -moveLimit, moveLimit), 
            //                                 transform.position.y, transform.position.z);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x + diffPos.x, -5, 5),
                                             transform.position.y, transform.position.z);
        }
        /*
        if (jumpDelay) 
        {
           // 점프 중일때 점점 떨어짐
           transform.Translate(0, -(gravity * Time.deltaTime), 0);
        }
        */

        // test용 // 플레이어 낙하 방지 코드
        //if (transform.position.y < -6f)
        //{
        //    transform.transform.position = new Vector2(transform.position.x, -2f);
        //}
    }
    void Update()
    {

    }
}