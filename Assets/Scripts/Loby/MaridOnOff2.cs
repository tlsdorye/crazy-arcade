using UnityEngine;
using System.Collections;

public class MaridOnOff2 : MonoBehaviour {

    public GameObject MaridActive;
    public AudioClip ClickSound;
    private AudioSource ClickSource = null;

    //외부 스크립트를 가져온다.
    private DaoOnOff2 GetDao;
    private BazziOnOff2 GetBazzi;
    private CappiOnOff2 GetCappi;

    void Start()
    {
        MaridActive.SetActive(false);
        ClickSource = GetComponent<AudioSource>();
    }

    public void MaridSetActive()
    {
        //DaoButton(2p)에 연결된 DaoOnOff 스크립트의 정보를 가져온다.
        GetDao = GameObject.Find("DaoButton(2p)").GetComponent<DaoOnOff2>();
        GetBazzi = GameObject.Find("BazziButton(2p)").GetComponent<BazziOnOff2>();
        GetCappi = GameObject.Find("CappiButton(2p)").GetComponent<CappiOnOff2>();

        //선택되지 못한 캐릭터는 비활성화 한다.
        if (Global.DaoSelect_2p == true)
        {
            GetDao.DaoSetActive();
            Global.DaoSelect_2p = false;
        }

        if(Global.BazziSelect_2p == true)
        {
            GetBazzi.BazziSetActive();
            Global.BazziSelect_2p = false;
        }

        if (Global.CappiSelect_2p == true)
        {
            GetCappi.CappiSetActive();
            Global.CappiSelect_2p = false;
        }

        MaridActive.SetActive(!MaridActive.active);
        ClickSource.PlayOneShot(ClickSound, 1f);

        //같은캐릭터 중복선택 방지.
        if (Global.MaridSelect_2p == true)
			Global.MaridSelect_2p = false;
		else 
		{
			Global.MaridSelect_2p = true;
			Global.SecondPlayer = true;

            SecondPlayerInfo.strCharName = "Marid";
            SecondPlayerInfo.fSpeed = 3.5f;
            SecondPlayerInfo.iBubbleCount = 2;
            SecondPlayerInfo.iBubbleLengthCount = 1;
        }


    }
}
