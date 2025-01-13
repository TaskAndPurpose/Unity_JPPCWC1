using UnityEngine;

public class PlayerMovement_2 : MonoBehaviour
{
    [Header("Player Movement Settings")]
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _movementSpeed = 5.0f;
    [SerializeField] private float _rotationSpeed = 100.0f;

    void Update()
    {
        PlayerController();
    }

    private void PlayerController()
    {
        HandleVerticalMovement();
        HandleHorizontalMovement();
        HandleRotationMovement();
    }

    private void HandleVerticalMovement()
    {
        if (Input.GetKey(KeyCode.Keypad8))
        {
            MoveForward();
        }
        else if (Input.GetKey(KeyCode.Keypad2))
        {
            MoveBackward();
        }
    }

    private void HandleHorizontalMovement()
    {
        if (Input.GetKey(KeyCode.Keypad4))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.Keypad6))
        {
            MoveRight();
        }
    }

    private void HandleRotationMovement()
    {
        if (Input.GetKey(KeyCode.Keypad7))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.Keypad9))
        {
            RotateRight();
        }
    }

    private void MoveForward()
    {
        Vector3 movement = transform.forward * _movementSpeed * Time.DeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + movement);
    }

    private void MoveBackward()
    {
        Vector3 movement = -transform.forward * _movementSpeed * Time.DeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + movement);
    }

    private void MoveLeft()
    {
        Vector3 movement = -transform.right * _movementSpeed * Time.DeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + movement);
    }

    private void MoveRight()
    {
        Vector3 movement = transform.right * _movementSpeed * Time.DeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + movement);
    }

    private void RotateLeft()
    {
        transform.Rotate(Vector3.up, -_rotationSpeed * Time.deltaTime);
    }

    private void RotateRight()
    {
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }
}
