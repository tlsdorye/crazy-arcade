using UnityEngine;
using System.Collections;

public class Screen1 : MonoBehaviour
{

    void Start()
    {
        //LeanTween.scale(gameObject, new Vector3(2f, 2f, 1f), 1.0f).setEase(LeanTweenType.easeOutElastic);       //setEase 증가함수??
        //LeanTween.moveY(gameObject, 1f, 1.0f);
        LeanTween.move(gameObject, new Vector3(1.5f, -3.95f, 0f), 0.5f).setDelay(0.0f).setLoopPingPong().setEase(LeanTweenType.easeInOutBounce);  //setLoopPingPong : 핑퐁 형태로 Loop

    }

}

