using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forceMultiplier = 4f;
    public float maximumVelocity = 4f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        
        if(rb.velocity.magnitude <= maximumVelocity) {
            rb.AddForce(new Vector3(horizontalInput * forceMultiplier , 0, 0));
        }


    }


    private void OnCollisionEnter(Collision colission)
    {
        if(colission.gameObject.CompareTag("Hazard")) {
            GameManager.GameOver();
            Destroy(gameObject);
        }
    }
}
