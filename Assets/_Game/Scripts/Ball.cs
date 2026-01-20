using UnityEngine;

public class Ball : MonoBehaviour {
    [Header("References")]
    [SerializeField] private Rigidbody2D _rb2d;

    [Header("Settings")]
    [SerializeField] private float _checkGroundDistance = 0.18f;
    [SerializeField] private LayerMask _layerCheck;

    void FixedUpdate() {
        Friction();
    }

    void Friction() {
        Vector2 velocity = _rb2d.linearVelocity;

        float friction = 0.85f;
        velocity.x *= friction;
        _rb2d.linearVelocity = velocity;
    }

    bool IsGrounded() {
        // Global world down yönünde raycast
        return Physics2D.Raycast(transform.position, Vector2.down, _checkGroundDistance, _layerCheck);
    }

    void OnDrawGizmos() {
        // Global down (kırmızı) çizgi
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * _checkGroundDistance);
    }
}