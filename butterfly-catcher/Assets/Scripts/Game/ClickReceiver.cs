using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ButterflyController))]
public class ClickReceiver : MonoBehaviour, IPointerClickHandler
{
    public ButterflyController controller;

    public void OnPointerClick(PointerEventData eventData)
    {
        controller.CatchButterfly();
    }
}
