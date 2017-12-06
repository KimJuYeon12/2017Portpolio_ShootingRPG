using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace jiyong{
	public class GameManager : MonoBehaviour {

		public int maxTime = 30; // test용 원래는 120
		public int height = 20; // test용 미정

		public InfoManager im;
		public Text manaText;
		public int mana;
		public float currentTime;
		public Image timerBar;
		public GameObject block;
		public Transform player;

		SortedDictionary<int, GameObject> dic = new SortedDictionary<int, GameObject>();

		void Awake(){
			im = GameObject.Find("InfoManager").GetComponent<InfoManager>();
			spawnPlayer (im.playerType);
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
			currentTime = maxTime;
			setSkillImage (); // 직업 & 스킬등록에 따른 스킬슬롯 이미지 변경
		}

		void Update () {
			manaText.text = mana.ToString ();
			UpdateTimer ();
		}

		void setSkillImage() {
			im.loadSkill ();
			Image[] SkillBtn = new Image[3];
			SkillBtn [0] = GameObject.Find ("Skill").GetComponent<Image> ();
			SkillBtn [1] = GameObject.Find ("Skill (1)").GetComponent<Image> ();
			SkillBtn [2] = GameObject.Find ("Skill (2)").GetComponent<Image> ();

			Sprite[] icon = new Sprite[7];
			switch (im.playerType) { /// 이미지 변경 후 수정할 것
			case 1: // 전사
				icon [1] = Resources.Load<Sprite> ("SkillIcon/1");
				icon [2] = Resources.Load<Sprite> ("SkillIcon/2");
				icon [3] = Resources.Load<Sprite> ("SkillIcon/3");
				icon [4] = Resources.Load<Sprite> ("SkillIcon/4");
				icon [5] = Resources.Load<Sprite> ("SkillIcon/5");
				icon [6] = Resources.Load<Sprite> ("SkillIcon/6");

				// pos >> 1, 2, 3 : 클릭 스킬 // 4, 5, 6 : 터치 스킬
				SkillBtn[0].sprite = icon[im.warriorSlot_pos[1]];
				SkillBtn[1].sprite = icon[im.warriorSlot_pos[2]];
				SkillBtn[2].sprite = icon[im.warriorSlot_pos[3]];
				break;
			case 2: // 궁수
				icon [1] = Resources.Load<Sprite> ("SkillIcon/1");
				icon [2] = Resources.Load<Sprite> ("SkillIcon/2");
				icon [3] = Resources.Load<Sprite> ("SkillIcon/3");
				icon [4] = Resources.Load<Sprite> ("SkillIcon/4");
				icon [5] = Resources.Load<Sprite> ("SkillIcon/5");
				icon [6] = Resources.Load<Sprite> ("SkillIcon/6");

				// pos >> 1, 2, 3 : 클릭 스킬 // 4, 5, 6 : 터치 스킬
				SkillBtn [0].sprite = icon [im.archerSlot_pos[1]];
				SkillBtn [1].sprite = icon [im.archerSlot_pos[2]];
				SkillBtn [2].sprite = icon [im.archerSlot_pos[3]];
				break;
			case 3: // 마법사
				icon [1] = Resources.Load<Sprite> ("SkillIcon/1");
				icon [2] = Resources.Load<Sprite> ("SkillIcon/2");
				icon [3] = Resources.Load<Sprite> ("SkillIcon/3");
				icon [4] = Resources.Load<Sprite> ("SkillIcon/4");
				icon [5] = Resources.Load<Sprite> ("SkillIcon/5");
				icon [6] = Resources.Load<Sprite> ("SkillIcon/6");

				// pos >> 1, 2, 3 : 클릭 스킬 // 4, 5, 6 : 터치 스킬
				SkillBtn [0].sprite = icon [im.magicianSlot_pos[1]];
				SkillBtn [1].sprite = icon [im.magicianSlot_pos[2]];
				SkillBtn [2].sprite = icon [im.magicianSlot_pos[3]];
				break;
			}
		}

		// num개만큼 상단 블럭 삭제 // 스킬 사용 시 호출
		public void destoryBlcok(int num)
		{
			//  블럭 부족하므로 중단
			if (dic.Count < num) {
				Debug.Log ("자원이 부족합니다.");
				return;
			}
			GameObject obj;

			for (int h = height; h >= 0; h--) 
			{
				// key가 7인 값이 존재 or num이 0이 아닐때
				for (int key = height * 10 - 1; key >= 0; key--) 
				{
					// 스킬에 소모되는 블럭 수만큼 반복
					if (num == 0)	break; 
					if (dic.ContainsKey (key)) {
						Debug.Log ("블럭 제거! key : " + key);
						dic.TryGetValue (key, out obj);
						dic.Remove (key);
						num--;
						mana--;
						DestroyObject (obj);
						obj = null;
					}
				}
			}
			return;
		}

		public void stackBlock(int key, GameObject obj)
		{
			Debug.Log ("자원 등록! key : " + key);
			dic.Add (key, obj);
		}

		/* createBlock 원본
	 //몬스터가 죽으면 호출 // obj : moster
	public void createBlock(GameObject obj)
	{
		Debug.Log ("create block");
		Vector3 pos = obj.transform.position;
		Destroy (obj);
		Instantiate(block, new Vector3(Mathf.Round(pos.x),0,pos.z), Quaternion.identity);


		//GameObject prefab = Resources.Load ("Prefabs/Block") as GameObject;
		//GameObject block = MonoBehaviour.Instantiate (prefab) as GameObject;
		//block.transform = new Vector3(Mathf.Round(death.x), 0, death.z);
	}
	*/
		private void spawnPlayer (int type) 
		{
			Debug.Log ("Player SPAWN !@!$!@%!%!");
			switch (type) 
			{
			case 1: // 전사
				Instantiate(Resources.Load ("Player 1") as GameObject); // 프리팹에서 오브젝트 가져오기

				break;
			case 2: // 궁수
				Instantiate(Resources.Load ("Player 2") as GameObject); // 프리팹에서 오브젝트 가져오기
				break;
			case 3: // 마법사
				Instantiate(Resources.Load ("Player 3") as GameObject); // 프리팹에서 오브젝트 가져오기
				break;
			default: // defalut // 오류값일때
				Instantiate(Resources.Load ("Player 1") as GameObject); // 프리팹에서 오브젝트 가져오기
				break;
			}
		}
		// 테스트용 임시 함수
		public void createBlock(Vector3 EnemyPos)
		{
			Vector3 pos = EnemyPos;
			Instantiate(block, new Vector3(Mathf.Round(pos.x),0,pos.z), Quaternion.identity);
			mana++;
		}

		public void stageClear()
		{
			im.saveStage (); // 스테이지에 넘어올 때 im에 기록한 lastPlayLv을 데이터로 저장
			// getMoney(); // 스테이지에 따른 자원 획득

			SceneManager.LoadScene ("Adventure");
		}

		// 스테이지에 따른 자원 획득
		void getMoney(){ 
			//im.money += ;
			//im.crystal += ;
			// im.saveMoney();
		}

		void gameOver()	{
			Debug.Log ("game OVer!!!!!!!!!!!!!!!!!!!!!!!!!!");
		}

		private void UpdateTimer() {
			if (currentTime > 0) 
			{
				currentTime = (currentTime - (Time.deltaTime));

				timerBar.fillAmount = currentTime / maxTime;
				//timerBar.color = Color.Lerp (new Color(1,0,0), new Color(0,1,0), currentTime / maxTime);

				if ((currentTime / maxTime) < 0.20) // 20% red bar
					timerBar.color = Color.red;
				else if((currentTime / maxTime) < 0.5) // 50% yellow bar
					timerBar.color = Color.yellow;
			}
			else // time == 0
				gameOver();
		}
	}

}