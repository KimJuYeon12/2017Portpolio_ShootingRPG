using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace jiyong{
	public class StageManager : MonoBehaviour {

		InfoManager im;
		public static int stageMax = 4; // 전체 스테이지 종류
		public static int subStageNum = 4; // sub stage 개수
		public static int totalStage = stageMax * 4;

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
			im.loadStage ();

			panelActive (im.activePanelNum);
			stageOpen (im.lastPlayLv);
		}

		// Scene Load시에 기존에 클리어한 스테이지 오픈
		public void stageOpen(int clearLv)
		{
			// 방금 클리어한 스테이지
			if(im.maxClear <= clearLv)
			{
				im.maxClear = clearLv;
				Debug.Log ("NEW STAGE OPEN!!!!!!!!!!!!! :    " + (clearLv + 1));
				im.subStageOn[clearLv + 1] = true;
				// stageOpenEffect();
				//subStageIcon [clearLv + 1].color = Color.white; // 클리어한 다음 맵 오픈

				if((clearLv + 1) % subStageNum == 0) // 다음 스테이지로 넘어가면 스테이지버튼 오픈
					newStageOpen(clearLv + 1);		 // ex) 0, 4, 8, 12.....	
			}
			im.saveStage ();

			// 기존에 이미 클리어된 부분
			for (int i = 0; i <= im.maxClear; i++) 
			{
				Debug.Log ("BRIGHT SUBSTAGE!!!!!!!!!      " + (i+1));
				subStageIcon [i + 1].color = Color.white;

				if(i % subStageNum == 0) 
					newStageOpen(i);
				//newStageOpen(im.maxClear);
			}
			return;
		}

		// stageIcon bright up
		void newStageOpen(int clearLv)
		{
			int num = clearLv / subStageNum;
			Debug.Log (" ! ! ! ! ! !! !NEW STAGE OPEN! ! ! ! ! !! : " + num);
			im.stageOn [num] = true;
			// stageOpenEffect();
			stageIcon [num].GetComponent<Image>().color = Color.white;
		}

		public void panelActive(int num)
		{
			if (num == -1) return;

			else if(im.stageOn[num]) // stageOn is true??
			{
				panel [num].SetActive (true);
				im.setPanel (num);
				//Debug.Log("on panel : " + num);
			}
			return;
		}

		// sub stage select panel off
		public void panelInActive()
		{
			if (im.activePanelNum == -1) return;
			else if (panel [im.activePanelNum].activeSelf) {
				//Debug.Log("off panel : " + im.activePanelNum);

				panel [im.activePanelNum].SetActive (false);
			}
			return;
		}
	}
}
