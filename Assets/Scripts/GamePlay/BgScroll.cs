using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour
{

    //making a bg scroll 

    public float speed = 0.3f; //scroll speed 

    private MeshRenderer meshRenderer;


    // Start is called before the first frame update
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveBg(); 
    }
    void MoveBg()
    {
        Vector2 offset = meshRenderer.sharedMaterial.GetTextureOffset("_MainTex");

        offset.y += Time.deltaTime * speed;
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex",offset);


        

    }
}
