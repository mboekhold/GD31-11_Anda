using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
    public GameObject deathEffect;
    public float speed;
    public float stoppingDistance;
    public Transform player;
    public int damage;
    public GameObject coconut;
    public float FireRate;
    private float _nextFire;
    public GameObject reward;

 


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        reward.gameObject.SetActive(false);
        

    }

    private void Update()
    {
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
            reward.gameObject.SetActive(true);
        }
        MoveToAndAttackPlayer();

    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        HealthBarScript.health -= damage;
    }

    private void MoveToAndAttackPlayer()
    {

        if(Vector2.Distance(transform.position,player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position,player.position) < stoppingDistance)
        {
            transform.position = this.transform.position;
            if(Time.time > _nextFire)
            {
                Instantiate(coconut, transform.position, Quaternion.identity);
                _nextFire = Time.time + FireRate;

            }
        }
    }
        
        


}

  

    
