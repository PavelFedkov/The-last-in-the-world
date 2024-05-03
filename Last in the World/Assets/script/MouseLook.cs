using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // задаём координаты по которым будет происходить вращение
    public enum RorationAxes 
    { 
        XandY,
        X,
        Y

    }
    //Общедоступная переменная для Unity
    public RorationAxes _axes = RorationAxes.XandY;

    //Задаём скорость вращения по горизонтали
    public float _rotetionSpeedHor = 5.0f;
    //Задаём скорость вращения по вертикали
    public float _rotetionSpeedVer = 5.0f;

    public float maxVert = 45.0f;
    public float minVert = -45.0f;

    private float _rotationX = 0;

    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }

    private void Update()
    {
        // Проверим ось двиения
        if(_axes == RorationAxes.XandY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _rotetionSpeedVer;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * _rotetionSpeedHor;
            float _rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
        else if(_axes == RorationAxes.X)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * _rotetionSpeedHor, 0);
        }
        else if (_axes == RorationAxes.Y) 
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _rotetionSpeedVer;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            float _rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }



    }



}
