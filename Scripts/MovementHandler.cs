using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private InputHandler _input;
    private Animator _animator;

    [SerializeField]
    private float move_speed;

    [SerializeField]
    private Camera camera;

    [SerializeField]
    private float rotate_speed;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        move_speed = player.GetSpeed();
    }

    private void Awake()
    {
        _input = GetComponent<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);
        var movementVector = MoveToward(targetVector);

        if (targetVector != new Vector3(0,0,0))
        {
            _animator.SetBool("isRunning", true);
        } else
        {
            _animator.SetBool("isRunning", false);
        }
        move_speed = player.GetSpeed();
        RotateTowardMovement(movementVector);

        setTheFlashMode();
    }

    private Vector3 MoveToward(Vector3 targetVector)
    {
        targetVector = Quaternion.Euler(0, camera.gameObject.transform.eulerAngles.y, 0) * targetVector;
        var speed = move_speed * Time.deltaTime;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }

    void RotateTowardMovement(Vector3 movementVector)
    {
        if(movementVector.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotate_speed);
    }

    void setTheFlashMode()
    {
        if(move_speed >= 11)
        {
            _animator.SetBool("theFlashMode", true);
        }
    }
}
