using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 10;
    public float rotSpeed = 10;
    public float lookSpeed = 5;
    public float jumpHeight = 10;

    Rigidbody rb;

    void Start() {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        float rotate = Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
        Vector3 move = transform.forward * Input.GetAxis("Vertical");
        Vector3 stafe = transform.right * Input.GetAxis("Horizontal");

        if (Input.GetAxis("Vertical") != 0 && Input.GetAxis("Horizontal") != 0) {
            rb.AddForce(move * (speed * 0.6f), ForceMode.Impulse);
            rb.AddForce(stafe * (speed * 0.6f), ForceMode.Impulse);
        } else {
            rb.AddForce(move * speed, ForceMode.Impulse);
            rb.AddForce(stafe * speed, ForceMode.Impulse);
        }
        
        transform.Rotate(0, rotate, 0);

        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }
}
