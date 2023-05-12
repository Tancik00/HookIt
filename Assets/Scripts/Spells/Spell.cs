using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public AttributeSpell A_Attribute;

	public virtual void A_ActivateSpell(Vector3 _point)
	{
		Debug.Log("Activate");
	}
}
