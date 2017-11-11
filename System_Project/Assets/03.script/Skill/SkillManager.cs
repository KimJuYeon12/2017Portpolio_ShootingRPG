using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour {

	InfoManager im = new InfoManager();
	int skillNum;
	public Text[] warrior;
	public Text[] archer;
	public Text[] magician;
	public Image[] warriorSlot, archerSlot, magicianSlot;
	//int[] warriorSkill_LV, archerSkill_LV, magicianSkill_LV; // 각 직업별 스킬레벨 정보
	//int[] warriorSlot_pos, archerSlot_pos, magicianSlot_pos; // 각 직업별 스킬 슬롯 정보 
															// 어떤 스킬이 어디에 등록?
	void Awake()
	{
		im = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		skillNum = im.skillNum;
		im.loadSkill ();
	}

	// Use this for initialization
	void Start () {
		//warriorSkill_LV = new int[skillNum];
		//archerSkill_LV = new int[skillNum];
	//	magicianSkill_LV = new int[skillNum];
	//	warriorSlot_pos = new int[skillNum];
	//	archerSlot_pos = new int[skillNum];
	//	magicianSlot_pos = new int[skillNum];
		LoadData ();
	}

	void LoadData()
	{
		/*
		for (int i = 1; i < skillNum; i++) {
			warrior [i].text = im.warriorSkill_LV [i].ToString ();
			warriorSkill_LV [i] = im.warriorSkill_LV [i];
			warriorSlot_pos [i] = im.warriorSlot_pos [i];
		}
		for (int i = 1; i < skillNum; i++) {
			archer [i].text = im.archerSkill_LV [i].ToString();
			archerSkill_LV [i] = im.archerSkill_LV [i];
			archerSlot_pos [i] = im.archerSlot_pos [i];
		}
		for (int i = 1; i < skillNum; i++) {
			magician [i].text = im.magicianSkill_LV [i].ToString();
			magicianSkill_LV [i] = archerSkill_LV [i];
			magicianSlot_pos [i] = im.magicianSlot_pos [i];
		}
		*/
		Debug.Log ("load Skill Data ");
		for (int i = 1; i < skillNum; i++) {
			warrior [i].text = im.warriorSkill_LV [i].ToString();
			if(im.warriorSlot_pos[i] == 0) continue; // 0이면 없는 것
			warriorSlot[i].sprite = warrior [im.warriorSlot_pos[i]].transform.GetComponentInParent<Image> ().sprite;
		}
		for (int i = 1; i < skillNum; i++) {
			archer [i].text = im.archerSkill_LV [i].ToString();
			if(im.archerSlot_pos[i] == 0) continue; // 0이면 없는 것
			//archerSlot [i].sprite = archer [im.archerSlot_pos[i]].transform.GetComponentInParent<Image> ().sprite;
			archerSlot[i].sprite = archer [im.archerSlot_pos[i]].transform.GetComponentInParent<Image> ().sprite;
		}
		for (int i = 1; i < skillNum; i++) {
			magician [i].text = im.magicianSkill_LV [i].ToString();
			if(im.magicianSlot_pos[i] == 0) continue; // 0이면 없는 것
			//magicianSlot [i].sprite = magician[im.magicianSlot_pos[i]].transform.GetComponentInParent<Image> ().sprite;
			magicianSlot[i].sprite = magician [im.magicianSlot_pos[i]].transform.GetComponentInParent<Image> ().sprite;
		}
	}
}
