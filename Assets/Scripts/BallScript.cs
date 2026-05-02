using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    //For Ball
    public Rigidbody2D BallRB;
    public float Bspeed = 18f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BallRB.linearVelocity = new Vector2(0,Bspeed +10f); 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Paddle")
        {
            BallRB.linearVelocity = new Vector2(BallRB.linearVelocity.x,Bspeed+10f); 
            Debug.Log("bouncey");
        }

       
        
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 vel = new Vector2(0, BallRB.linearVelocity.y);
        //Ball movement via <- -> arrows
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = Bspeed;
            BallRB.linearVelocity = vel;
            //Debug.Log("yes");
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -Bspeed;
            BallRB.linearVelocity = vel;
            //Debug.Log(Input.GetKey(KeyCode.LeftArrow));
        }
       else
        {
            BallRB.linearVelocity = new Vector2(0, BallRB.linearVelocity.y);
        }
        
      
    }
}
