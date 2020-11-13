using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        var fingerCount = 0;
        foreach(Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                fingerCount++;

            }
            if(fingerCount>0)
            {
                Debug.Log("there are " + fingerCount + " finger(s) touching the screen ");

            }
        }

        //touch event (touch.phase != TouchPhase.Ended)==left the screen 
        //touch event click ( touch.phase==TouchPhase.Began)==click on the screen 

    }

}
