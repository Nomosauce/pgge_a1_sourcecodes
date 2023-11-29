using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q3PlayerAudio : MonoBehaviour
{
    public AudioClip[] footstepsTest;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayFootstep()
    {
        Debug.Log("Footstep Noises");
        AudioClip clip = footstepsTest[(int)Random.Range(0, footstepsTest.Length)];
        source.clip = clip;
        source.Play();
        Debug.Log(clip.name);
    }
}
