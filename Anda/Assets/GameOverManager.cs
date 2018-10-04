﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    
    public float restartDelay = 5f;
    public Animator anim;
    float restartTimer;
	void Start ()
    {
        anim.GetComponent<Animator>();
        
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerHealthBarScript.health <= 0)
        {
            anim.SetTrigger("GameOver");
            restartTimer += Time.deltaTime;
            if (restartTimer >= restartDelay)
            {

                SceneManager.LoadScene("MainScene");
            }
        }
    }
}
