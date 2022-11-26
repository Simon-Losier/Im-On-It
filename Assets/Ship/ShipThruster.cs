using UnityEngine;

namespace Ship {
    public class ShipThruster : MonoBehaviour
    {
        private Rigidbody rb;
        [SerializeField] private float projectileSpeed;
        private void Start() {
            rb = GetComponent<Rigidbody>();
        
        }

        void OnCollisionEnter(Collision collision) {
            for (int i = 0; i < collision.contactCount; i++) {
                collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(75, collision.contacts[i].point, 1f);
            }
        
        }
    
        private void FixedUpdate() {
            // rb.velocity = transform.forward * Time.fixedDeltaTime * projectileSpeed;
            rb.AddForce(transform.forward * projectileSpeed * Time.fixedDeltaTime);
        }
    }
}
