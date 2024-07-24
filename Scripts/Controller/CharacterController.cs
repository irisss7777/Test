using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Rigidbody2D _rigidbogy;
    [SerializeField] private float _moveSpeed;

    void FixedUpdate()
    {
        MoveWithJoyStick();
    }

    private void MoveWithJoyStick()
    {
        _rigidbogy.velocity = new Vector2(_joystick.Horizontal * _moveSpeed, _joystick.Vertical * _moveSpeed);
    }
}
