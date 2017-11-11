using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragableObject : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler {

    float distance;
    public void OnDrag(PointerEventData data)
    {
       // Vector2 deltaMove = data.delta;

        Vector3 halfWidthOffset = new Vector3(transform.lossyScale.x / 2f, 0f,0f);

        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(data.position.x,data.position.y,distance));


        if(Physics.Raycast(transform.position,targetPosition + halfWidthOffset))
        {
            Debug.Log("Deny Move");
        }
        else
        {
            transform.position = targetPosition;
        }
    }

    public void OnBeginDrag(PointerEventData data)
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
    }

    public void OnEndDrag(PointerEventData data)
    {

    }

}
