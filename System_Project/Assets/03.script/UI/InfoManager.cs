using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class InfoManager : MonoBehaviour {

	[Serializable]
	public class GameData
	{
		public int money;	// 소지한 게임 머니
		public int crystal;	// 소지한 캐시 머니

		public int stageLv;	// 방금 클리어한 맵의 스테이지 레벨
		public int myStage;	// 플레이할 수 있는 최신 스테이지
		public bool[] subStageOn, stageOn; // 스테이지 오픈 여부

		public int[] warriorSkill, archerSkill, magicianSkill; // 각 직업별 스킬레벨 정보
		public int[] warriorSlot, archerSlot, magicianSlot; // 각 직업별 스킬 슬롯 정보 
															// 어떤 스킬이 어디에 등록?
	}
	string filePath; // gameData 저장 경로

	public int money;
	public int crystal;

	public int stageLv = -1;
	int myStage; // 플레이할 수 있는 최신 스테이지
	public static int stageMax = 4; // 전체 스테이지 종류
	public int subStageNum = 4; // sub stage 개수
	public int totalStage = stageMax * 4; // sub stage로 계산한 전체 스테이지 수
	public bool[] subStageOn, stageOn; // 스테이지 오픈 여부

	public int skillNum = 6; // 직업별 스킬 개수
	public int[] warriorSkill, archerSkill, magicianSkill; // 각 직업별 스킬레벨 정보
	public int[] warriorSlot, archerSlot, magicianSlot; // 각 직업별 스킬슬롯 정보

	public int activePanelNum; // 활성화된 패널 넘버 (스테이지 선택)

	// Use this for initialization
	void Awake () {
		// scene이 바뀌어도 유지
		DontDestroyOnLoad (this.gameObject);
		filePath = Application.persistentDataPath;

		stageOn = new bool[stageMax];
		subStageOn = new bool[totalStage + 1]; // +1 : dummy. array overflow 방지

		skillNum += 1; // arr[1] ~ [n] 사용을 위해서
		warriorSkill = new int[skillNum];
		archerSkill = new int[skillNum];
		magicianSkill = new int[skillNum];

		warriorSlot = new int[skillNum];
		archerSlot = new int[skillNum];
		magicianSlot = new int[skillNum];

		loadMoney ();
		loadSkill();
	}

	public void setPanel(int num)
	{
		activePanelNum = num;
	}

	/*
	 * ===== Save =====
	 * saveMoney -> crystal, money
	 * saveStage -> stageOn, subStageOn, stageLv, myStage
	 * saveSkill -> warriorSkill, warriorSlot .... magicianSlot
	 *
	 * ===== Load =====
	 * loadMoney -> crystal, money
	 * loadStage -> stageOn, subStageOn, stageLv, myStage
	 * loadSkill -> warriorSkill, warriorSlot .... magicianSlot
	 * 
	 */

	public void saveMoney()
	{
		BinaryFormatter formatter = new BinaryFormatter ();
		FileStream file = File.Create (filePath + "/Money.dat");

		GameData data = new GameData ();
		data.crystal = crystal;
		data.money = money;
	
		formatter.Serialize (file, data);
		file.Close ();
		Debug.Log ("saveMoney");
	}

	public void saveStage()
	{
		BinaryFormatter formatter = new BinaryFormatter ();
		FileStream file = File.Create (filePath + "/Stage.dat");

		GameData data = new GameData ();
		data.stageLv = stageLv;
		data.myStage = myStage;

		for (int i = 0; i < stageMax; i++)
			data.stageOn [i] = stageOn [i];
		for (int i = 0; i < totalStage; i++)
			data.subStageOn [i] = subStageOn [i];

		formatter.Serialize (file, data);
		file.Close ();
		Debug.Log ("saveStage");
	}


	public void saveSkill()
	{
		BinaryFormatter formatter = new BinaryFormatter ();
		FileStream file = File.Create (filePath + "/Skill.dat");

		GameData data = new GameData ();

		for (int i = 1; i < skillNum; i++) {
			data.warriorSkill [i] = warriorSkill [i];
			data.archerSkill [i] = archerSkill [i];
			data.magicianSkill [i] = magicianSkill [i];
		}
		for (int i = 1; i < skillNum; i++) {
			data.warriorSlot [i] = warriorSlot [i];
			data.archerSlot [i] = archerSlot [i];
			data.magicianSlot [i] = magicianSlot [i];
		}
		
		formatter.Serialize (file, data);
		file.Close ();
		Debug.Log ("saveSkill");
	}

	public void loadMoney()
	{
		BinaryFormatter formatter = new BinaryFormatter ();

		if (System.IO.File.Exists (filePath + "/Money.dat")) {
			FileStream file = File.Open (filePath + "/Money.dat", FileMode.Open);

			GameData data = (GameData)formatter.Deserialize (file);
			crystal = data.crystal;
			money = data.money;

			file.Close ();
			Debug.Log ("loadMoney");
		} else // 저장된 데이터가 없으면 기본값 세팅
		{
			crystal = 0;
			money = 0;
		}
	}

	public void loadStage()
	{
		BinaryFormatter formatter = new BinaryFormatter ();

		if (System.IO.File.Exists (filePath + "/Stage.dat")) {
			FileStream file = File.Open (filePath + "/Stage.dat", FileMode.Open);

			GameData data = (GameData)formatter.Deserialize (file);
			stageLv = data.stageLv;
			myStage = data.myStage;

			for (int i = 0; i < stageMax; i++)
				data.stageOn [i] = stageOn [i];
			for (int i = 0; i < totalStage; i++)
				data.subStageOn [i] = subStageOn [i];

			file.Close ();
			Debug.Log ("loadStage");
		} else // 저장된 데이터가 없으면 기본값 세팅
		{
			stageOn [0] = true;
			subStageOn[0] = true;
			myStage = 0; 
			//activePanelNum = -1; // default, dummy value
		}
	}

	public void loadSkill()
	{
		BinaryFormatter formatter = new BinaryFormatter ();

		if (System.IO.File.Exists (filePath + "/Skill.dat")) {
			FileStream file = File.Open (filePath + "/Skill.dat", FileMode.Open);

			GameData data = (GameData)formatter.Deserialize (file);

			for (int i = 1; i < skillNum; i++) {
				warriorSkill [i] = data.warriorSkill [i];
				archerSkill [i] = data.archerSkill [i];
				magicianSkill [i] = data.magicianSkill [i];
			}
			for (int i = 1; i < skillNum; i++) {
				warriorSlot [i] = data.warriorSlot [i];
				archerSlot [i] = data.archerSlot [i];
				magicianSlot [i] = data.magicianSlot [i];
			}

			file.Close ();
			Debug.Log ("loadSkill");
		} else // 저장된 데이터가 없으면 기본값 세팅
		{
			for (int i = 1; i < skillNum; i++) {
				warriorSkill [i] = 1;
				archerSkill [i] = 1;
				magicianSkill [i] = 1;
			}
		}
	}
}
