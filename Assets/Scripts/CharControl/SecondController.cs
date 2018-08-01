using UnityEngine;
using System.Collections;

public class SecondController : MonoBehaviour
{

    public GameObject DaoActive;
    public GameObject MaridActive;
    public GameObject BazziActive;
    public GameObject CappiActive;

    // Use this for initialization
    void Awake()
    {
        if (SecondPlayerInfo.strCharName == "Dao")
            DaoActive.SetActive(!DaoActive.active);
        else if (SecondPlayerInfo.strCharName == "Marid")
            MaridActive.SetActive(!MaridActive.active);
        else if (SecondPlayerInfo.strCharName == "Bazzi")
            BazziActive.SetActive(!BazziActive.active);
        else if (SecondPlayerInfo.strCharName == "Cappi")
            CappiActive.SetActive(!CappiActive.active);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * SecondPlayerInfo.fSpeed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * SecondPlayerInfo.fSpeed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * SecondPlayerInfo.fSpeed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * SecondPlayerInfo.fSpeed * Time.deltaTime);
        }
    }
}
