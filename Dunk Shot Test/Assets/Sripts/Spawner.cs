using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    GameObject[] basketDontActiv;
    GameObject[] basket;
    public GameObject MainBasket;
    public GameObject Stars;
    public Transform ball;

    Vector3 volume;
    Vector3 starPos;
    Vector3 pos;

    int basketCountDontActiv;
    int basketCount;
    
    int starsCount;
    bool ballDai = false;

    float spawnRandX;
    float spawnRandY;
    float CounterY = 3.5f;

    void FixedUpdate()
    {
        basketDontActiv = GameObject.FindGameObjectsWithTag("BasketDontActiv");
        basket = GameObject.FindGameObjectsWithTag("Basket");
        basketCountDontActiv = basketDontActiv.Length;
        basketCount = basket.Length;
        pos = ball.position;
        DestroyBasket();        
    }

    public void SpawnBasket()
    {       
        if(pos.x < 0f)
        {
            spawnRandX = Random.Range(0.7f, 2f);
            CounterY += 1.5f; 
            volume = new Vector3(spawnRandX, CounterY, 0f);

            Instantiate(MainBasket, volume, MainBasket.transform.rotation);

            if(starsCount == 5)
            {
                starPos = new Vector3(spawnRandX, CounterY + 1f, 0f);
                Instantiate(Stars, starPos, Stars.transform.rotation);
            }
        }
        else if(pos.x > 0f)
        {
            spawnRandX = Random.Range(-0.7f, -2f);
            CounterY += 1.5f;
            volume = new Vector3(spawnRandX, CounterY, 0f);

            Instantiate(MainBasket, volume, MainBasket.transform.rotation);

            if(starsCount == 10)
            {
                starPos = new Vector3(spawnRandX, CounterY + 1f, 0f);
                Instantiate(Stars, starPos, Stars.transform.rotation);
                starsCount = 0;
            }
        }
    }

    void DestroyBasket()
    {
        if(basketCountDontActiv == 2)
        {
            Destroy(basketDontActiv[0]);
            SpawnBasket();
            starsCount++;
        }
    }
    
    public void DestroyBasketInBall(bool ballDeaht)
    {
        ballDai = ballDeaht;
        if(ballDai == true)
            Destroy(basketDontActiv[0]);
    }

}
