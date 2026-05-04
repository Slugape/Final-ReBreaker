using UnityEngine;

public class RocketScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Breaker Ball")
        {
            Destroy(gameObject);
            GameObject.Find("Breaker Ball").GetComponent<BallScript>().rocketOn  = true; 
            Debug.Log(GameObject.Find("Breaker Ball").GetComponent<BallScript>().rocketOn);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    
}
