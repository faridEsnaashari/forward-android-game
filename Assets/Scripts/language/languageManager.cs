using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class languageManager : MonoBehaviour 
{

    // public delegate void _languageChanged();
    // public event _languageChanged  languageChanged;

    public static languageManager instance;

    private Dictionary<string, string> localizedText;

    // Use this for initialization
    private void Start() 
    {
        if (languageManager.instance == null) 
        {
            instance = this;
        }
        else
        {
            Destroy (gameObject);
        }

        DontDestroyOnLoad (this.gameObject);


        settingStatus ss = fileManager.loadSettingStatus();
        LoadLocalizedText(ss.language);

        setting.instance.languageChanged += changeLanguage;
    }

    public void LoadLocalizedText(string language)
    {
        localizedText = new Dictionary<string, string> ();

        string fileName = getFileName(language);
        TextAsset ta=Resources.Load<TextAsset>(fileName);
        string dataAsJson = ta.text;
        LocalizationData loadedData = JsonUtility.FromJson<LocalizationData> (dataAsJson);
        for (int i = 0; i < loadedData.items.Length; i++) 
        {
            localizedText.Add (loadedData.items [i].key, loadedData.items [i].value);    
        }
    }

    private string getFileName(string language)
    {
        if(language == "persian")
        {
            return "localizedText_fa";
        }
        else
        {
            return "localizedText_en";
        }
    }

    public string GetLocalizedValue(string key)
    {
        return localizedText[key];
    }
    private void changeLanguage(string language)
    {
        settingStatus ss = fileManager.loadSettingStatus();
        ss.language = language;
        fileManager.saveSettingStatus(ss);

        LoadLocalizedText(language);
        changeSettingLanguage();
    }
    private void changeSettingLanguage()
    {
        GameObject[] textUI = GameObject.FindGameObjectsWithTag("settingTextUI");
        foreach(GameObject obj in textUI)
        {
            obj.GetComponent<textUILanguageChanger>().changeLanguage();
        }
    }
}