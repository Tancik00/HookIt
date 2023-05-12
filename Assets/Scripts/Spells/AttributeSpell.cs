using UnityEngine;

[CreateAssetMenu(fileName = "Attribute", menuName = "Spell/Attribute")]
public class AttributeSpell : ScriptableObject
{
	[Header("Description")]
	public string Name;
	public Sprite Icone;

	[Header("Attribute")]
	public float Cooldown;
	public int manaCost;

}
