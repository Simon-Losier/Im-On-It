using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Ship {
    public class ShipThruster : MonoBehaviour
    {
        private Rigidbody rb;
        [SerializeField] private float projectileSpeed;
        [SerializeField] private float explosionForce;
        [SerializeField] private float gracePeriod = 0.2f;
        [SerializeField] private float chargeForce;
        [SerializeField] private float maxChargeTime;
        private bool isCharging;
        private float chargeTime;
        

        private float gracePeriodTimer;
        
        private void Start() {
            rb = GetComponent<Rigidbody>();
            gracePeriodTimer = gracePeriod;
        }

        private void Update() {
            ChargeShot();
        }

        void OnCollisionEnter(Collision collision) {
            if (gracePeriodTimer > 0)
                return;
            
            for (int i = 0; i < collision.contactCount; i++) {
                collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, collision.contacts[i].point, 1f);
            }
            Destroy(this.gameObject);
        
        }

        void ChargeShot() {
            if (PlayerInputManager.Instance.Left && PlayerInputManager.Instance.Right) {
                isCharging = true;
                chargeTime += Time.deltaTime;
                if (chargeTime > maxChargeTime) {
                    chargeTime = maxChargeTime;
                }
            }
            else {
                isCharging = false;
                chargeTime = 0;
            }
            
            // rb.AddForce(transform.forward * chargeForce * Time.deltaTime * chargeTime);
        }
        
        private void FixedUpdate() {
            // rb.velocity = transform.forward * Time.fixedDeltaTime * projectileSpeed;
            // rb.AddForce(transform.forward * chargeForce * Time.deltaTime * chargeTime);
            // rb.velocity += transform.forward * Time.fixedDeltaTime * chargeTime;
            rb.transform.position += transform.forward * chargeForce * Time.fixedDeltaTime * chargeTime;
            rb.AddForce(transform.forward * projectileSpeed * Time.fixedDeltaTime);
            
            gracePeriodTimer -= Time.fixedDeltaTime;
        }
    }
}
