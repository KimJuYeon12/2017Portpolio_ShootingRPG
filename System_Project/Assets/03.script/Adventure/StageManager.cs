using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StageManager : MonoBehaviour {

	public InfoManager im;
	public static int stageMax = 4; // 전체 스테이지 종류
	public static int subStageNum = 4; // sub stage 개수
	public static int totalStage = stageMax * 4;

	static int myStage; // 플레이할 수 있는 최신 스테이지
	public bool[] subStageOn;
	public bool[] stageOn;
	public int activePanelNum;

	/*
	enum Stage : int{
		stage_1 = 1, stage_2, stage_3, stage_4,  //field
		stage_5, stage_6, stage_7, stage_8, 	 //fire
		stage_9, stage_10, stage_11, stage_12,	 //forest
		stage_13, stage_14, stage_15, stage_16,	 //snow
	};
	*/

	public GameObject[] stageIcon = new GameObject[stageMax]; // stage image
	public Image[] subStageIcon = new Image[totalStage]; // sub_stage array
	public GameObject[] panel = new GameObject[stageMax]; // sub_stage select panel

	// Use this for initialization
	void Start () 
	{
		im = GameObject.Find("InfoManager").GetComponent<InfoManager>();

		subStageOn = im.subStageOn;
		stageOn = im.stageOn;
		activePanelNum = im.activePanelNum;

		panelActive (activePanelNum);
		stageClear (im.stageLv);
	}

	public void panelActive(int num)
	{
		if (num == -1) return;

		else if(stageOn[num]) // stageOn is true??
		{
			panel [num].SetActive (true);
			im.setPanel (num);
			Debug.Log("on panel : " + num);
		}
		return;
	}

	// sub stage select panel off
	public void panelInActive()
	{
		if (activePanelNum == -1) return;
		else if (panel [activePanelNum].activeSelf) {
			Debug.Log("off panel : " + activePanelNum);

			panel [activePanelNum].SetActive (false);
		}
		return;
	}

	// stageLv : clear한 stage의 Lv info
	public void stageClear(int stageLv)
	{
		Debug.Log ("stage clear! : " + stageLv);

		myStage = stageLv + 1;
		if (!subStageOn [myStage]) 
		{
			subStageOn [myStage] = true;
											  // next field open
			if ((myStage % subStageNum) == 0) // 0, 4, 8, 12 ...
			newStageOpen (myStage);
		}

		for (int i = 0; i <= myStage; i++) {
			subStageIcon [i].color = new Color (1, 1, 1);
		}
		return;
	}

	// stageIcon bright up
	void newStageOpen(int myLv)
	{
		int num = myLv / subStageNum;
		Debug.Log ("NEW STAGE OPEN!! : " + num);
		stageOn [num] = true;
		stageIcon [num].GetComponent<Image>().color = new Color (1, 1, 1);
	}
}
