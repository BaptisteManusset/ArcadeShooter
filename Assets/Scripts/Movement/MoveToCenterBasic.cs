using UnityEngine;
namespace Movement {
    public class MoveToCenterBasic : MonoBehaviour {
        private Rigidbody rb;

        [Range(0, .1f)] public float speed = .05f;
        private void Awake() => rb = GetComponent<Rigidbody>();
        private void FixedUpdate() {
            Vector3 direction = Vector3.zero - transform.position;


            if (direction.magnitude < 10) return;
            transform.LookAt(Vector3.zero);
            rb.MovePosition(transform.position + ((direction.normalized * speed + transform.right * .1f) * 100 * Time.fixedDeltaTime));
        }
    }
}