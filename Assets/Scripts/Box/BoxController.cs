using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BombWaterU" || col.gameObject.tag == "BombWaterD" || col.gameObject.tag == "BombWaterL" || col.gameObject.tag == "BombWaterR")
        {
            Destroy(gameObject);
        }
    }
}
