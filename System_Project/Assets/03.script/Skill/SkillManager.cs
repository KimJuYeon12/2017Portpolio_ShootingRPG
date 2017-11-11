using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour {

	InfoManager im = new InfoManager();
	public static int skillNum = 6;
	public Text[] warrior;
	public Text[] archer;
	public Text[] magician;

	// Use this for initialization
	void Start () {
		im = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
		skillNum = im.skillNum;
		//warrior = new Text[skillNum];
		//archer = new Text[skillNum];
		//magician = new Text[][skillNum];

//		Text[] warriorLV = new Text[warrior.Length];
//		Text[] archerLV = new Text[archer.Length];
//		Text[] magicianLV = new Text[magician.Length];

		for (int i = 1; i < warrior.Length; i++) {
			warrior [i].text = im.warriorSkill [i].ToString();
		}
		for (int i = 1; i < archer.Length; i++) {
			archer [i].text = im.archerSkill [i].ToString();
		}
		for (int i = 1; i < magician.Length; i++) {
			magician [i].text = im.magicianSkill [i].ToString();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
