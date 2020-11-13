using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

         public float speed = 1f;


        private Rigidbody2D myBody;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

    }

    void Move()
    {
             
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            myBody.velocity = new Vector2(-speed, myBody.velocity.y);
        }
    }//move the player 


    public void PlatformMovement(float x )
    {
        myBody.velocity = new Vector2(x, myBody.velocity.y); 
    }


    public void GoMainMenu()
    {
        SceneManager.LoadScene("Main Menu");

    }
}
