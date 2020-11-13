using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;


public class SpaceEnemySpawn : MonoBehaviour
{


    public float min = -4.3f, max = 4.3f;

    public GameObject[] asteriod_Prefabs;
    public GameObject enemyPrefab;
    public float Timer = 2f;


    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Spawn()
    {

        float posY = Random.Range(min, max);
        Vector3 temp = transform.position;
        temp.y = posY;
        if (Random.Range(0, 2) > 0)//50% for two choices spaceship or a asteriod 
        {

            Instantiate(enemyPrefab, temp, Quaternion.Euler(0f, 0f,90f));// to face the player 

        }
        else
        {
            Instantiate(asteriod_Prefabs[Random.Range(0, asteriod_Prefabs.Length)], temp, Quaternion.identity);

        }
       Invoke("Spawn", Timer);

    }
   

   
            
}
