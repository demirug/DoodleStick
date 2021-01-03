using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public int hightScore = 0;
    public bool volumeActive = true;

    [System.NonSerialized]
    public int currentScore = 0;

}
