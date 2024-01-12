using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public static class SaveSystem  
{
    
    public static void SaveDate(ScoreManager scoreManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/score.data";
        FileStream stream = new FileStream(path, FileMode.Create);
        Data data = new Data(scoreManager);
        formatter.Serialize(stream, data);
        stream.Close();


    }

    public static Data LoadData()
    {
        string path = Application.persistentDataPath + "/score.data";
         
 
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);            
            Data data = formatter.Deserialize(stream) as Data;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Score file not found at path "+path);
            return null;
        }
         
    }
}
