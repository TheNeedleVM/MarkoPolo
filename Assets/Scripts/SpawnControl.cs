using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    public GameObject agentPrefab, newAgent;
    public GameObject[] tiles;
    public int spawnTimeRoll, agentAmount, spawnPosRoll, agentNumber;
    public float spawnTimer;
    public void Start()
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");
        spawnTimeRoll = 1;
        spawnPosRoll = Random.Range(0, tiles.Length);
    }
    public void Update()
    {
        SpawnTime();
        SpawnAgent();       
    }
    public void SpawnTime()
    {
        if(agentAmount < 30)
        {
            spawnTimer += Time.deltaTime;
        }
        else
        {
            spawnTimer = 0;
        }
    }
    public void SpawnAgent()
    {
        if(spawnTimer > spawnTimeRoll && !tiles[spawnPosRoll].GetComponent<Tile>().isOccupied)
        {
            newAgent = Instantiate(agentPrefab, tiles[spawnPosRoll].transform.position + new Vector3(0, 0.5f, 0f), Quaternion.identity);
            agentNumber += 1;
            newAgent.name = "Agent 00" + agentNumber.ToString();
            agentAmount += + 1;            
            spawnTimer = 0;
            spawnTimeRoll = Random.Range(3, 11);
            spawnPosRoll = Random.Range(0, tiles.Length);
        }
    }    
}
