using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakter : MonoBehaviour
{
    public Rigidbody2D rocketMan;
    public float fart;
    //public float fartY;

    private float xMovement;
    private float yMovement; //--- testing

    void Awake()
    {
        rocketMan = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        yMovement = Input.GetAxis("Vertical") * fart; //--- testing
        xMovement = Input.GetAxis("Horizontal") * fart; 
    }

    void FixedUpdate()
    {
        Vector2 velocity = rocketMan.velocity;
        velocity.x = xMovement;
        //velocity.y = fartY; 
        velocity.y = yMovement; //--- testing
        rocketMan.velocity = velocity;
    }
}
