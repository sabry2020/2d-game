using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Enemy : MonoBehaviour
{


    public float speed = 5f;
    public float rotateSpeed = 50f;


    public bool canShoot;
    public bool canRotate;
    private bool canMove=true;

    public float boundX = -11f;


    public Transform attackPoint;
    public GameObject bulletPrefab;


    private Animator anim;
    private AudioSource audio; //explosion Sound 



    public GameObject Steriod;

   void Awake()
    {
        anim = GetComponent<Animator>();
        audio= GetComponent<AudioSource>();


    }

    void Start()
    {
        if (canRotate)
        {

            if (Random.Range(0, 2) > 0)
            {
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
                rotateSpeed *=-1f;     //make the object rotate backwards 
            }
            else
            {
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);//make the object rotate in normal without changing  the angle 
            }
        }
        if (canShoot)
        {
            Invoke("startShooting", Random.Range(1f,3f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotateEnemy();


    }

    void Move()
    {
        if (canMove)
        {
           Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;
            if (temp.x < boundX)
             gameObject.SetActive(false);

        }
    
    }

    void RotateEnemy()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime), Space.World);
        }
    }

    void startShooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().isEnemyBullet = true;
        if(canShoot)
        {
            Invoke("startShooting", Random.Range(1f, 3f));
        }
        

    }
    void TurnOffGameObject()
    {

        gameObject.SetActive(false);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {

            canMove = false;
            if (canShoot)
            {
                canShoot = false;
                CancelInvoke("startShooting");
            }

            Invoke("TurnOffGameObject", 1);

            //play the explosion sound 

            anim.Play("Destroy");

           
        }
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);

        }
    }
}
