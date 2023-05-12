using UnityEngine;
using System.Collections;

public class HookSpell : Spell
{
    [Header("Attribute")]
    public float Distance;

    [Header("Reference")]
    public GameObject HookPrefab;

    public GameObject hook;

    public bool isPlayerRotate;
    
    private Vector3 p_stPosition;
    private Animator _animator;
    private Vector3 _pointPos;
    public bool _isEnter;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    
    public override void A_ActivateSpell(Vector3 _point)
    {
        if (!_isEnter)
        {
            if (isPlayerRotate)
                transform.rotation = Quaternion.identity;
            _animator.SetTrigger("isHook");
            _pointPos = _point;
            StartCoroutine("ActivateSpell");
            _isEnter = true;
        }
    }
    
    private IEnumerator ActivateSpell()
    {
        yield return new WaitForSeconds(0.9f);
        p_stPosition = transform.position;
        p_stPosition.y += 1f;
        p_stPosition.z += 0.7f;
        hook = Instantiate(HookPrefab, p_stPosition, Quaternion.identity);
        hook.GetComponentInChildren<Hook>().Initialize(Distance, p_stPosition, new Vector3(_pointPos.x, _pointPos.y + 1f, _pointPos.z));
    }
}
