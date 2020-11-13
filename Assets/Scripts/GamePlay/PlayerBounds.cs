using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounce : MonoBehaviour
{

    public float minX = -2.6f, maxX = 2.6f, minY = -5.6f;

    private bool outOfBounds;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckBounds();

    }


   
    void CheckBounds()
    {
        Vector2 temp = transform.position;

        if (temp.x > maxX)
        {
            temp.x = maxX;

            transform.position = temp;
        }
        if (temp.x < minX)
        {
            temp.x = minX;
            transform.position = temp;
        }
        if (temp.y < minY)
        {
            if (!outOfBounds)
            {
                outOfBounds = true;
                SoundManager.instance.DeathSound();
                GameManager.instance.RestartGame();
                 
            }
        }


    }


    
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "Star")
        {
            // other.gameObject.SetActive(false);   
            //or transport to a far place as the tutorial 

            gameObject.SetActive(false);


            SoundManager.instance.DeathSound();
            GameManager.instance.RestartGame();

        }


    }
   
}
