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

    public void BubbleBreak()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }

    public void Update()
    {
        if (Flag == true)
        {
            Flag = false;
            BubbleBreak();
        }
    }

    //public void Start()
    //{
    //    BubbleBreak();
    //}
}
