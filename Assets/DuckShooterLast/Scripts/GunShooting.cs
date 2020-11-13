using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
  
    // Update is called once per frame
    void Update()
    {
        //get Input from User 

        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D collider = Physics2D.OverlapCircle(mousePosition, 0.01f);
            if(collider!=null &&collider.CompareTag("Target"))
            {
                // Destroy(this.gameObject);      /*collider.gameObject*/
                Target target = collider.GetComponentInParent<Target>();
                target.Hit(mousePosition);
            }

        }
        
    }
}
