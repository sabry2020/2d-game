using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject breakablePlatform;
    public GameObject[] moving_Platforms;
   


    public float platformSpawnTimer = 1.8f;

    public float currentPlatformSpawnTimer;

    public int platformSpawnCount;
    public float minX = -2.1f, maxX = 2.1f;





    // Start is called before the first frame update
    void Start()
    {
        currentPlatformSpawnTimer = platformSpawnTimer;
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();
        
    }

    void SpawnPlatforms()
    {
       

        currentPlatformSpawnTimer += Time.deltaTime;

        if (currentPlatformSpawnTimer >= platformSpawnTimer) {

            //Instantiate(Random.Range(minX,maxX), Random.Range(minX, maxX), Quaternion.identity);
            platformSpawnCount++;

            Vector3 temp = transform.position;
            temp.x = Random.Range(minX, maxX);

            GameObject newPlatform = null;

            if (platformSpawnCount < 2)
            {
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);//Quaternion for the rotation 
                 
            }
            else if (platformSpawnCount == 2)
            {
                                                          //controlling the instantiation by using probability 
                if (Random.Range(0,2)>0)    //1 to 1 probability 0.5 
                newPlatform = Instantiate(moving_Platforms[Random.Range(0, moving_Platforms.Length)], temp, Quaternion.identity);
                else
                {
                    newPlatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity);

                }
            }

            else if (platformSpawnCount==3)
            {

                if (Random.Range(0, 2) > 0)    //1 to 1 probability 0.5 
                    newPlatform = Instantiate(moving_Platforms[Random.Range(0, moving_Platforms.Length)], temp, Quaternion.identity);
                else
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);

                }
            }
            else if(platformSpawnCount==4)
            {
                if (Random.Range(0, 2) > 0)    //1 to 1 probability 0.5 
                    newPlatform = Instantiate(moving_Platforms[Random.Range(0, moving_Platforms.Length)], temp, Quaternion.identity);
                else
                {
                    newPlatform = Instantiate(breakablePlatform, temp, Quaternion.identity);

                }

                platformSpawnCount = 0;
            }
           

            if(newPlatform) //check if the platform is not a null 
             newPlatform.transform.parent= transform;           //attatch the spawned object to the Spawner 

            currentPlatformSpawnTimer = 0f;




        }
        //condition to stop the game depending on the spawnTimer 
        
    }



   /* void Spawn()
    {
    //my new edited one 
    //clearly from my mind 

        GameObject newPlatform = null;
        platformSpawnCount++;

        newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);

    }
    */
    
}


