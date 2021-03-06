using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioMixer music, effects;

    public AudioSource backgroundMusic, hit, enemyDead, gems, DragonBall;

    public static AudioManager instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
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

    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }
}
