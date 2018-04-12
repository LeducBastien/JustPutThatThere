
using UnityEngine;
using UnityEngine.EventSystems;

public class DecoPlate : MonoBehaviour
{
	public void OnClick()
	{
		this.gameObject.GetComponentInParent<Animator> ().SetBool ("GLISS", true);
	}
}

