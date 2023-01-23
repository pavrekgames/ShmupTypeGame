using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadScore : MonoBehaviour
{
   
   public void SaveData()
    {
        FileStream file = File.Create(Application.persistentDataPath + "/ShmupGameSave.pav");

        GameData gameData = new GameData();

        gameData.bestScore = GameManager.bestScore;

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, gameData);

        file.Close();

    }

    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/ShmupGameSave.pav"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/ShmupGameSave.pav", FileMode.Open);

            BinaryFormatter bf = new BinaryFormatter();

            GameData gameData = (GameData)bf.Deserialize(file);

            file.Close();

            GameManager.bestScore = gameData.bestScore;

        }

    }

    [Serializable]
    class GameData
    {
        public int bestScore;
    }

}
