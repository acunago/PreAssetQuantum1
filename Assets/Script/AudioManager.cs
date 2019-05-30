using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update

    public List<AudioSource> sources = new List<AudioSource>();
    public GameObject sourceHolder;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(this.sourceHolder);
    }

    // Update is called once per frame
    public void PlaySound(AudioClip pClip)
    {
        bool playSong = false;

        if (sources.Count > 0)
        {

            for (int i = 0; i < sources.Count; i++)
            {
                if (sources[i] != null)
                {
                    if (!sources[i].isPlaying)
                    {
                        playSong = true;
                        sources[i].PlayOneShot(pClip);

                        break;
                    }
                }

            }
        }


        if (!playSong)
        {

            GameObject newSrc = (GameObject)Instantiate(sourceHolder);
            sources.Add(newSrc.GetComponent<AudioSource>());
            sources[sources.Count - 1].PlayOneShot(pClip);
        }

    }
    public void PlayOnce(AudioClip pClip)
    {
        if (sources.Count > 0)
        {
            
        }
    }
}
