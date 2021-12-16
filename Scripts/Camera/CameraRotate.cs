using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField]
    private float _mouseSens = 3.0f;

    private float _rotationX;
    private float _rotationY;

    [SerializeField]
    private float _distanceFromTarget;

    [SerializeField]
    private Transform _target;

    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity = Vector3.zero;

    [SerializeField]
    private float _smoothTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSens;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSens;

        _rotationX += mouseY;
        _rotationY += mouseX;

        _rotationX = Mathf.Clamp(_rotationX, 10, 80);

        Vector3 nextRotation = new Vector3(_rotationX, _rotationY);
        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
        transform.localEulerAngles = _currentRotation;
        transform.position = _target.position - transform.forward * _distanceFromTarget;
    }
}
