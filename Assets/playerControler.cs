using UnityEngine;

public class playerControler : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 125f;
    public float turnSpeed = 150f;
    
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        { 
            rb.AddForce(transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
    }
}