using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Hook : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0.5f, 0.1f);
    private bool p_active;

    //private float p_damage;
    private float p_speed = 20.0f;

    private GameObject p_target;
    private LineRenderer p_lrender;
    private CastSystem castSystem;
    private HookSpell _hookSpell;

    private Vector3 p_stPosition;
    private Vector3 p_endDirection;
    private Vector3 p_endPosition;
    private bool p_end;

    private void Awake()
    {
        p_lrender = GetComponentInParent<LineRenderer>();
        castSystem = FindObjectOfType<CastSystem>();
        _hookSpell = FindObjectOfType<HookSpell>();
    }

    public void Initialize(float _rng, Vector3 _stPosition, Vector3 _endPoint)
    {
        p_stPosition = _stPosition;

        p_endDirection = (_endPoint - _stPosition).normalized;
        p_endPosition = _stPosition + (p_endDirection * _rng);

        p_lrender.SetPosition(0, castSystem.gameObject.transform.position + offset);
        p_lrender.SetPosition(1, transform.position);

        transform.LookAt(p_endPosition);

        p_active = true;
        castSystem.canShoot = false;
    }

    private void Update()
    {
        if (p_active)
        {
            if (Vector3.Distance(transform.position, p_endPosition) <= 1.0f)
            {
                if (p_end)
                {
                    GetComponentInParent<DestroyHook>().RemoveHook();
                    castSystem.canShoot = true;
                    _hookSpell._isEnter = false;
                }

                p_endPosition = p_stPosition;
                p_endDirection = (p_stPosition - transform.position).normalized;

                if (p_target != null)
                {
                    castSystem.AddTargetToTheList(p_target.gameObject);
                    p_target = null;
                }

                p_end = true;
            }
            else
            {
                transform.position += p_endDirection * p_speed * Time.deltaTime;

                if (p_end && p_target != null)
                    p_target.transform.position = transform.position;

                if (!p_end)
                    transform.Rotate(new Vector3(0, 0, 15.0f));
            }

            if (!castSystem.isPlayerPulled)
            {
                p_lrender.SetPosition(1, transform.position);
            }
            else
            {
                p_lrender.SetPosition(0, castSystem.gameObject.transform.position);
            }
        }
    }

    private void OnCollisionEnter(Collision _coll)
    {
        if(_coll.gameObject.CompareTag("Unit") && !p_end)
        {
            Debug.Log("unit");
            p_target = _coll.gameObject;
            p_endPosition = p_stPosition;
            p_endDirection = (p_stPosition - transform.position).normalized;
            p_end = true;
            castSystem.pulledHostageCount++;
        }
        
        if (_coll.gameObject.CompareTag("pillar") && !p_end)
        {
            castSystem.movableObject = _coll.gameObject;
            castSystem.isPlayerPulled = true;
            _coll.gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.transform.parent.gameObject.SetActive(false);
            castSystem.canShoot = true;
            _hookSpell._isEnter = false;
        }
        
        if (_coll.gameObject.CompareTag("bonus") && !p_end)
        {
            Destroy(_coll.gameObject);
        }

        if (_coll.gameObject.CompareTag("correctRing") && !p_end)
        {
            castSystem.movableObject = _coll.gameObject.transform.parent.gameObject;
            castSystem.isCorrectPanelMoving = true;
        }

        if (_coll.gameObject.CompareTag("wrongRing") && !p_end)
        {
            castSystem.movableObject = _coll.gameObject.transform.parent.gameObject;
            castSystem.initialMovableObjPos = _coll.gameObject.transform.parent.position;
            castSystem.isWrongPanelMoving = true;
        }

        if (_coll.gameObject.CompareTag("redCube") && !p_end)
        {
            Level5Controller.Instance.Hit("redCube", null);
        }
        if (_coll.gameObject.CompareTag("greenCube") && !p_end)
        {
            Level5Controller.Instance.Hit("greenCube", null);
        }
        if (_coll.gameObject.CompareTag("yellowCube") && !p_end)
        {
            Level5Controller.Instance.Hit("yellowCube", null);
        }

        if (_coll.gameObject.CompareTag("rainbowCube") && !p_end)
        {
            Debug.Log("rainbow cube");
        }

        else 
        {
            if (p_target != null) return;
            p_target = null;
            p_endPosition = p_stPosition;
            p_endDirection = (p_stPosition - transform.position).normalized;
            p_end = true;
        }
    }
}
