using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

[System.Serializable]
public class PlayerData
{
    public float score;
    public float health;
    public float exp;
    public PlayerData(float givenScore, float givenHealth, float givenExp)
    {
        score = givenScore;
        health = givenHealth;
        exp = givenExp;
        
    }
    public PlayerData()
    {
        score = 0;
        health = 0;
        exp = 0;
    }
}

public class FileManager : MonoBehaviour
{
    private void Awake()
    {
        if (!File.Exists(Application.persistentDataPath + "/playerdata.dat"))
        {
            File.Create(Application.persistentDataPath + "/playerdata.dat");
        }
    }
    //maybe autoload on awake?
    public void save(PlayerData handedData)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.OpenWrite(Application.persistentDataPath + "/playerdata.dat");

        PlayerData data = handedData;
        bf.Serialize(file, data);
        file.Close();
    }

    public PlayerData load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.OpenRead(Application.persistentDataPath + 
            "/playerdata.dat");
        
        PlayerData data;


        if (file == null)
        {
            data = new PlayerData();
        }
        else
        {
            data = (PlayerData)bf.Deserialize(file);
        }
        file.Close();

        return data;
    }
}
