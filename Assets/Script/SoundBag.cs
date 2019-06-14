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
    public AudioClip[] sonido;
    public AudioSource AudManager;
    public SoundState state = SoundState.DISABLED;


    private void Start()
    {

    }
    private void Update()
    {
        if (state == SoundState.ACTIVE)
        {
            PlaySound();
        }
    }

    public void PlaySound(int sound)
    {
        if (AudManager != null && sonido != null)
        {
            if (!AudManager.isPlaying)
            {
                Debug.Log("Sonido");
                AudManager.PlayOneShot(sonido[sound]);
            }
        }
    }
    public void PlaySound()
    {
        if (AudManager != null && sonido != null)
        {
            if (!AudManager.isPlaying)
            {
                AudManager.PlayOneShot(sonido[0]);
            }
        }
    }
    public void StopSound()
    {
        if (AudManager != null && sonido != null)
        {
            if (AudManager.isPlaying)
            {
                AudManager.Stop();
            }
        }
    }
}
