using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameManager : MonoBehaviour {

    // Use this for initialization
    public float restartDelay = 6f;

    float restartTimer;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthBarScript.health <= 0)
        {
         
            restartTimer += Time.deltaTime;
            if (restartTimer >= restartDelay)
            {

                SceneManager.LoadScene("Restart");
            }
        }
    }
}
