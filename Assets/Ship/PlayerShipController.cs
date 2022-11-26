using UnityEngine;

namespace Ship
{
    public class PlayerShipController : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed = 125f;
        [SerializeField] private float turnSpeed = 150f;
    
        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.W))
                Throttle(speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            }
        }

        private void Throttle(float force)
        {
            rb.AddForce(force * transform.forward);
        }
    }
}