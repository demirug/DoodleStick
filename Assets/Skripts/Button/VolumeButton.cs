using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VolumeButton : MonoBehaviour, IPointerClickHandler {

    public Logic logic;
    public Texture volumeOn, volumeOff;

    private RawImage rawImage;

    public void Start()
    {
        this.rawImage = GetComponent<RawImage>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Logic.userData.volumeActive = !Logic.userData.volumeActive;
        logic.updateAudio();
        DataSystem.save(Logic.userData);
        rawImage.texture = Logic.userData.volumeActive ? this.volumeOn : this.volumeOff;

        

    }
}
