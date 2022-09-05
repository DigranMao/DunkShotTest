using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public AudioSource hitSound;
    Rigidbody2D rb;
    Interface interfaceResume;
    Spawner spawnBasket;
    GameObject[] basket;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        interfaceResume = GameObject.Find("Canvas").GetComponent<Interface>();
        spawnBasket = GameObject.Find("SpawnController").GetComponent<Spawner>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.relativeVelocity.magnitude > 1f) 
        {
            hitSound.Play();
            hitSound.volume = Mathf.Clamp01(other.relativeVelocity.magnitude / 10);
            rb.velocity *= 0.8f;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.CompareTag("Respawn"))
        {
            Destroy(gameObject);
            interfaceResume.resume = true;
            interfaceResume.mainMenu = false;
            spawnBasket.DestroyBasketInBall(true);
        }
    }
}
