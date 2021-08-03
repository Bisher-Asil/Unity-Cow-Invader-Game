using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera mainCam;
    public Rigidbody rb;
    Vector3 mousePos;
    public float mouseMovespeed;
    Vector3 position = new Vector3 (0f,0f,0f); 
    public float tiltamount;

    private void Start() {
        rb = this.GetComponent<Rigidbody>();

    }
    // Update is called once per frame
    void Update()
    {
        mousePos =  mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,transform.position.z));
        // Debug.Log(mousePos);
        position = Vector3.Lerp(transform.position, mousePos, mouseMovespeed);
    }

    private void FixedUpdate() {
        rb.MovePosition(position);
        rb.rotation= Quaternion.Euler(270f,0.0f,-tiltamount*rb.velocity.x);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.tag);
    }

}
