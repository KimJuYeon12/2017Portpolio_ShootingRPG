using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemymoveBoss2 : MonoBehaviour
    {
        private GameObject[] Boss;
        private GameObject[] shotSpawn;
        public GameObject missile;

        public float horizontalSpeed = 2f;
        public int shotCnt = 5;
        public float shotAngle = 10f;

        public float leftShotDirect = -1f;
        public float rightShotDirect = 1f;

        public float shotTime = 1f;
        public float reloadTime = 2f;

        private Quaternion leftShotInitRotation;
        private Quaternion rightShotInitRotation;

        //tmp////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //public float health = 3;

        // Use this for initialization
        private void Start()
        {
            Boss = new GameObject[2];
            shotSpawn = new GameObject[2];

            Boss[0] = GetChildObject("EnemyBoss2_1(Forest)");
            Boss[1] = GetChildObject("EnemyBoss2_2(Forest)");

            var tmp = Boss[0].transform.GetChild(0);
            shotSpawn[0] = tmp.gameObject;

            tmp = Boss[1].transform.GetChild(0);
            shotSpawn[1] = tmp.gameObject;

            leftShotInitRotation = shotSpawn[0].transform.rotation;
            rightShotInitRotation = shotSpawn[1].transform.rotation;

            StartCoroutine(cBossPattern());
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private IEnumerator cBossPattern()
        {
            yield return StartCoroutine(cMoveHorizontal());
            yield return new WaitForSeconds(1f);
            yield return StartCoroutine(cAttack());
        }

        private IEnumerator cMoveHorizontal()
        {
            bool check1 = true, check2 = true;
            while (check1 || check2)
            {
                check1 = moveHorizontal(Boss[0], "Left");
                check2 = moveHorizontal(Boss[1], "Right");
                yield return null;
            }
        }

        public bool moveHorizontal(GameObject go, string direct)
        { //이동 거리 수정
            if (direct == "Left")
            {
                if (go.transform.position == transform.position + new Vector3(-2f, 0f, 0f))
                {
                    return false;
                }
                go.transform.position = Vector3.MoveTowards(go.transform.position, transform.position + new Vector3(-2f, 0f, 0f), horizontalSpeed * Time.deltaTime);
            }
            else
            {
                if (go.transform.position == transform.position + new Vector3(2f, 0f, 0f))
                {
                    return false;
                }
                go.transform.position = Vector3.MoveTowards(go.transform.position, transform.position + new Vector3(2f, 0f, 0f), horizontalSpeed * Time.deltaTime);
            }

            return true;
        }

        private IEnumerator cAttack()
        {
            //Boss[0].GetComponent<EnemyAttackStraight>().enabled = true;

            while (gameObject.activeSelf)
            {
                shotSpawn[0].transform.rotation = leftShotInitRotation;
                shotSpawn[1].transform.rotation = rightShotInitRotation;

                //Boss[0].GetComponent<EnemyAttackStraight>().enabled = true;

                //Boss[1].GetComponent<EnemyAttackStraight>().enabled = true;

                for (int i = shotCnt; i > 0; i--)
                {
                    //shotSpawn[0].transform.Rotate(0f, leftShotDirect * shotAngle, 0f); //Left
                    //shotSpawn[1].transform.Rotate(0f, rightShotDirect * shotAngle, 0f); //R

                    shotSpawn[0].transform.Rotate(0f, -1 * shotAngle, 0f); //Left
                    shotSpawn[1].transform.Rotate(0f, 1 * shotAngle, 0f); //R

                    Instantiate(missile, shotSpawn[0].transform.position, shotSpawn[0].transform.rotation);
                    Instantiate(missile, shotSpawn[1].transform.position, shotSpawn[1].transform.rotation);

                    yield return new WaitForSeconds(shotTime);

                    //health--;////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }

                //Boss[0].GetComponent<EnemyAttackStraight>().enabled = false;
                //Boss[1].GetComponent<EnemyAttackStraight>().enabled = false;

                yield return new WaitForSeconds(reloadTime);

                //if (health < 0) ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //{
                //    Destroy(gameObject);
                //    health = 0;
                //}
            }
        }

        public GameObject GetChildObject(string name)
        {
            Transform[] tf = GetComponentsInChildren<Transform>();
            foreach (var tmp in tf)
            {
                if (tmp.name == name)
                {
                    return tmp.gameObject;
                }
            }
            return null;
        }
    }
}