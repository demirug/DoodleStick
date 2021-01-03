using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float scale = 1.1f;
    private bool entered = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.localScale = this.transform.localScale * scale;
        this.entered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.localScale = this.transform.localScale / scale;
        this.entered = false;
    }

    private void OnDisable()
    {
        if(this.entered)
        {
            this.entered = false;
            this.transform.localScale = this.transform.localScale / scale;
        }
    }

}
