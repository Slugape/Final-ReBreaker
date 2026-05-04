using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public GameObject rocketPF;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
       
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Breaker Ball")
        {
            Destroy(gameObject);
            GameObject.Find("Score").GetComponent<ScoreScript>().Score += 50;
            //Debug.Log(GameObject.Find("Score").GetComponent<ScoreScript>().Score);
            Instantiate(rocketPF, transform.position, Quaternion.identity);
            
            
        }
    
    }
}
