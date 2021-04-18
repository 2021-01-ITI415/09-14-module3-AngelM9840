using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip splashSound;
    public AudioSource audioS;
    public AudioMixerSnapshot idleSnapshot;
    public AudioMixerSnapshot AuxInSnapshot;

    private void onTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Water"))
        {
            audioS.PlayOneShot(splashSound);
        }

        if(other.CompareTag("EnemyZone"))
        {
            AuxInSnapshot.TransitionTo(0.5f);
        }
    }

    private void onTriggerExit(Collider other) 
    {
        if(other.CompareTag("Water"))
        {
            audioS.PlayOneShot(splashSound);
        }

        if(other.CompareTag("EnemyZone"))
        {
            idleSnapshot.TransitionTo(0.5f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
