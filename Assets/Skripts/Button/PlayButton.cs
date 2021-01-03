using UnityEngine;
using UnityEngine.EventSystems;
public class PlayButton : MonoBehaviour, IPointerClickHandler
{

    public GameObject stickman, gameCanvas, pauseCanvas;
    public ObjectSpawner spawner;

    public void OnPointerClick(PointerEventData eventData)
    {
        this.stickman.transform.position = new Vector3(-5, 0, 0);
        this.stickman.transform.rotation = new Quaternion(0, 0, 0, 0);
        this.stickman.SetActive(true);
        this.pauseCanvas.SetActive(false);
        this.gameCanvas.SetActive(true);
        this.spawner.start();
    }
}
