using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMovement : MonoBehaviour
{                                              //try to move the car back and forth + try Using analog instead of the buttons 

    public Rigidbody2D rb;
    public float speed=10f;


  public void Left()
    {
        rb.AddForce(Vector2.left * speed*Time.deltaTime);

    }
    public void Right()
    {
        rb.AddForce(Vector2.right * speed * Time.deltaTime);
        Debug.Log("This is a right Click");

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
       
        Destroy(gameObject);

    }

    public void goToHome()
    {
        SceneManager.LoadScene("Main Menu");

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
