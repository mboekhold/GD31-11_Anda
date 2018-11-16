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
    public AudioSource audiosrc;
    public AudioClip audioclip;
    

   

    

    private void Start()
    {
        audiosrc.GetComponent<AudioSource>();
        AudioSource.PlayClipAtPoint(audioclip, transform.position);
        Invoke("DestroyProjectile",lifeTime); 
        
    }
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
            if(hitInfo.collider != null)
            {
                if(hitInfo.collider.CompareTag("Enemy"))
                {
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

