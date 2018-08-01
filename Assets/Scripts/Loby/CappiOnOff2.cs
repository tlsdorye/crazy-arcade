using UnityEngine;
using System.Collections;

public class CappiOnOff2 : MonoBehaviour {

    public GameObject CappiActive;
    public AudioClip ClickSound;
    private AudioSource ClickSource = null;

    //외부 스크립트를 가져온다.
    private MaridOnOff2 GetMarid;
    private DaoOnOff2 GetDao;
    private BazziOnOff2 GetBazzi;

    void Start()
    {
        CappiActive.SetActive(false);
        ClickSource = GetComponent<AudioSource>();

    }

    public void CappiSetActive()
    {
        //MaridButton(2p)에 연결된 MaridOnOff 스크립트의 정보를 가져온다.
        GetMarid = GameObject.Find("MaridButton(2p)").GetComponent<MaridOnOff2>();
        GetDao = GameObject.Find("DaoButton(2p)").GetComponent<DaoOnOff2>();
        GetBazzi = GameObject.Find("BazziButton(2p)").GetComponent<BazziOnOff2>();

        //선택되지 못한 캐릭터는 비활성화 한다.
        if (Global.MaridSelect_2p == true)
        {
            GetMarid.MaridSetActive();
            Global.MaridSelect_2p = false;
        }

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

        CappiActive.SetActive(!CappiActive.active);
        ClickSource.PlayOneShot(ClickSound, 1f);

        //같은캐릭터 중복선택 방지.
        if (Global.CappiSelect_2p == true)
            Global.CappiSelect_2p = false;
        else
        {
            Global.CappiSelect_2p = true;
            Global.SecondPlayer = true;

            SecondPlayerInfo.strCharName = "Cappi";
            SecondPlayerInfo.fSpeed = 3.0f;
            SecondPlayerInfo.iBubbleCount = 1;
            SecondPlayerInfo.iBubbleLengthCount = 2;
        }

    }
}
