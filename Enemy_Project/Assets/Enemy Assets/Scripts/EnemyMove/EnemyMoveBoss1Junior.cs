﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveBoss1Junior : MonoBehaviour {
    public Vector3 moveVerticalDist = new Vector3 (0f, 0f, -10f);
    public Vector3 moveHorizontalDist = new Vector3(8f, 0f, 0f);
    private bool checkHorizontal = false;
    private Vector3 initPos;
    public float speed = 10f;

	// Use this for initialization
	void Start () {
        StartCoroutine(cEnemyPattern());
	}

    IEnumerator cEnemyPattern()
    {
        yield return StartCoroutine("cMoveVertical");
        yield return StartCoroutine("cMoveHorizontal");
    }
	
    IEnumerator cMoveVertical()
    {
        initPos = transform.position;

        while (transform.position != (initPos + moveVerticalDist))
        {
            moveVertical();
            yield return null;
        }
    }
    public void moveVertical()
    {
        transform.position = Vector3.MoveTowards(transform.position, initPos + moveVerticalDist, speed * Time.deltaTime);
    }

    IEnumerator cMoveHorizontal()
    {
        initPos = transform.position;

        while (gameObject.activeSelf)
        {
            moveHorizontal();
            yield return null;
        }
    }
       
    public void moveHorizontal()
    {
        if(transform.position == initPos + moveHorizontalDist)
        {
            checkHorizontal = true;
        }
        else if(transform.position == initPos)
        {
            checkHorizontal = false;
        }

        if (!checkHorizontal)
        {
            transform.position = Vector3.MoveTowards(transform.position, initPos + moveHorizontalDist, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, initPos, speed * Time.deltaTime);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
