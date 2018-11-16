using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
        
    public float moveSpeed = 8f;
    public Joystick joystick;
    public Animator animator;
    public static bool facingRight;

    private Rigidbody2D _body;
    public LayerMask notToHit;
    public int health;
    
    

    
    

    private void Start()
    {
        facingRight = true;
        
        //_body.GetComponent<Rigidbody2D>();
      
        


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

   


    public void TakeDamage(int damage)
    {
        health -= damage;
        PlayerHealthBarScript.health -= damage;
    }
    

}
