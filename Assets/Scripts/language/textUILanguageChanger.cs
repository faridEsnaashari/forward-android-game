using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textUILanguageChanger : MonoBehaviour
{
    public string key;
    private Text text;

    private void Start () 
    {
        text = gameObject.GetComponent<Text>();

        initializeLanguage();

        // languageManager.instance.languageChanged += changeLanguage;
    }
    private void initializeLanguage()
    {
        text.text = languageManager.instance.GetLocalizedValue(key);
    }
    public void changeLanguage()
    {
        text.text = languageManager.instance.GetLocalizedValue(key);
    }

}