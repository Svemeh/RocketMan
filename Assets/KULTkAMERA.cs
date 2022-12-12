using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KULTkAMERA : MonoBehaviour
{
    public Transform kamera;
    public Transform rocketMan;

    void Update()
    {
        kamera.position = new Vector3(kamera.position.x, rocketMan.position.y+2, kamera.position.z);  
    }
}
