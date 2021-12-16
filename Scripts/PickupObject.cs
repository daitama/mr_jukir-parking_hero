using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    [SerializeField]
    private Transform pickup_pos;

    private Animator _animator;

    private bool is_picking_up;
    public Collider collided_object;

    public AudioClip SoundToPlay;
    public float Volume;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (collided_object)
        {
            if (is_picking_up == false && Input.GetKey(KeyCode.LeftShift))
            {
                collided_object.gameObject.GetComponent<Rigidbody>().useGravity = false;
                collided_object.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                collided_object.gameObject.transform.position = pickup_pos.position;
                collided_object.gameObject.transform.rotation = new Quaternion();
                collided_object.transform.parent = GameObject.Find("Player").transform;

                is_picking_up = true;
                _animator.SetBool("isPickingUp", true);
                audio.PlayOneShot(SoundToPlay, Volume);
                
            }

            if(is_picking_up == true && Input.GetKey(KeyCode.LeftControl))
            {
                collided_object.gameObject.GetComponent<Rigidbody>().useGravity = true;
                collided_object.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                collided_object.gameObject.transform.position = pickup_pos.position + GameObject.Find("Player").GetComponent<Transform>().forward*3;
                collided_object.transform.parent = null;
                collided_object = null;
                is_picking_up = false;
                _animator.SetBool("isPickingUp", false);
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!collided_object)
        {
            if (collider.gameObject.tag == "ParkCar")
            {
                collided_object = collider;
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collided_object.gameObject.tag == "ParkCar" && !is_picking_up)
        {
            collided_object = null;
        }
    }
}
