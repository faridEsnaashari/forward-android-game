using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class fileManager
{
    public static void savePlayerStatus(playerStatus ps)
    {
        BinaryFormatter formatter=new BinaryFormatter();
		string path=Application.persistentDataPath+"/playerStatus.forward";
		FileStream stream=new FileStream(path,FileMode.Create);
		Debug.Log(path);

		formatter.Serialize(stream,ps);
		stream.Close();
    }

    public static playerStatus loadPlayerStatus()
    {
		playerStatus ps = new playerStatus();
		if(!isplayerStatusExists())
		{
			savePlayerStatus(ps);
		}
        
		BinaryFormatter formatter=new BinaryFormatter();
		string path=Application.persistentDataPath+"/playerStatus.forward";
		FileStream stream=new FileStream(path,FileMode.Open);
		
		ps = formatter.Deserialize(stream) as playerStatus;
		stream.Close();
		
        return ps;
    }
	public static bool isplayerStatusExists()
	{
		string path=Application.persistentDataPath+"/playerStatus.forward";
        bool firstTime=File.Exists(path);
		return firstTime;
	}
	public static void saveSettingStatus(settingStatus ss)
    {
        BinaryFormatter formatter=new BinaryFormatter();
		string path=Application.persistentDataPath+"/settingStatus.forward";
		FileStream stream=new FileStream(path,FileMode.Create);

		formatter.Serialize(stream,ss);
		stream.Close();
    }

    public static settingStatus loadSettingStatus()
    {
		settingStatus ss = new settingStatus();
		if(!ispSettingStatusExists())
		{
			saveSettingStatus(ss);
		}
        
		BinaryFormatter formatter=new BinaryFormatter();
		string path=Application.persistentDataPath+"/settingStatus.forward";
		FileStream stream=new FileStream(path,FileMode.Open);
		
		ss = formatter.Deserialize(stream) as settingStatus;
		stream.Close();
		
        return ss;
    }
	public static bool ispSettingStatusExists()
	{
		string path=Application.persistentDataPath+"/settingStatus.forward";
        bool firstTime=File.Exists(path);
		return firstTime;
	}
}
