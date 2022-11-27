using UnityEngine;

namespace Ship {
    public class ShipThruster : MonoBehaviour
    {
        private Rigidbody rb;
        [SerializeField] private float projectileSpeed;
        [SerializeField] private float explosionForce;
        [SerializeField] private float gracePeriod = 0.2f;
        
        private float gracePeriodTimer;
        
        private void Start() {
            rb = GetComponent<Rigidbody>();
            gracePeriodTimer = gracePeriod;
        }

        void OnCollisionEnter(Collision collision) {
            if (gracePeriodTimer > 0)
                return;
            
            for (int i = 0; i < collision.contactCount; i++) {
                collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, collision.contacts[i].point, 1f);
            }
            Destroy(this.gameObject);
        
        }
    
        private void FixedUpdate() {
            // rb.velocity = transform.forward * Time.fixedDeltaTime * projectileSpeed;
            rb.AddForce(transform.forward * projectileSpeed * Time.fixedDeltaTime);
            gracePeriodTimer -= Time.fixedDeltaTime;
        }
    }
}
