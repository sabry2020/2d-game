using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextControll : MonoBehaviour
{
    void Update()
    {
        if(Time.timeSinceLevelLoad > 5f)
        {
            this.gameObject.SetActive(false);

        }
    }
}
