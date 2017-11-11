using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillCtrl : MonoBehaviour, IPointerClickHandler, IEndDragHandler {

	GameManager gm;

	// Use this for initialization
	void Start () {
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}

	// Update is called once per frame
	void Update () {
	}

	// Click Skill
	public void OnPointerClick(PointerEventData data)
	{
		//Debug.Log ("Click : "+transform.name);
		int btnNum =  GetComponent<SkillButton>().buttonNum;
		Skill(btnNum);
		Debug.Log ("Click Skill On : Skill"+ btnNum);
	}

	// Drag Skill
	public void OnEndDrag(PointerEventData data)
	{
		if(Input.mousePosition.y >= 200)
		{
			// Drag Skill 발동 범위 체크용
			//Debug.Log ("Y position : " + Input.mousePosition.y);
			int btnNum =  GetComponent<SkillButton>().buttonNum;
			Debug.Log ("Drag Skill On : Skill"+ (btnNum + 4));
		}
	}

	void Skill(int btnNum)
	{
		if (btnNum == 1) {
			gm.destoryBlcok (3);
		}
		if (btnNum == 2) {
			gm.destoryBlcok (3);
		}
		if (btnNum == 3) {
			gm.destoryBlcok (3);
		}
		if (btnNum == 4) {
			gm.destoryBlcok (3);
		}
	}

}

