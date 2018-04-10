
using UnityEngine;
using UnityEngine.EventSystems;

public class DecoPlate : MonoBehaviour, IDragHandler
{
    [SerializeField] GameObject hiddenContentInstance;

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void ShowHiddenContent()
    {
        hiddenContentInstance.SetActive(true);
    }
}

