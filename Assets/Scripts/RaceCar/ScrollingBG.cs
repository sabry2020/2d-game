using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    public float speedScroll;
    Vector2 offset;

  

    // Update is called once per frame
    void Update()
    {

        offset = new Vector2(Time.time * speedScroll, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
