using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public Vector3 endMove, hitMove;
    public GameObject spawnControl, topScore;
    public Material[] materials;    
    public int moveDirection, hp;
    public bool isMoving, isHit, isSelected;
    public float hitTimer, surviveTimer;
    public void Start()
    {
        endMove = transform.position;
        spawnControl = GameObject.FindGameObjectWithTag("SpawnControl");
        topScore = GameObject.FindGameObjectWithTag("TopScore");
        hp = 3;
    }
    public void Update()
    {
        surviveTimer += Time.deltaTime;
        DestroyAgent();
        ChangeMaterialOnHit();        
    }
    public void DestroyAgent()
    {
        if(hp <= 0)
        {
            SaveTopScore();
            spawnControl.GetComponent<SpawnControl>().agentAmount = spawnControl.GetComponent<SpawnControl>().agentAmount - 1;
            Destroy(gameObject);
        }
    }
    public void SaveTopScore()
    {
        if(surviveTimer > topScore.GetComponent<TopScore>().topScore)
        {
            topScore.GetComponent<TopScore>().topNameText.text = gameObject.name;
            topScore.GetComponent<TopScore>().topScore = surviveTimer;
        }
    }
    public void ChangeMaterialOnHit()
    {
        if(isHit)
        {
            gameObject.GetComponent<Renderer>().material = materials[1];
            hitTimer += Time.deltaTime;
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
    public void FixedUpdate()
    {
        if(!isHit)
        {
            Movement();
        }
        else
        {
            HitMove();
        }
    }
    public void Movement()
    {
        if(isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, endMove, 0.3f);
        }
        else
        {
            ChangeMoveDirection();
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
    public void ChangeMoveDirection()
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
            if (transform.position.x < 1)
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
    public void HitMove()
    {
        transform.position = Vector3.Lerp(transform.position, hitMove, 0.3f);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Agent")
        {
            isHit = true;
            hp -= 1;
            endMove = hitMove;
        }
        else if(other.gameObject.tag == "Hit")
        {
            if(!isHit)
            {
                hitMove = other.transform.position + new Vector3(0, 0.5f, 0);                
            }            
        }
        if(other.gameObject.tag == "MedKit")
        {
            hp += 1;
            Destroy(other.gameObject);
        }
    }
}
