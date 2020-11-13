using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{
    public SpriteRenderer spriteRender = null;
    private Camera camera = null;
    public float offset = 2.5f;

    void Start()
    {
        camera = Camera.main;

    }
    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        //flip mouse check 
        bool flip = mousePosition.x < 0;  //which is true
         
        spriteRender.flipX = flip;     //make actions due to the previous bool 
         
        transform.position = new Vector3(Mathf.Clamp(mousePosition.x+(flip?-offset : offset), -8.5f ,8.5f ), transform.position.y);



        
    }
}
