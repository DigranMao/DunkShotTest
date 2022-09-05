using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PointText : MonoBehaviour
{
    public static int Point;
    int StarsPoint;
    public Text text;
    public Text StarsText;
 
    void Start()
    {
        StarsPoint = PlayerPrefs.GetInt("Star", StarsPoint);       
    }

    public void StringStarsText(int starPoint)
    {   StarsPoint += starPoint;}
  
    void Update()
    {
        text.text = Point.ToString();
        PlayerPrefs.SetInt("Star", StarsPoint);        
        StarsText.text = StarsPoint.ToString();
        //PlayerPrefs.DeleteKey("Star");
    }
}
