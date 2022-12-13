using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public Rigidbody2D obstacle;
    [SerializeField] GameObject plane; // bakgrunn, defineres i Awake
    bakgrunngoesbrrr backgroundScript; // bakgrunn script

    private void OnCollisionEnter2D(Collision2D collision)
    {

            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>(); // kræsj trigger
        if (rb != null)
            {
                Debug.Log("hit");
            }
    }

    private void Awake()
    {
        plane = GameObject.Find("Plane");
        obstacle = GetComponent<Rigidbody2D>();
        backgroundScript = plane.GetComponent<bakgrunngoesbrrr>();
    }
    private void FixedUpdate()
    {
        Vector2 velocity = obstacle.velocity;
        velocity = new Vector3(0, -(backgroundScript.brrrSpeed*2), 0); // fart defienert som scrollspeed * 2
        obstacle.velocity = velocity;
    }
}
