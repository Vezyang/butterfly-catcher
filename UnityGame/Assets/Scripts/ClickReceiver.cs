using UnityEngine;
using UnityEngine.EventSystems;

public class ClickReceiver : MonoBehaviour, IPointerClickHandler
{
    public ButterflyController controller;

    public void OnPointerClick(PointerEventData eventData)
    {
        controller.CatchButterfly();
    }
}
