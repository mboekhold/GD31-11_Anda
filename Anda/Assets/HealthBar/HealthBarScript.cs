using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    Image healthBar;
    public float maxhealth;
    public static float health;
	void Start ()
    {
        healthBar = GetComponent<Image>();
        health = maxhealth;
	}
	
	
	void Update ()
    {
		healthBar.fillAmount = health / maxhealth;
	}
}
