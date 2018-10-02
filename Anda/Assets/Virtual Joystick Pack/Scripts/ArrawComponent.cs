using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrawComponent : MonoBehaviour
{
    public float xspeed = 0f;
    public float yspeed = 0f;
    public GameObject arrow;
    Rigidbody2D rb;
    float arrowSpeed = 5f;
    public Transform target;
    Vector2 moveDirection;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyArrow());
        target = GameObject.FindGameObjectWithTag("Boss_Spy").transform;
        moveDirection = (target.transform.position - transform.position).normalized * arrowSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);

    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == ("Boss_Spy"))
        {
            Debug.Log("Hit");
            
        }
    }

    IEnumerator DestroyArrow()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    

    
}
