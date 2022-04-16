using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectingControl : MonoBehaviour
{
    private RaycastHit hit;
    public LayerMask layermask;
    public GameObject selectedAgent, agentUi;
    public float rayLength;
    public Text agentName, hpText, surviveText;
    void Start()
    {
        
    }


    void Update()
    {
        if(selectedAgent != null)
        {
            agentName.text = selectedAgent.name;
            hpText.text = "HP: " + selectedAgent.GetComponent<Agent>().hp.ToString();
            surviveText.text = "Survived for: " + selectedAgent.GetComponent<Agent>().surviveTimer.ToString("0.0" ) + "sec";
        }
        else
        {
            agentUi.SetActive(false);
        }
        
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
                        agentUi.SetActive(true);                        
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
                        agentUi.SetActive(false);
                    }                    
                }
            }            
        }
    }
}
