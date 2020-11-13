using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{


    //Enemy Sprites 
    public GameObject Enemy_f;
    public GameObject Enemy_s;

   public int enemyCount;


    //variable conrtolling the spawn 

    public float currentTimer;
    public float EnemySpawnTimer = 1f;




    // Start is called before the first frame update
    void Start()
    {
        currentTimer = EnemySpawnTimer;

    }

    // Update is called once per frame
    void Update()
    {
        Spawn();

    }
    void Spawn()
    {                        //making the position of the Enemy and incrementing him 
        currentTimer = Time.deltaTime;

        if (currentTimer > EnemySpawnTimer)
        {
            enemyCount++;
            Vector3 temp = transform.position;
            temp.x = Random.Range(-2.5f, 2.5f);


            GameObject newEnemy = null;



            //using probability of 0.5  in instantiating the enemies 
            if (enemyCount <= 2)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newEnemy = Instantiate(Enemy_f, temp, Quaternion.identity);
                }
            }
            if (enemyCount >= 4)
            { 
                if (Random.Range(0, 2) < 1)
                {
                    newEnemy = Instantiate(Enemy_s, temp, Quaternion.identity);
                }
            }
            enemyCount = 0;
        }

        currentTimer = 0;
    }
}
