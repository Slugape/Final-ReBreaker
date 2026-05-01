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
        Vector3 vel = new Vector3(0, 0, 0);
        //Ball movement via <- -> arrows
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = Bspeed;
            //Debug.Log("yes");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -Bspeed;
            //Debug.Log(Input.GetKey(KeyCode.LeftArrow));
        }
        BallRB.linearVelocity = vel;
       
    }
}
