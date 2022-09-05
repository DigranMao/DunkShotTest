using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Basket : MonoBehaviour
{
    public GameObject hitPos;
    Transform ball;

    Vector3 oldMousePos;
    Vector3 vector;
    Quaternion originRotate;

    public AudioSource toCatch;
    public AudioSource throwUp;
    MainCamera cameraSripts;
    Rigidbody2D rbBall;
    VectorRenderer trajectory;
    LineRenderer line;
    Spawner SpawnController;

    bool shoot;
    public float offset = 90f;
    float forceY;
    int basketDontActiv;
    
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
        rbBall = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();
        trajectory = GameObject.Find("Vector1").GetComponent<VectorRenderer>();
        line = GameObject.Find("Vector1").GetComponent<LineRenderer>();
        SpawnController =  GameObject.Find("SpawnController").GetComponent<Spawner>();
        cameraSripts =  GameObject.Find("Main Camera").GetComponent<MainCamera>();
    }
    
    void Update()
    {
        if(shoot == true)
        {
            ball.position = Vector2.MoveTowards(ball.position, hitPos.transform.position, 3f * Time.deltaTime);
            ball.SetParent(transform);
            ShootBall();
        }
        else if(shoot == false)
            ball.SetParent(null);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Ball"))
        {
            if(gameObject.tag == "Basket")
                PointText.Point += 1;

            toCatch.Play();
            rbBall.bodyType = RigidbodyType2D.Static;
            shoot = true;
            cameraSripts.CameraPos(ball.position);
            gameObject.tag = "BasketDontActiv";
        }
    }


    void ShootBall()
    {
        if(Input.GetMouseButtonDown(0))
            oldMousePos = new Vector3(Input.mousePosition.x / 100f, Input.mousePosition.y / 100f, 0);

        if(Input.GetMouseButton(0) || Input.touchCount == 1)
        {
            RotateBasket();
        }
        if(Input.GetMouseButtonUp(0))
        {    
            if(forceY >2.1f)
            {
                rbBall.bodyType = RigidbodyType2D.Dynamic;
                rbBall.AddForce(vector , ForceMode2D.Impulse);
                shoot = false;
                line.enabled = false;
                throwUp.Play();
            }
            transform.rotation = originRotate;         
        }
    }        

    void RotateBasket()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.x /= 100f;
        mouse.y /= 100f;

        forceY = Vector2.Distance(oldMousePos, mouse);
        forceY = Mathf.Clamp(forceY, 2f, 5.5f);
        vector = transform.up * forceY *2f;

        if(forceY > 2.1f)
        {
            line.enabled = true;
            trajectory.Trajectory(ball.position, vector);
        }
        originRotate = transform.rotation;  
        
        Vector3 mousePos = mouse - oldMousePos;
        float rotateZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if(rotateZ != 0)
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
         
    }

}
