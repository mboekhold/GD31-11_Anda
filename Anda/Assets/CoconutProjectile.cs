using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutProjectile : MonoBehaviour
{
    public float distance;
    public float lifeTime;
    public int damage;
    public float coconutSpeed = 5f;
    private Vector2 _moveDirection;
    public GameObject destroyEffect;
    public LayerMask whatIsSolid;
    public Transform target;
    private Rigidbody2D rb;


	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        _moveDirection = (target.transform.position - transform.position).normalized * coconutSpeed;
        Invoke("DestroyProjectile", lifeTime);
        rb.velocity = new Vector2(_moveDirection.x, _moveDirection.y);
	}
	
	// Update is called once per frame
	void Update ()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {

                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            DestroyProjectile();

        }
        
    }


    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
