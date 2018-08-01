using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

	GameObject GameStart;
	public AudioClip ClickSound;
	private AudioSource ClickSource = null;

	// Use this for initialization
	void Start () 
	{
		ClickSource = GetComponent<AudioSource>();
	}

	public void GameStartFunc()
	{
		//플레이어의 캐릭터 선택이 완료되어야 스타트 버튼이 작동하게 한다.
		if (Global.FirstPlayer == true && Global.SecondPlayer == true) 
		{
			ClickSource.PlayOneShot (ClickSound, 1f);

			//코루틴으로 2초뒤에 씬이동을 실행한다.
			StartCoroutine (delayTime (2.0f));      //멤버변수는 초단위 시간
		}
	}

	IEnumerator delayTime(float fSec)
	{
		yield return new WaitForSeconds (fSec);

        //2초가 지나면 다시 실행되며 ForestMap 씬으로 이동한다.
        SceneManager.LoadScene("ShipMap");
	}

}
