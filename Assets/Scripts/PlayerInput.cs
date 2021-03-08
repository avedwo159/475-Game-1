using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public float speed = 0.0f;

    public float speedCap = 0.5f;
    public float speedMod = 0.05f;
    public float speedDrag = 0.01f;
    public float gravity = -20f;

    //jump
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    Rigidbody rb;

    private GameObject target;
    void Start()
    {
        target = GameObject.Find("Cube");

        //jump 
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        float hVal = Input.GetAxis("Horizontal");
        float vVal = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.D))
        {
            if (speed > speedCap) { }
            else speed += speedMod;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (speed < -speedCap) { }
            else speed -= speedMod;
        }
        else
        {
            if (speed < 0)
                speed += speedDrag;
            if (speed > 0)
                speed -= speedDrag;
            if (speed < speedDrag && speed > -speedDrag)
                speed = 0.0f;

        }

        //-0.00999921

        //move left & right
        target.transform.Translate(speed, 0f, 0f);

        rb.AddForce(0, gravity, 0);

        //jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    }
}
