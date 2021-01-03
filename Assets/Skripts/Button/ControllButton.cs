using UnityEngine;
using UnityEngine.EventSystems;

public class ControllButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public bool handleClick = false;
    public Vector3 pos;
    public MoveController controller;

    private bool validInput = false;

    public void Update()
    {
        
        if (this.validInput)
        {
           this.controller.move(pos);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (this.handleClick) return;
        this.validInput = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.handleClick) return;
        this.validInput = true;
    }

    public void OnDisable()
    {
        this.validInput = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.handleClick)
        {
            this.controller.move(pos);
        }
    }
}
