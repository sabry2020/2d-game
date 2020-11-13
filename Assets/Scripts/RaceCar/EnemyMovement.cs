using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed=1000f;

  
    
    // Update is called once per frame
    void Update()
    {

        transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime);
    }
}
