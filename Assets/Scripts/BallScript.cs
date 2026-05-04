using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    //For Ball
    public Rigidbody2D BallRB;
    public float Bspeed = 18f;
    public bool RocketOn = false;
    private bool RocketSpawn = false;
    public GameObject BallRocket;
    public GameObject RocketPFB;
    public GameObject RocketShot;

    private float radius = 1.5f;
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
            //Debug.Log("bouncey");
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 vel = new Vector2(0, BallRB.linearVelocity.y);
        //Ball movement via <- -> arrows
        if (Input.GetKey(KeyCode.D))
        {
            vel.x = Bspeed;
            BallRB.linearVelocity = vel;
            //Debug.Log("yes");
        }

        else if (Input.GetKey(KeyCode.S))
        {
            vel.x = -Bspeed;
            BallRB.linearVelocity = vel;
            //Debug.Log(Input.GetKey(KeyCode.LeftArrow));
        }
       else
        {
            BallRB.linearVelocity = new Vector2(0, BallRB.linearVelocity.y);
        }
        
        if (RocketOn == true && RocketSpawn == false)
        {
            BallRocket = Instantiate(RocketPFB, new Vector2(transform.position.x, transform.position.y +1.5f), Quaternion.identity);
            RocketSpawn = true;
            //Debug.Log("rSpawn");
            
        }

        if (RocketSpawn == true)
        {
            //Math for following mouse
            Vector3 FollowMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = FollowMousePos - BallRocket.transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            BallRocket.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
            //Debug.Log(angle);

            //Follows Ball orbit via polar to cartesian conversion
            BallRocket.transform.position = new Vector2(
                transform.position.x + radius * Mathf.Cos(angle * Mathf.Deg2Rad),
                transform.position.y + radius * Mathf.Sin(angle * Mathf.Deg2Rad));
            
            //Rocket shot
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(RocketShot, BallRocket.transform.position, BallRocket.transform.rotation);
                Destroy(BallRocket);
                BallRocket = null;
                RocketSpawn = false;
                RocketOn = false;
                
            }
        }
    }
}