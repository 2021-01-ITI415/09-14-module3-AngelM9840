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
    public AudioMixerSnapshot AmbidleSnapshot;
    public AudioMixerSnapshot AmbInSnapshot;


    public LayerMask enemyMask;
    
    bool enemyNear;

    private void Update()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 5f, transform.forward, 0f, enemyMask);

        if (hits.Length > 0)
        {
            enemyNear = true;
        }
        else 
        {
            enemyNear = false;
        }
        if (!AudioManager.manager.eventRunning)
        {
            if (enemyNear)
            {
                if(!AudioManager.manager.auxIn)
                {
                    AuxInSnapshot.TransitionTo(0.5f);
                    AudioManager.manager.currentAudioMixerSnapshot = AuxInSnapshot;
                    AudioManager.manager.auxIn = true;
                }
                else
                {
                    if(AudioManager.manager.currentAudioMixerSnapshot == AudioManager.manager.eventSnap);
                    {
                        AuxInSnapshot.TransitionTo(0.5f);
                        AudioManager.manager.currentAudioMixerSnapshot = AuxInSnapshot;
                        AudioManager.manager.auxIn = true;
                    }
                }
            }
            else 
            {
                if (AudioManager.manager.auxIn)
                {
                    idleSnapshot.TransitionTo(0.5f);
                    AudioManager.manager.currentAudioMixerSnapshot = idleSnapshot;
                    AudioManager.manager.auxIn = false;
                }
                else
                {
                   if(AudioManager.manager.currentAudioMixerSnapshot == AudioManager.manager.eventSnap);
                   {
                    idleSnapshot.TransitionTo(0.5f);
                    AudioManager.manager.currentAudioMixerSnapshot = idleSnapshot;
                    AudioManager.manager.auxIn = false;
                   }
                }
            }
        }
    }

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
        if(other.CompareTag("Ambience"))
        {
            AmbInSnapshot.TransitionTo(0.5f);
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
        if(other.CompareTag("Ambience"))
        {
            AmbidleSnapshot.TransitionTo(0.5f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
