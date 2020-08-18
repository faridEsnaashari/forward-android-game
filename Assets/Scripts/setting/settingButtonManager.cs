using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settingButtonManager : MonoBehaviour
{
    public void turnSoundOn()
    {
        setting.instance.invokeSoundStatusChanged("on");
    }
    public void turnSoundOff()
    {
        setting.instance.invokeSoundStatusChanged("off");
    }
    public void changeLangToPersian()
    {
        setting.instance.invokeLanguageChanged("persian");
    }
    public void changeLangToEnglish()
    {
        setting.instance.invokeLanguageChanged("english");
    }
    public void loadMainMenuScene()
    {
        SceneManager.LoadScene("mainMenu" , LoadSceneMode.Single);
    }
}
