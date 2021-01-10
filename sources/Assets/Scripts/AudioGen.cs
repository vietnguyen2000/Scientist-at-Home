using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioGen : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip[] clips;
    public AudioSource audioSource;
    public bool Flag;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //-------------------------------------Scene1---------------------------------------------------------
    public void BubbleBreak()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        Debug.Log("Clips length: " + clips.Length);
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }

    //public void Start()
    //{
    //    BubbleBreak();
    //}

    //--------------------------------------Scene 2-------------------------------------------------------
    public int index = 0;
    public void KeyBoard()
    {
        AudioClip clip = clips[index%(clips.Length - 1)];
        audioSource.PlayOneShot(clip);
        index++;
    }

    //The last element of the AudioClips list
    public void SpaceBar()
    {
        AudioClip clip = clips[clips.Length];
        audioSource.PlayOneShot(clip);
    }
}
