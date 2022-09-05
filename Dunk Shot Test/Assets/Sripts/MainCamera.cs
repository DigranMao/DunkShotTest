using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private Transform ball;
    private Vector3 pos;
    float bottomLimit;
    float upperLimit;

    private void Awake()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }
    private void Update()
    {
        pos = ball.position;
        pos.x = 0;
        pos.z = -10f;
        pos.y += 2f;   
        upperLimit++;
        transform.position = Vector3.Lerp(transform.position, pos, 3f * Time.deltaTime);

        transform.position = new Vector3(transform.position.x,
            Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
            transform.position.z);
    }

    public void CameraPos(Vector3 posBall)
    {     bottomLimit = posBall.y +2f;}        
    
}
