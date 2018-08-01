using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupController : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        if (isLocalPlayer) GetComponent<MainController>().enabled = true;
        else GetComponent<MainController>().enabled = false;
    }

}
