using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {

    // Use this for initialization
    public Joystick joystick;

    public GameObject projectile;
    public GameObject shotEffect;
    public Transform shotPoint;
    public Button AttackButton;
    public UnityEvent OnAttack;

    private float _timeBtwShots;
    public float startTimeBtwShots;
    private bool _isReadyToShoot;
    public float offset;
    void Start ()
    {
        AttackButton.onClick.AddListener(() =>{ ShootBullet(); });
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 direction = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);

        if (direction != Vector3.zero)
        {

            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
        _timeBtwShots -= Time.deltaTime;
       
        
        
    }


    public void ShootBullet()
    {
        
       if(_timeBtwShots <= 0)
       {
           
            Vector2 position = transform.position;
            position.x += .5f;
            position.y += .5f;
            OnAttack.Invoke();
            Instantiate(projectile, shotPoint.position, transform.rotation);
            Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
            _timeBtwShots = startTimeBtwShots;

       } 
    }

    
}
