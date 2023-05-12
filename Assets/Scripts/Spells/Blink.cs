using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : Spell
{ 
    //protected AttributeSpell _attribute;
    //public override AttributeSpell A_Attribute{get { return _attribute;} set{ _attribute = value;}}

    public override void A_ActivateSpell(Vector3 _point)
    {
    	transform.position = _point;
    }

}
