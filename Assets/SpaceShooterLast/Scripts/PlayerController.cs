using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    //to prevent the playe from going off the seen add a collider OR
    public float min_Y, max_Y;

    [SerializeField]
    private GameObject player_Bullet;

    [SerializeField]
    private Transform  attackPoint;

    public float attackTimer = 0.5f;

    private float currentAttackTimer;

    private bool canAttack;

    // Start is called before the first frame update
    void Start()
    {
        currentAttackTimer = attackTimer;

    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        Attack();
        CheckForPause();
    }





    public void Pause()
    {
        Time.timeScale = 0f;
        Debug.Log("the pause button is pressed ");


    }



    public void GoHome()
    {
        SceneManager.LoadScene("Main Menu");

    }
    void CheckForPause()
    {
        if(Input.GetKey(KeyCode.M))
        {
            Time.timeScale = 0;
        }

        else if (Input.GetKey(KeyCode.N))
        {
         Time.timeScale = 1;

        }
        else if (Input.GetKey(KeyCode.Return))
        {
            Invoke("SlowDown", 5);

        }

    }
    void SlowDown()
    {
        Time.timeScale = 0.5f;
    }
    void movePlayer()
    {
        if (Input.GetAxisRaw("Vertical") > 0f)//going up
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;
            if (temp.y > max_Y)
                temp.y = max_Y;
            transform.position = temp;


        }

        else if (Input.GetAxisRaw("Vertical") < 0f) //going down 
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;
            if (temp.y < min_Y)
                temp.y = min_Y;
                transform.position = temp;
        }
    }

    void Attack()
    {
        attackTimer +=Time.deltaTime;

        if (attackTimer > currentAttackTimer)
            canAttack = true;


        if (Input.GetKeyDown(KeyCode.K))
        {
            if (canAttack)
            {
                Instantiate(player_Bullet, attackPoint.position, Quaternion.identity);
                canAttack = false;
                attackTimer = 0f;
                //play the sound effects 


            }
        }

        /*
         * Basic One Without the bullet firing restrictions 
         *
                if (Input.GetKey(KeyCode.K))
                {
                    Instantiate(player_Bullet, attackPoint.position, Quaternion.identity);

                }
                */
    }



    

}
