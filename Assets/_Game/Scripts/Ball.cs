using UnityEngine;

public class Ball : MonoBehaviour {
    [Header("References")]
    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField] private UI _ui;

    [Header("Settings")]
    [SerializeField] private float _checkGroundDistance;
    [SerializeField] private float _fricitionMultiplier;
    [SerializeField] private LayerMask _layerCheck;

    void FixedUpdate() {
        Friction(_fricitionMultiplier);
    }

    void Friction(float multiplier) {
        // gets the multiplier and applies to the ball
        multiplier = _fricitionMultiplier;
        Vector2 velocity = _rb2d.linearVelocity;
        velocity.x *= multiplier;
        _rb2d.linearVelocity = velocity;
    }

    bool IsGrounded() {
        // uses the distance of the red line to see if the object is grounded
        return Physics2D.Raycast(transform.position, Vector2.down, _checkGroundDistance, _layerCheck);
    }

    void OnDrawGizmos() {
        // draws red line 
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * _checkGroundDistance);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Obstacle")) {
            _ui.TakeDamage(5);
        }
    }
}