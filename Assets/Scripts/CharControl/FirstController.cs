using UnityEngine;
using System.Collections;

public class FirstController : MonoBehaviour {

    public GameObject DaoActive;
    public GameObject MaridActive;
    public GameObject BazziActive;
    public GameObject CappiActive;

    // Use this for initialization
    void Awake ()
    {
        if (FirstPlayerInfo.strCharName == "Dao")
            DaoActive.SetActive(!DaoActive.active);
        else if (FirstPlayerInfo.strCharName == "Marid")
            MaridActive.SetActive(!MaridActive.active);
        else if (FirstPlayerInfo.strCharName == "Bazzi")
            BazziActive.SetActive(!BazziActive.active);
        else if (FirstPlayerInfo.strCharName == "Cappi")
            CappiActive.SetActive(!CappiActive.active);
    }
	
	// Update is called once per frame
	void Update () 
	{

        if (Input.GetKey(KeyCode.F))
        {
            transform.Translate(Vector3.left * FirstPlayerInfo.fSpeed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.H))
        {
            transform.Translate(Vector3.right * FirstPlayerInfo.fSpeed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.T))
        {
            transform.Translate(Vector3.up * FirstPlayerInfo.fSpeed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.G))
        {
            transform.Translate(Vector3.down * FirstPlayerInfo.fSpeed * Time.deltaTime);
        }

       
	}

}
