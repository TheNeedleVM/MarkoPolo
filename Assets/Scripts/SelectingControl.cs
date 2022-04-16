using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectingControl : MonoBehaviour
{
    private RaycastHit hit;
    public LayerMask layermask;
    public GameObject selectedAgent;
    public float rayLength;
    void Start()
    {
        
    }


    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, rayLength, layermask))
        {
            if(Input.GetMouseButtonDown(0))
            {
                
                if(selectedAgent == null)
                {
                    if(hit.collider.tag == "Agent")
                    {
                        selectedAgent = hit.collider.gameObject;
                        hit.collider.GetComponent<Agent>().isSelected = true;
                    }
                }
                else
                {
                    if(hit.collider.tag == "Agent" && hit.collider.gameObject != selectedAgent)
                    {
                        selectedAgent.GetComponent<Agent>().isSelected = false;                        
                        hit.collider.GetComponent<Agent>().isSelected = true;
                        selectedAgent = hit.collider.gameObject;
                    }
                    else if(hit.collider.tag != "Agent" && hit.collider.gameObject != selectedAgent)
                    {
                        selectedAgent.GetComponent<Agent>().isSelected = false;
                        selectedAgent = null;
                    }                    
                }
            }            
        }
    }
}
