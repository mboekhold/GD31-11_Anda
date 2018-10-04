using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarScript : MonoBehaviour {

    Image healthBar;
    public float maxhealth;
    public static float health;
    public Image healthBarBackground;
   
    void Start()
    {
        healthBar = GetComponent<Image>();
        health = maxhealth;
        healthBarBackground.enabled = false;
        healthBar.enabled = false;
       
        

    }


    void Update()
    {
        healthBar.fillAmount = health / maxhealth;
        if (health < maxhealth)
        {
            healthBarBackground.enabled = true;
            healthBar.enabled = true;
            
        }


    }
}
