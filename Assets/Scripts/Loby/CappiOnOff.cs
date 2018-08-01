using UnityEngine;
using System.Collections;

public class CappiOnOff : MonoBehaviour {

    public GameObject CappiActive;
    public AudioClip ClickSound;
    private AudioSource ClickSource = null;

    //외부 스크립트를 가져온다.
    private MaridOnOff GetMarid;
    private DaoOnOff GetDao;
    private BazziOnOff GetBazzi;

    void Start()
    {
        CappiActive.SetActive(false);
        ClickSource = GetComponent<AudioSource>();

    }

    public void CappiSetActive()
    {
        //MaridButton(1p)에 연결된 MaridOnOff 스크립트의 정보를 가져온다.
        GetMarid = GameObject.Find("MaridButton(1p)").GetComponent<MaridOnOff>();
        GetDao = GameObject.Find("DaoButton(1p)").GetComponent<DaoOnOff>();
        GetBazzi = GameObject.Find("BazziButton(1p)").GetComponent<BazziOnOff>();

        //선택되지 못한 캐릭터는 비활성화 한다.
        if (Global.MaridSelect_1p == true)
        {
            GetMarid.MaridSetActive();
            Global.MaridSelect_1p = false;
        }

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

        CappiActive.SetActive(!CappiActive.active);
        ClickSource.PlayOneShot(ClickSound, 1f);

        //같은캐릭터 중복선택 방지.
        if (Global.CappiSelect_1p == true)
            Global.CappiSelect_1p = false;
        else
        {
            Global.CappiSelect_1p = true;
            Global.FirstPlayer = true;

            FirstPlayerInfo.strCharName = "Cappi";
            FirstPlayerInfo.fSpeed = 3.0f;
            FirstPlayerInfo.iBubbleCount = 1;
            FirstPlayerInfo.iBubbleLengthCount = 2;
        }

    }
}
