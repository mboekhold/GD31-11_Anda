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
    
	void Start ()
    {
        healthBar = GetComponent<Image>();
        health = maxhealth;
        healthBarBackground.enabled = true;
        healthBar.enabled = true;
        bossText.enabled = true;
       
        
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

    
}
