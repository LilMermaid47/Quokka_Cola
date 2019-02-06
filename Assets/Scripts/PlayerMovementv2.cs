using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementv2 : MonoBehaviour
{
    [SerializeField]
    float speed = 12;
    [SerializeField]
    float jumpHeight = 2;
    [SerializeField]
    float airControlDifficulty = 15;

    [Header("Jetpack information")]
    [SerializeField]
    float jetpackFuel = 200;
    [SerializeField]
    float jetpackCapacity = 200;
    [SerializeField]
    float jetpackSpeed = 1000;

    [Header("Debug information")]
    [SerializeField]
    bool grounded;
    [SerializeField]
    float gravityPull = 200;
    [SerializeField]
    Transform cameraTr;

    Rigidbody rb;
    float y;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grounded = true;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            y += 40 * Time.deltaTime;
            cameraTr.rotation = Quaternion.Euler(0, y, 0);
        }
        if(Input.GetKey(KeyCode.E))
        {
            y -= 40 * Time.deltaTime;
            cameraTr.rotation = Quaternion.Euler(0, y, 0);
        }
    }
    private void FixedUpdate()
    {

        Vector3 targetSpeed = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed);
        Vector3 speedChange = (targetSpeed - rb.velocity);

        speedChange.x = Mathf.Clamp(speedChange.x, -10, 10);
        speedChange.y = 0;
        speedChange.z = Mathf.Clamp(speedChange.z, -10, 10);

        if (grounded)
        {
            rb.AddForce(speedChange, ForceMode.VelocityChange);
            if (jetpackFuel < jetpackCapacity)
                jetpackFuel++;
        }
        else
        {
            rb.AddForce(speedChange / airControlDifficulty, ForceMode.VelocityChange);
        }

        if (Input.GetButton("Jump") && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Sqrt(jumpHeight * -Physics.gravity.y * 2), rb.velocity.z);
        }
        else if (Input.GetButton("Jump") && !grounded && jetpackFuel > 0)
        {
            rb.AddForce(0, jetpackSpeed * Time.fixedDeltaTime, 0,ForceMode.Impulse);
            jetpackFuel--;
        }
        else if(!grounded)
        {
            rb.AddForce(0, -gravityPull * Time.fixedDeltaTime, 0, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Ground"))
        {
            grounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag.Contains("Ground"))
            grounded = false;
    }
}
