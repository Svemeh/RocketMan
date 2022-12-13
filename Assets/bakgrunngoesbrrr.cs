using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bakgrunngoesbrrr : MonoBehaviour
{
    [Range(0f, 10f)]
    public float brrrSpeed = 1f; //scrollspeed
    private float offset;
    private Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    
    private void Update()
    {
        offset += (Time.deltaTime * brrrSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
