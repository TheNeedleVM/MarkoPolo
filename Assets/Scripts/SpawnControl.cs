using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    public GameObject agentPrefab;
    public GameObject[] tiles;
    public int spawnTimeRoll, agentAmount, spawnPosRoll;
    public float spawnTimer;

    void Start()
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");
        spawnTimeRoll = Random.Range(3, 11);
        spawnPosRoll = Random.Range(0, tiles.Length);
    }


    void Update()
    {
        if(agentAmount < 30)
        {
            spawnTimer = spawnTimer + Time.deltaTime;
        }
        else
        {
            spawnTimer = 0;
        }

        if(spawnTimer > spawnTimeRoll && !tiles[spawnPosRoll].GetComponent<Tile>().isOccupied)
        {
            Instantiate(agentPrefab, tiles[spawnPosRoll].transform.position + new Vector3(0, 0.5f, 0f), Quaternion.identity);
            agentAmount = agentAmount + 1;
            spawnTimer = 0;
            spawnTimeRoll = Random.Range(3, 11);
            spawnPosRoll = Random.Range(0, tiles.Length);
        }
    }    
}
