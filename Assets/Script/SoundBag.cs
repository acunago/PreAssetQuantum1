using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundState
{
    ACTIVE,
    DISABLED
}

public class SoundBag : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip sonido;
    public AudioSource AudManager;
    public SoundState state = SoundState.DISABLED;


    private void Start()
    {
        AudManager =  transform.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(state == SoundState.ACTIVE)
        {
            PlaySound();
        }
    }

    public void PlaySound()
    {
        if (!AudManager.isPlaying)
        {
            AudManager.PlayOneShot(sonido);
        }
    }
}
