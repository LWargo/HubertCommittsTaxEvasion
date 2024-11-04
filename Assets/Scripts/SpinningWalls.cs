using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningWalls : MonoBehaviour
{
    public float rotateSpeed = 1f;  // Adjust this for your desired rotation speed
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,rotateSpeed);
    }
}
