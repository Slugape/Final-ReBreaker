using UnityEngine;

public class BallScript : MonoBehaviour
{
    //For Ball
    public Rigidbody2D BallRB;
    public float Bspeed = 6;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
