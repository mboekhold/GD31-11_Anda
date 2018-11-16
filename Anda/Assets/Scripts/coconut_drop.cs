using UnityEngine;
using UnityEngine.UI;

public class coconut_drop : MonoBehaviour
{
    [SerializeField]
    public Text text;

    
	// Use this for initialization
	void Start ()
    {
        text.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("Player"))
        {
          
            Destroy(gameObject);
            text.enabled = true;
        }
    }
}
