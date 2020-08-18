using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundSoundPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    public static backgroundSoundPlayer instance;
    private void Start()
    {
        if(backgroundSoundPlayer.instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(this.gameObject);

        initializeStuff();
    }
    private void initializeStuff()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        setting.instance.soundStatusChanged += makeAudioSourceEnableOrDisable;
    }
    private void makeAudioSourceEnableOrDisable(string soundStatus)
    {
        if(soundStatus == "on")
        {
            audioSource.enabled = true;
            audioSource.Play(0);
        }
        else
        {
            audioSource.enabled = false;
        }
    }
}
