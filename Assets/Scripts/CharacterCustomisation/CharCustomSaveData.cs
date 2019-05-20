
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CharCustomSaveData
{
    public static void SavePlayerData(CustomisationSet customSet)
    {
        //reference to binary formatter
        BinaryFormatter formatter = new BinaryFormatter();

        //path to save to
        string path = Application.persistentDataPath + "/customChar.png";

        //file stream create file at path
        FileStream stream = new FileStream(path, FileMode.Create);

        //dataToSave with player info
        CharDataToSave data = new CharDataToSave(customSet);

        //format and serialize location and data
        formatter.Serialize(stream, data);

        //end
        stream.Close();
        Debug.Log("Saved");
    }
    public static CharDataToSave LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/customChar.png";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            CharDataToSave data = formatter.Deserialize(stream) as CharDataToSave;
            stream.Close();

            return data;

        }
        else
        {
            Debug.Log("No FILE Detected");
            return null;

        }
    }
}
