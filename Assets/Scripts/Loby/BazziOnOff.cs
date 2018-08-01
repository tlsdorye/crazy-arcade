using UnityEngine;
using System.Collections;

public class BazziOnOff : MonoBehaviour {

    public GameObject BazziActive;
    public AudioClip ClickSound;
    private AudioSource ClickSource = null;
    public SpriteRenderer aaa;
    //외부 스크립트를 가져온다.
    private MaridOnOff GetMarid;
    private DaoOnOff GetDao;
    private CappiOnOff GetCappi;

    void Start()
    {
        BazziActive.SetActive(false);
        ClickSource = GetComponent<AudioSource>();
    }

    public void BazziSetActive()
    {
        //MaridButton(1p)에 연결된 MaridOnOff 스크립트의 정보를 가져온다.
        GetMarid = GameObject.Find("MaridButton(1p)").GetComponent<MaridOnOff>();
        GetDao = GameObject.Find("DaoButton(1p)").GetComponent<DaoOnOff>();
        GetCappi = GameObject.Find("CappiButton(1p)").GetComponent<CappiOnOff>();

        //선택되지 못한 캐릭터는 비활성화 한다.
        if (Global.MaridSelect_1p == true)
        {
            GetMarid.MaridSetActive();
            Global.MaridSelect_1p = false;
        }

        if(Global.DaoSelect_1p == true)
        {
            GetDao.DaoSetActive();
            Global.DaoSelect_1p = false;
        }

        if(Global.CappiSelect_1p == true)
        {
            GetCappi.CappiSetActive();
            Global.CappiSelect_1p = false;
        }

        BazziActive.SetActive(!BazziActive.active);
        ClickSource.PlayOneShot(ClickSound, 1f);

        //같은캐릭터 중복선택 방지.
        if (Global.BazziSelect_1p == true)
            Global.BazziSelect_1p = false;
        else
        {
            Global.BazziSelect_1p = true;
            Global.FirstPlayer = true;

            FirstPlayerInfo.strCharName = "Bazzi";
            FirstPlayerInfo.fSpeed = 5.0f;
            FirstPlayerInfo.iBubbleCount = 1;
            FirstPlayerInfo.iBubbleLengthCount = 1;
        }

    }
}
