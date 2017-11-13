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

	void Awake()
	{
		im = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		im.loadSkill ();
		skillNum = im.skillNum;
	}

	// Use this for initialization
	void Start () {

		LoadData ();
	}

	void LoadData()
	{
		for (int i = 1; i < skillNum; i++) {
			warrior [i].text = im.warriorSkill_LV [i].ToString();
			if(im.warriorSlot_pos[i] == 0) continue; // 0이면 없는 것
			warriorSlot[i].sprite = warrior [im.warriorSlot_pos[i]].transform.GetComponentInParent<Image> ().sprite;
		}
		for (int i = 1; i < skillNum; i++) {
			archer [i].text = im.archerSkill_LV [i].ToString();
			if(im.archerSlot_pos[i] == 0) continue; // 0이면 없는 것
			archerSlot[i].sprite = archer [im.archerSlot_pos[i]].transform.GetComponentInParent<Image> ().sprite;
		}
		for (int i = 1; i < skillNum; i++) {
			magician [i].text = im.magicianSkill_LV [i].ToString();
			if(im.magicianSlot_pos[i] == 0) continue; // 0이면 없는 것
			magicianSlot[i].sprite = magician [im.magicianSlot_pos[i]].transform.GetComponentInParent<Image> ().sprite;
		}
	}
}
