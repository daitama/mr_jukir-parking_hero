using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkCollider : MonoBehaviour
{
    public AudioClip SoundToPlay;
    public float Volume;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "ParkCar")
        {
            Destroy(collider.gameObject);
            audio.PlayOneShot(SoundToPlay, Volume);

            UITextManager.instance.AddScore();
        }
    }
}
