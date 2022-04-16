using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public GameObject spawnControl;
    public Material[] materials;
    public Vector3 endMove;
    public int moveDirection, hp;
    public bool isMoving, isHit, isSelected;
    public float hitTimer, surviveTimer;
    void Start()
    {
        endMove = transform.position;
        spawnControl = GameObject.FindGameObjectWithTag("SpawnControl");
        hp = 3;
    }


    void Update()
    {
        surviveTimer = surviveTimer + Time.deltaTime;
        if(hp == 0)
        {
            spawnControl.GetComponent<SpawnControl>().agentAmount = spawnControl.GetComponent<SpawnControl>().agentAmount - 1;
            Destroy(gameObject, 0.15f);
        }
        if(isHit)
        {            
            gameObject.GetComponent<Renderer>().material = materials[1];
            hitTimer = hitTimer + Time.deltaTime;
            if(hitTimer > 0.15f)
            {
                isHit = false;
            }
        }
        else
        {
            if(!isSelected)
            {
                gameObject.GetComponent<Renderer>().material = materials[0];
            }
            else
            {
                gameObject.GetComponent<Renderer>().material = materials[2];
            }
            hitTimer = 0f;
        }
    }
    void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        if(isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, endMove, 0.3f);
        }
        else
        {
            if(moveDirection == 0)
            {
                if(transform.position.x > 8)
                {
                    endMove = transform.position;
                }
                else
                {
                    endMove = transform.position + new Vector3(1, 0, 0);
                }
                
            }
            else if(moveDirection == 1)
            {
                if(transform.position.x < 1)
                {
                    endMove = transform.position;
                }
                else
                {
                    endMove = transform.position + new Vector3(-1, 0, 0);
                }                
            }
            else if(moveDirection == 2)
            {
                if(transform.position.z > 8)
                {
                    endMove = transform.position;
                }
                else
                {
                    endMove = transform.position + new Vector3(0, 0, 1);
                }
                
            }
            else if(moveDirection == 3)
            {
                if (transform.position.z < 1)
                {
                    endMove = transform.position;
                }
                else
                {
                    endMove = transform.position + new Vector3(0, 0, -1);
                }
                
            }
        }
        if(transform.position == endMove)
        {
            moveDirection = Random.Range(0, 4);
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Agent")
        {
            isHit = true;
            hp = hp - 1;           
        }
    }
}
