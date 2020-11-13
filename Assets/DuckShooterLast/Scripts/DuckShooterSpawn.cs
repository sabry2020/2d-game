using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using System;  //til now is useless

public class DuckShooterSpawn : MonoBehaviour
{
    [SerializeField]
    private Target FirstRowDuckTargetPrefab;

    /*
    [SerializeField]
   public  Target SecondRowDuckTargetPrefab;
   */
    [SerializeField]
   public  Target CircleTargetPrefab;





    private Queue<Target> FirstRowDuckTargetPool = new Queue<Target>();

    /*
    private Queue<Target> SecondRowDuckTargetPool = new Queue<Target>();
    */


    private Queue<Target>CircleTargetPool = new Queue<Target>();




    private float timeBetweenWaves = 1f;
    private float nextTimeForWave = 0.5f;

    void Update()
    {

       if (Time.timeSinceLevelLoad >= nextTimeForWave){
            SpawnWave();

            nextTimeForWave = Time.timeSinceLevelLoad + timeBetweenWaves;
        }
    }
    void SpawnWave()
    {

        int waveCount = Random.Range(0, 4);
        for (int i = 0; i < waveCount; i++)
        {
            int row = Random.Range(0, 4);
            SpawnTarget(row);

        }

        //spawn a wave 


      
    }

public Target SpawnTarget(int row )
{
        bool isDuck = GetIsDuck(row);
        Vector3 location = new Vector3((isDuck ? Random.Range(-7f, 7f) : Random.Range(-5f, 5f)), 0, 0);
        Vector3 position = (location.x <= 0 ? new Vector3(-10, 0) : new Vector3(10, 0));


        //calling target script 

      Target target = getFromPool(row,position);//(row, position)
        return target;

        




}


    public Target getFromPool (int row, Vector3 position)
    {
        Queue<Target> pool = null;
        switch(row)
        {
            case (0):
                pool = FirstRowDuckTargetPool;
                break;
                /*
            case (1):
                pool = SecondRowDuckTargetPool;
                break;
                */

            case (2):
                pool = CircleTargetPool;
                break;
               

        }
        if (pool == null)
        {
            pool = FirstRowDuckTargetPool;

        }
      

        Target target;
        if (pool.Count == 0)
        {
            target = Instantiate(GetPrefab(row), position, Quaternion.identity, transform);
            target.IsOut += () => { pool.Enqueue(target); };
        }
        else
        {
            target = pool.Dequeue();
            target.transform.position = position;
            target.gameObject.SetActive(true);

        }
        return target;

    }
    public Target GetPrefab(int row)
    {
        switch(row)
        {

            case (0):
                return FirstRowDuckTargetPrefab;
                break;
/*
            case (1):
                return SecondRowDuckTargetPrefab;
                break;
                */

            case (2):
                return CircleTargetPrefab;
                break;
        }
        return FirstRowDuckTargetPrefab;  //default 

    }
  
        public bool GetIsDuck(int row)
    {
        return row != 2;

    }
   
}
