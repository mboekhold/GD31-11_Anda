using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public GameObject destroyEffect;
    public float distance;
    public LayerMask whatIsSolid;
    public int damage;
   
    

   

    

    private void Start()
    {
        
        Invoke("DestroyProjectile",lifeTime); 
    }
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
            if(hitInfo.collider != null)
            {
                if(hitInfo.collider.CompareTag("Enemy"))
                {
                    Debug.Log("DAMAGE");
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
                }
                DestroyProjectile();
                
            }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
       
    }

   
}

