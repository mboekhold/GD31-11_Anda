﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public GameObject destroyEffect;
    public LayerMask whatIsSolid;
    public GameObject Player;
    

    private void Start()
    {
        Invoke("DestroyProjectile",lifeTime);
    }
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("ENEMY MUST TAKE DAMAGE");
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            DestroyProjectile();
        }
        transform.Translate(transform.up * speed * Time.deltaTime);



    }

    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
