using UnityEngine;
using System.Collections;

public class MaridOnOff : MonoBehaviour {

    public GameObject MaridActive;
    public AudioClip ClickSound;
    private AudioSource ClickSource = null;

    //외부 스크립트를 가져온다.
    private DaoOnOff GetDao;
    private BazziOnOff GetBazzi;
    private CappiOnOff GetCappi;

    void Start()
    {
        MaridActive.SetActive(false);
        ClickSource = GetComponent<AudioSource>();
    }

    public void MaridSetActive()
    {
        //DaoButton(1p)에 연결된 DaoOnOff 스크립트의 정보를 가져온다.
        GetDao = GameObject.Find("DaoButton(1p)").GetComponent<DaoOnOff>();
        GetBazzi = GameObject.Find("BazziButton(1p)").GetComponent<BazziOnOff>();
        GetCappi = GameObject.Find("CappiButton(1p)").GetComponent<CappiOnOff>();

        //선택되지 못한 캐릭터는 비활성화 한다.
        if (Global.DaoSelect_1p == true)
        {
            GetDao.DaoSetActive();
            Global.DaoSelect_1p = false;
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

        MaridActive.SetActive(!MaridActive.active);
        ClickSource.PlayOneShot(ClickSound, 1f);

        //같은캐릭터 중복선택 방지.
        if (Global.MaridSelect_1p == true)
			Global.MaridSelect_1p = false;
		else 
		{
			Global.MaridSelect_1p = true;
			Global.FirstPlayer = true;

			FirstPlayerInfo.strCharName = "Marid";
			FirstPlayerInfo.fSpeed = 3.5f;
            FirstPlayerInfo.iBubbleCount = 2;
            FirstPlayerInfo.iBubbleLengthCount = 1;
        }


    }
}
