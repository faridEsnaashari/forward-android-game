using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setting
{
    public delegate void _soundStatusChanged(string soundStatus);
    public delegate void _languageChanged(string language);

    public event _soundStatusChanged  soundStatusChanged;
    public event _languageChanged  languageChanged;

    public static setting instance = new setting();

    private setting()
    {

    } 
    public void invokeSoundStatusChanged(string soundStatus)
    {
        soundStatusChanged.Invoke(soundStatus);
    }
    public void invokeLanguageChanged(string language)
    {
        languageChanged.Invoke(language);
    }
}
