using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Target : MonoBehaviour
{

    public SpriteRenderer spriteRender;

    public Animator targetHitAnimator;
    public Transform partToRotate;

    private Vector3 location;


    public float stayTime;
    private float speed = 2.5f;

   public  bool IsHit { get; private set; }  
                              //may use the private  for all ? 
    public bool isMovingIn = false;
    public bool isStaying = false;
    public bool isMovingOut = false;


    //add a variable used out of the script
    public event Action IsOut;


    private float timeLeft = 0f;


    private void OnEnable()
    {
        IsHit = false;
        isMovingIn = false;
        isMovingOut = false;
        isStaying = false;
        targetHitAnimator.enabled = false;
        partToRotate.rotation = Quaternion.identity;

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStaying)
        {
            timeLeft -= Time.deltaTime;

        }
        else
        {
            if (Mathf.Abs(transform.position.x - location.x) < 0.01f)
            {
                transform.position = location;
                if (isMovingOut)
                {
                    gameObject.SetActive(false);
                    IsOut?.Invoke();

                    return;
                }
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, location, speed * Time.deltaTime);
            }
        }
        
    }
    void MoveOut()
    {
        isMovingIn = false;
        isStaying = false;

        location = (location.x < 0 ? new Vector3(-10, 0) : new Vector3(10, 0));
        isMovingOut = true;

    }
    public  void Hit(Vector2 position )
    {
        if (IsHit)
        {
            return;
        }
        IsHit = true;

        targetHitAnimator.enabled = true;
        MoveOut();
    }
    public void getFromPool()
    {

    }
    
}
