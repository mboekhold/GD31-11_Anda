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
    private bool _facingRight;
    public Button AttackButton;
    private Rigidbody2D _body;
    private float _fireRate;
    private float _nextFire;
    public UnityEvent OnAttack;
    public GameObject arrow;
    

    private void Start()
    {
        _facingRight = true;
        _body.GetComponent<Rigidbody2D>();

        
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
        if (horizontal > 0 && !_facingRight || horizontal < 0 && _facingRight)
        {
            _facingRight = !_facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private void ShootArrow()
    {
        Vector2 position = transform.position;
        position.x += .5f;
        position.y += .5f;
        if (Time.time > _nextFire)
        {
            OnAttack.Invoke();
            
                var firedArrow = Instantiate(arrow, position, Quaternion.identity);
                _nextFire = Time.time + _fireRate;

            

        }

    }

}
