using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace jiyong{
	public class DragCtrl : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler {

		public Canvas canvas;
		GraphicRaycaster gr;
		PointerEventData ped;

		Transform Img;
		private Image EmptyImg;
		Bounds bounds;

		public int[] slot; // 어떤 스킬이 등록되어 있는지 스킬 번호 저장
		int skill_NO;
		//public int[] warriorSkill_LV, archerSkill_LV, magicianSkill_LV; // 각 직업별 스킬레벨 정보
		//public int[] warriorSlot_pos, archerSlot_pos, magicianSlot_pos; // 각 직업별 스킬슬롯 정보

		InfoManager im;
		SkillPanelCtrl spc;
		public int skillNum;

		// Use this for initialization
		void Start () {
			im = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
			spc = GameObject.Find ("SkillManager").GetComponent<SkillPanelCtrl> ();
			skillNum = im.skillNum;

			gr = canvas.GetComponent<GraphicRaycaster> ();
			ped = new PointerEventData (null);
			Img = GameObject.FindGameObjectWithTag ("DragImg").transform;	
			Img.gameObject.SetActive (false);
			EmptyImg = Img.GetComponent<Image> ();
			slot = new int[skillNum];

			//warriorSlot_pos  = new int[skillNum];
			//archerSlot_pos = new int[skillNum];
			//magicianSlot_pos = new int[skillNum];

			//warriorSkill_LV = new int[skillNum];
			//archerSkill_LV = new int[skillNum];
			//magicianSkill_LV = new int[skillNum];
		}

		// 스킬 레벨 업
		public void OnPointerClick(PointerEventData data)
		{
			ped.position = Input.mousePosition;
			List<RaycastResult> res = new List<RaycastResult> ();
			gr.Raycast (ped, res);
			if (res.Count != 0) {
				GameObject obj = res [0].gameObject.transform.parent.gameObject;
				Text lv = res [0].gameObject.GetComponent<Text> ();
				//Debug.Log ("click " + obj.name);

				for (int i = 1; i < skillNum; i++) {
					if (obj.name == "Skill_" + i) {
						skill_NO = int.Parse (obj.name.Substring (6));

						switch (spc._class) {
						case 1:
							++im.warriorSkill_LV[i];
							lv.text = im.warriorSkill_LV [i].ToString();
							break;
						case 2:
							++im.archerSkill_LV[i];
							lv.text = im.archerSkill_LV [i].ToString();
							break;
						case 3:
							++im.magicianSkill_LV[i];
							lv.text = im.magicianSkill_LV[i].ToString();
							break;
						}
						im.saveSkill ();
					}
				}
			}
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
				for (int i = 1; i <= skillNum; i++) 
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
						//Img.gameObject.SetActive (true);
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

			// 해당 위치에 슬롯이 있으면 등록
			ped.position = Input.mousePosition;
			List<RaycastResult> res = new List<RaycastResult> ();
			gr.Raycast (ped, res);
			if (res.Count != 0) 
			{
				GameObject obj = res [0].gameObject;
				//Debug.Log ("hit : " + obj.name);
				for (int i = 1; i <= skillNum; i++) 
				{
					if (obj.name == "Slot_" + i) 
					{
						if(EmptyImg.sprite != null)
						{
							obj.GetComponent<Image> ().sprite = EmptyImg.sprite;
							Debug.Log ("skill link!!!!!!!!!!!");
							switch (spc._class) {
							case 1:
								im.warriorSlot_pos[i] = skill_NO; // Slot[0] ~ Slot[5]
								Debug.Log("w_pos["+i+"] = "+skill_NO);
								break;
							case 2:
								im.archerSlot_pos[i] = skill_NO;
								break;
							case 3:
								im.magicianSlot_pos[i] = skill_NO;
								break;
							}
							im.saveSkill();
							//Debug.Log ("slot["+i+"] = " + skill_NO);
						}
					}
				}
				EmptyImg.sprite = null;
			}
		}
	}

}