using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class __dragCtrl : MonoBehaviour{
	/*
	public Canvas canvas;
	GraphicRaycaster gr;
	PointerEventData ped;

	InfoManager im;
	SkillPanelCtrl spc;

	Transform Img;
	private Image EmptyImg;
	Bounds bounds;

	public int[] slot; // 어떤 스킬이 등록되어 있는지 스킬 번호 저장
	int skill_NO;
	public int[] warriorSlot, archerSlot, magicianSlot; // 각 직업별 스킬슬롯 정보

	// Use this for initialization
	void Start () {
		im = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		spc = GameObject.Find ("SkillManager").GetComponent<SkillPanelCtrl> ();

		gr = canvas.GetComponent<GraphicRaycaster> ();
		ped = new PointerEventData (null);
		Img = GameObject.FindGameObjectWithTag ("DragImg").transform;	
		Img.gameObject.SetActive (false);
		EmptyImg = Img.GetComponent<Image> ();

		slot = new int[im.SkillNum];
		warriorSlot = new int[im.SkillNum];
		archerSlot = new int[im.SkillNum];
		magicianSlot = new int[im.SkillNum];
	}

	private bool IsInPanel(Vector3 pos)
	{
		pos.z = bounds.center.z;
		return bounds.Contains (pos);
	}

	public void OnPointerClick(PointerEventData data)
	{
		// 스킬 레벨 업
		//if (Input.GetMouseButtonDown (0)) 
		//{
		//	//gameObject.GetComponentInChildren<Text> ().text = .ToString();
		//	return;
		//}
		Debug.Log("fsf");
	}

	public void OnBeginDrag(PointerEventData data)
	{
		ped.position = Input.mousePosition;
		List<RaycastResult> res = new List<RaycastResult> ();
		gr.Raycast (ped, res);
		if (res.Count != 0) 
		{
			GameObject obj = res [0].gameObject.transform.parent.gameObject;
			//Debug.Log ("hit : " + obj.name);
			for (int i = 1; i <= 6; i++) 
			{
				if (obj.name == "Skill_" + i) 
				{
					EmptyImg.sprite = obj.GetComponent<Image> ().sprite;
					skill_NO = int.Parse (obj.name.Substring (6)); // Skill_i
					//Debug.Log (skill_NO.ToString ());

					float size = obj.transform.GetComponent<RectTransform> ().sizeDelta.x;
					EmptyImg.rectTransform.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, size);
					EmptyImg.rectTransform.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, size);
					EmptyImg.gameObject.SetActive (true);
				}
			}
		}
	}

	public void OnDrag(PointerEventData data)
	{
		Img.transform.position = Input.mousePosition;
	}

	public void OnEndDrag(PointerEventData data)
	{	
		EmptyImg.gameObject.SetActive (false);
		skill_NO = 0;
		// 해당 위치에 슬롯이 있으면 등록
		ped.position = Input.mousePosition;
		List<RaycastResult> res = new List<RaycastResult> ();
		gr.Raycast (ped, res);
		if (res.Count != 0) 
		{
			GameObject obj = res [0].gameObject;
			//Debug.Log ("hit : " + obj.name);
			for (int i = 1; i <= 6; i++) 
			{
				if (obj.name == "Slot_" + i) 
				{
					if(EmptyImg.sprite != null)
					{
						obj.GetComponent<Image> ().sprite = EmptyImg.sprite;
						EmptyImg.sprite = null;
						switch (spc._class) 
						{
						case 1:
							warriorSlot[i-1] = skill_NO; // Skill_i
							break;
						case 2:
							archerSlot[i-1] = skill_NO; // Skill_i
							break;
						case 3:
							magicianSlot[i-1] = skill_NO; // Skill_i
							break;
						default:
							break;
						}
						//Debug.Log ("slot["+i+"] = " + skill_NO);
					}
				}
			}
		}
	}
	*/
}
