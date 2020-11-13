using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{

    //bounds 
    public float minX = -0.9f, maxX = 1.5f;
    public float upperBound = 4f;


    public float speed = 2f;

    public int Score;

    //controlling the star spawn 
    public float currentTime;
    public float starSpawnTimer = 3f;
    
    public GameObject Star;
    public int  starCount;



    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("SpawnStars", 1f);

        MoveStars();

    }

    void MoveStars()
    {

        
        //move the stars up 
        Vector2 temp = transform.position;
        temp.y += speed * Time.deltaTime;
        transform.position = temp;



        //deactivate when out of the zone 
        if (transform.position.y < -4)
            gameObject.SetActive(false);


    }

    void SpawnStars()
    {
        if (currentTime > starSpawnTimer)
        {
            starCount++;

            Vector2 temp = transform.position;
            temp.x = Random.Range(-4, 4);

            Instantiate(Star, temp, Quaternion.identity);


            //free memory 
            if (temp.y < -4)
            {
                gameObject.SetActive(false);

            }
            Score = starCount;

            if (starCount > 50)
                gameObject.SetActive(false);
        }
       



    }


}
