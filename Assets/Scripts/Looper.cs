using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looper : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource _music;
    [SerializeField]private AudioClip start, loop;
    void Awake()
    {
        _music = GetComponent<AudioSource>();
        _music.clip = start;
        _music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (_music.isPlaying) return;
        _music.clip = loop;
        _music.Play();
        _music.loop = true;
    }
}
