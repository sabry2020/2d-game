using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextControl : MonoBehaviour
{


   
  
    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad>5f)
        {
            Destroy(this.gameObject);

        

        }
    }
}
