using UnityEngine;

public class Ball : MonoBehaviour {
    [Header("References")]
    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField] private UI _ui;
    [SerializeField] private Transform _startPoint;

    [Header("Friction Settings")]
    [SerializeField] private float _platformFricitionMultiplier;
    [SerializeField] private float _mudFricitionMultiplier;
    private float _currentFrictionMultiplier;
    [Header("Ground Check Settings")]
    [SerializeField] private float _checkGroundDistance;
    [SerializeField] private LayerMask _layerCheck;

    void FixedUpdate() {
        if (!IsGrounded()) { return; }
        ApplyFriction();
    }

    void ApplyFriction() {
        // gets the multiplier and applies to the ball

        Vector2 velocity = _rb2d.linearVelocity;
        velocity.x *= _currentFrictionMultiplier;
        _rb2d.linearVelocity = velocity;
    }

    bool IsGrounded() {
        // uses the distance of the red line to see if the object is grounded
        // returns true if line hits the ground
        Vector2 origin = transform.position;

        return Physics2D.Raycast(origin, Vector2.down, _checkGroundDistance, _layerCheck);
    }

    // void OnDrawGizmos() {
    //     draws red line 
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawLine(transform.position, transform.position + Vector3.down * _checkGroundDistance);
    // }

    // void OnTriggerEnter2D(Collider2D collision) {
    //     if (collision.gameObject.CompareTag("FinishPoint")) {
    //         transform.position = _startPoint.position;
    //     }
    // }

    // void OnCollisionEnter2D(Collision2D collision) {
    //     if (collision.gameObject.CompareTag("Cactus")) {
    //         _ui.UpdateHealth(5);
    //     }
    //     else if (collision.gameObject.CompareTag("Mud")) {
    //         _currentFrictionMultiplier = _mudFricitionMultiplier;
    //     }
    //     else if (collision.gameObject.CompareTag("Spike")) {
    //         transform.position = _startPoint.position;
    //     }
    // }

    // void OnCollisionExit2D(Collision2D collision) {
    //     if (collision.gameObject.CompareTag("Mud")) {
    //         _currentFrictionMultiplier = _platformFricitionMultiplier;
    //     }
    // }
}