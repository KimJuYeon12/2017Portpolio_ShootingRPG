using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyPanel : MonoBehaviour {

	InfoManager im;
	Text goldText, crystalText;

	// Use this for initialization
	void Start () {
		im = GameObject.Find ("InfoManager").GetComponent<InfoManager>();
		goldText = GameObject.Find ("GoldText").GetComponent<Text>();
		crystalText = GameObject.Find ("CrystalText").GetComponent<Text>();

		LoadData();
	}
	
	void LoadData()
	{
		im.loadMoney();
		goldText.text = im.money.ToString();
		crystalText.text = im.crystal.ToString();
	}
}
