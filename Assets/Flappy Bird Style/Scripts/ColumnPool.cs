using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {
    //Collection of pooled columns.
    private GameObject[] columns;
    //How many columns to keep on standby.
    public int columnPoolSize = 5;
    //The column game object.
    public GameObject columnPrefab;
    //A holding position for our unused columns offscreen.
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    // Time since last spawned.
    private float timeSinceLastSpawned;
    //How quickly columns spawn.
    public float spawnRate = 4f;
    //Minimum y value of the column position.
    public float columnMin = -1f;
    //Maximum y value of the column position.
    public float columnMax = 3.5f;
    // Spawn in the x position.
    private float spawnXPosition = 10f;
    //Index of the current column in the collection.
    private int currentColumn = 0;

	// Use this for initialization
	void Start () {
        //Initialize the columns collection.
        columns = new GameObject[columnPoolSize];
        //Loop through the collection... 
        for (int i = 0; i < columnPoolSize; i++)
        {
            //...and create the individual columns.
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }

	}

    // Update is called once per frame
    //This spawns columns as long as the game is not over.
    void Update () {

        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {

            timeSinceLastSpawned = 0;
            //Set a random y position for the column
            float spawnYPosition = Random.Range(columnMin, columnMax);
            //...then set the current column to that position.
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            //Increase the value of currentColumn. If the new size is too big, set it back to zero.
            currentColumn++;

            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
                 
        }
		
	}
}
