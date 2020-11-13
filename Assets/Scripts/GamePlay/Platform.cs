using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    //numerical variables 
    public float speed = 1f;
    public float minX = -2.3f, maxX = 2.3f;
    public float boundY = 6f;
    public bool movingPlatformLeft, movingPlatformRight, isBreakable, isSpike, isPlatform;


    private Animator anim;

    void Awake()
    {
        if (isBreakable)
        {
            anim = GetComponent<Animator>();

        }
    }
   

    // Update is called once per frame
    void Update()
    {
        Move();

    }
    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += speed * Time.deltaTime;
        transform.position = temp;

        if (temp.y >= boundY)
        {
            gameObject.SetActive(false);  //gameObject.SetActive(false);
        

        }
    }

    void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.1f);


    }
    void DeactivateGameObject()
    {
        SoundManager.instance.IceBreakSound();

       gameObject.SetActive(false);

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (isSpike)
            {
                other.transform.position = new Vector2(1000f, 1000f);
                SoundManager.instance.GameOverSound();
                GameManager.instance.RestartGame();

            }
        }

    }

    void OnCollisionEnter(Collision other )
    {
        if (other.gameObject.tag == "Player")
        {
            if (isBreakable)
            {
                SoundManager.instance.LandSound();
                anim.Play("Break");
            }
            if (isPlatform)
            {
                SoundManager.instance.LandSound();


            }
        }

    }

    void OnCollisionStay2D(Collision2D other )
    {
        if (other.gameObject.tag == "Player")
        {

            if (movingPlatformLeft)
            {
                other.gameObject.GetComponent<PlayerMovement>().PlatformMovement(-1f);

            }

            if (movingPlatformRight)
            {
                other.gameObject.GetComponent<PlayerMovement>().PlatformMovement(1f);

            }
        }
    }




}
