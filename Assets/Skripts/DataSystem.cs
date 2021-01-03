using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataSystem
{

    public static void save(PlayerData data)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using(FileStream fs = new FileStream(Application.persistentDataPath + "/player.bin", FileMode.OpenOrCreate))
        {
            binaryFormatter.Serialize(fs, data);
        }
    }

    public static PlayerData load()
    {
        PlayerData player;
        if (File.Exists(Application.persistentDataPath + "/player.bin"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(Application.persistentDataPath + "/player.bin", FileMode.OpenOrCreate))
            {
                player = binaryFormatter.Deserialize(fs) as PlayerData;
            }
        }
        else player = new PlayerData();

        return player;
    }

}
