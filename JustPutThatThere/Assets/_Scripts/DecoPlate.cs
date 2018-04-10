
using UnityEngine;
using UnityEngine.EventSystems;

public class DecoPlate : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
}

