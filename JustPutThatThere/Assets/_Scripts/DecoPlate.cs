
using UnityEngine;
using UnityEngine.EventSystems;

public class DecoPlate : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

	public void OnEndDrag(PointerEventData eventData)
	{
		this.gameObject.GetComponentInParent<Animator> ().SetBool ("GLISS", true);
	}
}

