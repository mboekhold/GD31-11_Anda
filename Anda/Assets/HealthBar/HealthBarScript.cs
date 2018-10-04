using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    Image healthBar;
    public float maxhealth;
    public static float health;
    public Image healthBarBackground;
    public Text bossText;
    public Transform player;
	void Start ()
    {
        healthBar = GetComponent<Image>();
        health = maxhealth;
        healthBarBackground.enabled = false;
        healthBar.enabled = false;
        bossText.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
	}
	
	
	void Update ()
    {
        healthBar.fillAmount = health / maxhealth;
        if (health < maxhealth)
        {
            healthBarBackground.enabled = true;
            healthBar.enabled = true;
            bossText.enabled = true;
        }
		

	}

    //private void Movement()
    //{
    //    //if(Vector2.Distance(transform.position,player.position) < )
    //}
}
