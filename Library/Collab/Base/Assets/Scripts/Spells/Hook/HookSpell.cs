using UnityEngine;
using System.Collections;

public class HookSpell : Spell
{
    [Header("Attribute")]
    public float Distance;

    [Header("Reference")]
    public GameObject HookPrefab;
    
    private Vector3 p_stPosition;
    private Animator _animator;
    private Vector3 _pointPos;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    
    public override void A_ActivateSpell(Vector3 _point)
    {
        _animator.SetTrigger("isHook");
        _pointPos = _point;
        StartCoroutine("ActivateSpell");
    }
    
    private IEnumerator ActivateSpell()
    {
        yield return new WaitForSeconds(0.9f);
        p_stPosition = transform.position;
        p_stPosition.y = 1.0f;
        p_stPosition.z = 2.7f;
        
        GameObject _hook = Instantiate(HookPrefab, p_stPosition, Quaternion.identity);
        _hook.GetComponentInChildren<Hook>().Initialize(Distance, p_stPosition, new Vector3(_pointPos.x, 1.0f, _pointPos.z));
    }
}
