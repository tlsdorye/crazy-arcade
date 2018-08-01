using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    public RectTransform Mask;

    void Start()
    {
        LeanTween.scale(gameObject, new Vector3(3f, 3f, 1f), 1.0f).setEase(LeanTweenType.easeOutElastic);       //setEase 증가함수??
        LeanTween.move(gameObject, new Vector3(0f, 1.5f, 0f), 1.0f).setDelay(2.0f).setLoopPingPong().setEase(LeanTweenType.easeInOutSine);  //setLoopPingPong : 핑퐁 형태로 Loop

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Mask.gameObject.SetActive(true);
            //알파값 조정가능
            LeanTween.alpha(Mask, 1f, 1.0f).setOnComplete(Complete);   //setOnComplete : 완성되면 다음의 함수를 실행한다. 
        }
    }

    void Complete()
    {
        SceneManager.LoadScene("Loby");
    }
}

