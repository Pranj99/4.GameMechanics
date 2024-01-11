using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody playeRb;
    private GameObject focalPoint;
    // Start is called before the first frame update
    void Start()
    {
        playeRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playeRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        
        
    }
}
