using UnityEngine;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{
    public RawImage volumeImage;
    public Texture volumeOff;
    public Text bestScoreText;

    public AudioSource music, jump;

    public static PlayerData userData;

    void Start()
    {
        userData = DataSystem.load();

        this.bestScoreText.text = userData.hightScore.ToString();
        this.updateAudio();
        if (!userData.volumeActive)
        {
            this.volumeImage.texture = this.volumeOff;
        }
    }


    public void updateAudio()
    {
        this.music.enabled = userData.volumeActive;
        this.jump.enabled = userData.volumeActive;
    }

}
