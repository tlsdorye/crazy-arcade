using UnityEngine;
using System.Collections;

public class BazziOnOff2 : MonoBehaviour {

    public GameObject BazziActive;
    public AudioClip ClickSound;
    private AudioSource ClickSource = null;

    //외부 스크립트를 가져온다.
    private MaridOnOff2 GetMarid;
    private DaoOnOff2 GetDao;
    private CappiOnOff2 GetCappi;

    void Start()
    {
        BazziActive.SetActive(false);
        ClickSource = GetComponent<AudioSource>();

    }

    public void BazziSetActive()
    {
        //MaridButton(1p)에 연결된 MaridOnOff 스크립트의 정보를 가져온다.
        GetMarid = GameObject.Find("MaridButton(2p)").GetComponent<MaridOnOff2>();
        GetDao = GameObject.Find("DaoButton(2p)").GetComponent<DaoOnOff2>();
        GetCappi = GameObject.Find("CappiButton(2p)").GetComponent<CappiOnOff2>();

        //선택되지 못한 캐릭터는 비활성화 한다.
        if (Global.MaridSelect_2p == true)
        {
            GetMarid.MaridSetActive();
            Global.MaridSelect_2p = false;
        }

        if(Global.DaoSelect_2p == true)
        {
            GetDao.DaoSetActive();
            Global.DaoSelect_2p = false;
        }

        if(Global.CappiSelect_2p == true)
        {
            GetCappi.CappiSetActive();
            Global.CappiSelect_2p = false;
        }

        BazziActive.SetActive(!BazziActive.active);
        ClickSource.PlayOneShot(ClickSound, 1f);

        //같은캐릭터 중복선택 방지.
        if (Global.BazziSelect_2p == true)
            Global.BazziSelect_2p = false;
        else
        {
            Global.BazziSelect_2p = true;
            Global.SecondPlayer = true;

            SecondPlayerInfo.strCharName = "Bazzi";
            SecondPlayerInfo.fSpeed = 5.0f;
            SecondPlayerInfo.iBubbleCount = 1;
            SecondPlayerInfo.iBubbleLengthCount = 1;
        }

    }
}
