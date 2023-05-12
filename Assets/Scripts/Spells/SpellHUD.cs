using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellHUD : MonoBehaviour
{
	public List<Image> slotsIcone;
	public List<Image> reloadsIcone;

	private CastSystem p_castSystem;

	void Start()
	{
		p_castSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<CastSystem>();
		slotsIcone[0].sprite = p_castSystem.hookSpell.A_Attribute.Icone;
		
	}
}
