using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isOccupied;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Agent")
        {
            isOccupied = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Agent")
        {
            isOccupied = false;
        }
    }
}
