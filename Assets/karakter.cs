using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakter : MonoBehaviour
{
    public Rigidbody2D rocketMan;
    public float fart;
    private float xMovement;
    //private float yMovement; //--- testing

    private void Awake()
    {
        rocketMan = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //yMovement = Input.GetAxis("Vertical") * fart; //--- testing
        xMovement = Input.GetAxis("Horizontal") * fart; 
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rocketMan.velocity;
        velocity.x = xMovement;
        //velocity.y = yMovement; //--- testing
        rocketMan.velocity = velocity;
    }
}
