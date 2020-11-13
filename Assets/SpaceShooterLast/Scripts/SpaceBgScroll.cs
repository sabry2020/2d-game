using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBgScroll : MonoBehaviour
{
    //global var 
   public float scrollSpeed = 0.1f;
    private MeshRenderer mesh_Renderer;
    private float x_Scroll;


    void Awake()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }
    void Scroll()
    {
        x_Scroll = Time.time * scrollSpeed;
        Vector2 offset = new Vector2(x_Scroll, 0f);
        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);

    }
}
