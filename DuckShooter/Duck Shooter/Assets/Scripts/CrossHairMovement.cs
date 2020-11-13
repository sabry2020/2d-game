using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairMovement : MonoBehaviour
{


    private Camera camera = null;

    void Start()
    {
        camera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        //check position  Flip
        Cursor.visible = mousePosition.x < 7.7f || mousePosition.x > -8.5f||mousePosition.y<-3.7f||mousePosition.y>4.5f;//4.5
        //Control the movement  of the cursor 
        transform.position = new Vector3(Mathf.Clamp(mousePosition.x, -7.7f, 8.5f), Mathf.Clamp(mousePosition.y, -3.7f, 4.5f));//or 4.5


    }
}
