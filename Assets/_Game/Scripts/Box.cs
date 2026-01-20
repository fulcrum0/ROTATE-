using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] float _rotationAngle = 90f;
    [SerializeField] float _rotationSpeed = 1.5f;


    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0f, 0f, -_rotationAngle * Time.deltaTime * _rotationSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0f, 0f, _rotationAngle * Time.deltaTime * _rotationSpeed);
        }
    }
}
