using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    public float deactivateTimer = 3f;

   // [SerializeField]
    private GameObject player_Bullet;

    [HideInInspector]
    public Transform attackPoint;

    [HideInInspector]
    public bool isEnemyBullet= false;




    // Start is called before the first frame update
    void Start()
    {
        if (isEnemyBullet)
        {
            speed *= -1f;

        }
        Invoke("DeactivateGameObject", deactivateTimer);

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 temp = transform.position;
        //fire the pullet from the rocket thorough the x-axis 
        temp.x += speed * Time.deltaTime;
        transform.position = temp;

    }


    void DeactivateGameObject()
    {
        gameObject.SetActive(false);


    }
    void OnTriggerEnter2D(Collider2D target)  //destroying or deactivating the bullets after hiting the player bullet or enemy
    {

        if (target.tag == "Bullet" || target.tag == "EnemyHard")
        {
            
            gameObject.SetActive(false);
          

        }
        if (isEnemyBullet)
        {
            if (target.tag == "Player")
                Destroy(target.gameObject);
        }
    }

   
    //enemy friendly fire ignore 
    //sprite for the end of the game
    //Some UI elements 
  
   
   

    
}
