using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    private static int _health = 50;
    public Transform player;
    public Animator animator;
    private bool _attacking;
    private int damage;

    private float _attackTimer = 0;
    private float _attackCooldown = 0.3f;

    public Collider2D attackTrigger;

    private Animator _anim;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator.GetComponent<Animator>();
        _anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            _attacking = false;
            attackTrigger.enabled = false;
            _anim.SetBool("attacking", false);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
            _attacking = true;
            _attackTimer = _attackCooldown;
            attackTrigger.enabled = true;
            _anim.SetBool("attacking", true);
            player.SendMessage("TakeDamage", damage);
            if (_attacking)
            {
                if (_attackTimer > 0)
                {
                    _attackTimer -= Time.deltaTime;
                }
            }

        }
        else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            _attacking = false;
            attackTrigger.enabled = false;
            _anim.SetBool("attacking", false);
        }

        
        


	}

  

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals ("Arrow"))
        {
            Destroy(collision.gameObject);
            _health--;
            Debug.Log("Hit");
            Debug.Log(_health.ToString());
        }
    }

    
}
