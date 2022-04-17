using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    public GameObject agentPrefab, newAgent, medkitPrefab;
    public GameObject[] tiles;
    public int spawnAgentTimeRoll, agentAmount, spawnAgentPosRoll, agentNumber, spawnMedkitTimeRoll, spawnMedkitPosRoll;
    public float spawnAgentTimer, spawnMedkitTimer;
    public void Start()
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");
        spawnAgentTimeRoll = 1;
        spawnAgentPosRoll = Random.Range(0, tiles.Length);
        spawnMedkitPosRoll = Random.Range(0, tiles.Length);
    }
    public void Update()
    {
        SpawnTime();
        SpawnAgent();
        SpawnMedKit();
    }
    public void SpawnTime()
    {
        if(agentAmount < 30)
        {
            spawnAgentTimer += Time.deltaTime;
        }
        else
        {
            spawnAgentTimer = 0;
        }
        spawnMedkitTimer += Time.deltaTime;
    }
    public void SpawnAgent()
    {
        if(spawnAgentTimer > spawnAgentTimeRoll && !tiles[spawnAgentPosRoll].GetComponent<Tile>().isOccupied)
        {
            newAgent = Instantiate(agentPrefab, tiles[spawnAgentPosRoll].transform.position + new Vector3(0, 0.5f, 0f), Quaternion.identity);
            agentNumber += 1;
            newAgent.name = "Agent 00" + agentNumber.ToString();
            agentAmount += + 1;
            spawnAgentTimer = 0;
            spawnAgentTimeRoll = Random.Range(2, 11);
            spawnAgentPosRoll = Random.Range(0, tiles.Length);
        }
    }
    public void SpawnMedKit()
    {
        if(spawnMedkitTimer > spawnMedkitTimeRoll)
        {
            Instantiate(medkitPrefab, tiles[spawnMedkitPosRoll].transform.position + new Vector3(0, 0.05f, 0f), Quaternion.identity);
            spawnMedkitTimeRoll = Random.Range(5, 12);
            spawnMedkitTimer = 0;
            spawnMedkitPosRoll = Random.Range(0, tiles.Length);
        }        
    }
}
