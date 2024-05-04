using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float _speed = 6.0f;
    public float _gravity = -9.8f;

    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        if (_characterController == null)
            Debug.Log("CharacterController is Null");
    }

    private void Update()
    {
        float DeltaX = Input.GetAxis("Horizontal") * _speed;
        float DeltaZ = Input.GetAxis("Vertical") * _speed;

        /*transform.Translate(DeltaX, 0, DeltaZ);*/
        Vector3 movement = new Vector3(DeltaX,0, DeltaZ);
        movement = Vector3.ClampMagnitude(movement, _speed);

        movement.y = _gravity;
        movement *= Time.deltaTime;

        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
    }
    

}
