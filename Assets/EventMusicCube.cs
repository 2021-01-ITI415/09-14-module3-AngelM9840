using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMusicCube : MonoBehaviour
{
    public AudioClip eventClip;

    private void onTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        AudioManager.manager.eventMusic.clip = eventClip;
        AudioManager.manager.StartCoroutine("PlayEventMusic");
        }
    }
}
