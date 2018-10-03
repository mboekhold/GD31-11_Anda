using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float moveSpeed = 8f;
    public Joystick joystick;
    public Animator animator;
    public bool facingRight;
    public Button AttackButton;
    private Rigidbody2D _body;
    public float FireRate = 0;
    public float Damage = 10;
    public LayerMask notToHit;
    private float _timeBtwShots;
    public float startTimeBtwShots;
    public Transform shotPoint;
    private float _nextFire;
    public UnityEvent OnAttack;
    public GameObject projectile;
    
    

    private void Start()
    {
        facingRight = true;
        _body.GetComponent<Rigidbody2D>();
        AttackButton.onClick.AddListener(() => { ShootArrow(); });
        


    }
    private void Update()
    {
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);
        animator.SetFloat("Speed", Mathf.Abs(joystick.Horizontal));
        if (moveVector != Vector3.zero)
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.World);
            
            
            Flip(joystick.Horizontal);
        }
        
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    public void ShootArrow()
    {
        Vector2 position = transform.position;
        position.x += .5f;
        position.y += .5f;
        if (_timeBtwShots <= 0)
        {
            OnAttack.Invoke();

            Instantiate(projectile, shotPoint.position, transform.rotation);

            _timeBtwShots = startTimeBtwShots;
        }
        else
        {
            _timeBtwShots -= Time.deltaTime;
        }

    }

}
