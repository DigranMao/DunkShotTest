using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsPoint : MonoBehaviour
{
    PointText pointTextSript;

    void Start()
    {
        pointTextSript = GameObject.Find("Canvas").GetComponent<PointText>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Ball")
        {
            pointTextSript.StringStarsText(1);
            Destroy(gameObject);
        }
    }
}
