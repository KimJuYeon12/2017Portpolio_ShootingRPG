using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	//public int maxTime = 120;
	public int maxTime = 30; // test용 원래는 120
	public int height = 20; // test용 미정

	public InfoManager info;
	public int lv;
	public Text manaText;
	public int mana;
	public float currentTime;
	public Image timerBar;
	public GameObject block;

	public GameObject player;
	SortedDictionary<int, GameObject> dic = new SortedDictionary<int, GameObject>();

	// Use this for initialization
	void Start () {
		info = GameObject.Find("InfoManager").GetComponent<InfoManager>();
		currentTime = maxTime;
	}
	
	// Update is called once per frame
	void Update () {
		//timeInfo.text = time.ToString("####");
		manaText.text = mana.ToString ();
		UpdateTimer ();
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

	// 테스트용 임시 함수
	public void createBlock()
	{
		Vector3 pos = player.transform.position;
		Instantiate(block, new Vector3(Mathf.Round(pos.x),0,pos.z + 10), Quaternion.identity);
		mana++;
	}

	public void stageClear()
	{
		Debug.Log ("clear stage : " + lv);
		info.stageLv = lv;
		SceneManager.LoadScene ("Adventure");
	}

	void gameOver()
	{
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
