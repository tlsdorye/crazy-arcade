using UnityEngine;
using System.Collections;

public enum SECOND_ANI_STATE
{
    DOWNIDLE,
    UPIDLE,
    RIGHTIDLE,
    LEFTIDLE,
    DOWNWALK,
    UPWALK,
    RIGHTWALK,
    LEFTWALK,
    BEFORE_DIE,
    DIE
}
//클래스 직속의 속성을 사용 하기 위해서 필요.
[System.Serializable]
public class SecondAniState
{
    public int StartIndex;
    public int EndIndex;
    public float FrameTime;
    public SECOND_ANI_STATE State;
}

public class SecondAnimation : MonoBehaviour
{

    public Texture2D[] textureList;      //애니메이션 이미지를 담당할 클래스
    public SecondAniState[] States;

    private SecondAniState CurAnistate;
    public int CurIndex;

    private bool IsSetAni;

    private string CurKey;
    void Start()
    {
        SetAni(SECOND_ANI_STATE.DOWNIDLE);
        StartCoroutine(AniUpdate());
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (IsSetAni == false)
                SetAni(SECOND_ANI_STATE.DOWNWALK);

            IsSetAni = true;
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (IsSetAni == false)
                SetAni(SECOND_ANI_STATE.UPWALK);

            IsSetAni = true;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (IsSetAni == false)
                SetAni(SECOND_ANI_STATE.RIGHTWALK);

            IsSetAni = true;
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (IsSetAni == false)
                SetAni(SECOND_ANI_STATE.LEFTWALK);

            IsSetAni = true;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            IsSetAni = false;
            SetAni(SECOND_ANI_STATE.DOWNIDLE);
        }

        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            IsSetAni = false;
            SetAni(SECOND_ANI_STATE.UPIDLE);
        }

        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            IsSetAni = false;
            SetAni(SECOND_ANI_STATE.LEFTIDLE);
        }

        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            IsSetAni = false;
            SetAni(SECOND_ANI_STATE.RIGHTIDLE);
        }
    }

    public void SetAni(SECOND_ANI_STATE aniState)
    {
        for (int i = 0; i < States.Length; ++i)
        {
            if (States[i].State == aniState)
            {
                CurAnistate = States[i];
                break;
            }
        }

        CurIndex = CurAnistate.StartIndex;
    }

    public IEnumerator AniUpdate()
    {
        while (true)
        {
            Renderer render = this.gameObject.GetComponent<Renderer>();
            if (render == null)
            {
                Debug.Log("Not Set Renderer");
                yield break;
            }
            if (CurAnistate == null)
            {
                Debug.Log("Not Set AniState");
                yield break;
            }

            CurIndex++;
            if (CurAnistate.EndIndex < CurIndex)
            {
                CurIndex = CurAnistate.StartIndex;
            }
            if (textureList.Length <= CurIndex)
            {
                Debug.Log("overFlow Index");
                yield break;
            }
            render.material.mainTexture = textureList[CurIndex];
            yield return new WaitForSeconds(CurAnistate.FrameTime);
        }
    }

}