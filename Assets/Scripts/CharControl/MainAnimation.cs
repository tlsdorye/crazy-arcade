using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MainAnimation : NetworkBehaviour {

    private SpriteRenderer sprite;
    public GameObject exBomb;
    public Transform exBombSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && isLocalPlayer)
        {
            CmdCreateBomb();
            //CmdexBomb();
        }
    }

    [Command]
    void CmdexBomb()
    {

        GameObject bomb = Instantiate(exBomb, exBombSpawn.position, exBombSpawn.rotation);

        NetworkServer.Spawn(bomb);

        Destroy(bomb, 3.5f);
    }

    [Command]
    void CmdCreateBomb()
    {
        GameObject bombObj = (GameObject)GameObject.Instantiate(Resources.Load("Bomb"));
        sprite = bombObj.GetComponent<SpriteRenderer>();
        if (sprite)
        {
            sprite.sortingOrder = 1;
        }
        Bomb bomb = bombObj.GetComponent<Bomb>();
        if (bomb == null)
            return;
        bomb.CreateBomb(this.gameObject.transform.position,
            this.gameObject.transform.rotation, 7); // FirstPlayerInfo.iBubbleLengthCount
        FirstPlayerInfo.iSetBuubleCount += 1;

        NetworkServer.Spawn(bombObj);

        Destroy(bombObj, 3.1f);
    }

}
