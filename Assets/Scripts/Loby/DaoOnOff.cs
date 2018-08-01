using UnityEngine;
using System.Collections;

public class DaoOnOff : MonoBehaviour {

    public GameObject DaoActive;
    public AudioClip ClickSound;
    private AudioSource ClickSource = null;

    //외부 스크립트를 가져온다.
    private MaridOnOff GetMarid;
    private BazziOnOff GetBazzi;
    private CappiOnOff GetCappi;

    void Start()
    {
        DaoActive.SetActive(false);
        ClickSource = GetComponent<AudioSource>();

    }

    public void DaoSetActive()
    {
        //MaridButton(1p)에 연결된 MaridOnOff 스크립트의 정보를 가져온다.
        GetMarid = GameObject.Find("MaridButton(1p)").GetComponent<MaridOnOff>();
        GetBazzi = GameObject.Find("BazziButton(1p)").GetComponent<BazziOnOff>();
        GetCappi = GameObject.Find("CappiButton(1p)").GetComponent<CappiOnOff>();

        //선택되지 못한 캐릭터는 비활성화 한다.
        if (Global.MaridSelect_1p == true)
        {
            GetMarid.MaridSetActive();
            Global.MaridSelect_1p = false;
        }

        if(Global.BazziSelect_1p == true)
        {
            GetBazzi.BazziSetActive();
            Global.BazziSelect_1p = false;
        }

        if (Global.CappiSelect_1p == true)
        {
            GetCappi.CappiSetActive();
            Global.CappiSelect_1p = false;
        }


        DaoActive.SetActive(!DaoActive.active);
        ClickSource.PlayOneShot(ClickSound, 1f);

        //같은캐릭터 중복선택 방지.
		if (Global.DaoSelect_1p == true)
			Global.DaoSelect_1p = false;
		else 
		{
			Global.DaoSelect_1p = true;
			Global.FirstPlayer = true;

			FirstPlayerInfo.strCharName = "Dao";
			FirstPlayerInfo.fSpeed = 4.0f;
            FirstPlayerInfo.iBubbleCount = 1;
            FirstPlayerInfo.iBubbleLengthCount = 1;
        }

    }
}
