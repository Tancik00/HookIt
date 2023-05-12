using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSystem : MonoBehaviour
{
    [Header("Status")] public bool Cast = false;

    [Header("Reference")] public Spell hookSpell;
    public GameObject arrow = null;
    [HideInInspector] public GameObject movableObject;
    [HideInInspector] public Vector3 initialMovableObjPos;
    [HideInInspector] public bool isPlayerPulled;
    [HideInInspector] public bool isCorrectPanelMoving;
    [HideInInspector] public bool isWrongPanelMoving;
    public bool canShoot = true;
    public bool isCanNotMove;
    public float yPos = 0f;
    public float zOffset = 0f;
    public float distance = 0f;
    public int pulledHostageCount = 0;

    public List<GameObject> _targetList = new List<GameObject>();

    private Ray p_ray;
    private RaycastHit p_hit;
    private Camera p_camera = null;

    [SerializeField] private Vector3 positionForTargetPlace;
    [SerializeField] private Vector3 positionForEnemy;

    private CController p_hero = null;

    private Animator _animator;
    private HookSpell _hookSpell;

    private void Start()
    {
        p_camera = Camera.main;
        p_hero = GetComponent<CController>();
        arrow.SetActive(false);
        _hookSpell = GetComponent<HookSpell>();
    }

    private void Update()
    {
        if (canShoot == false) return;

        if (Input.GetMouseButton(0))
        {
            if (rayMousePosition("Terrain"))
            {
                Vector3 dir = p_hit.point - transform.position;
                float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
                arrow.transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
                arrow.SetActive(true);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            hookSpell.A_ActivateSpell(p_hit.point);
            arrow.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (isPlayerPulled)
        {
            PullPlayer();
        }
        
        if (isCorrectPanelMoving)
        {
            MoveCorrectPanel();
        }

        if (isWrongPanelMoving)
        {
            MoveWrongPanel();
        }
    }

    private void PullPlayer()
    {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(movableObject.transform.position.x, yPos, movableObject.transform.position.z + zOffset), 4f * Time.deltaTime);
        if (Vector3.Distance(transform.position, movableObject.transform.position) <= distance)
        {
            isPlayerPulled = false;
        }
    }
    
    private void MoveCorrectPanel() 
    {
        movableObject.transform.localPosition =
            Vector3.Lerp(movableObject.transform.localPosition, new Vector3(0f, 0f, 0.4f), 3f * Time.deltaTime);
        if (movableObject.transform.localPosition.z >= 0.3f)
            isCorrectPanelMoving = false;
    }

    private void MoveWrongPanel()
    {
        movableObject.transform.localPosition =
            Vector3.Lerp(movableObject.transform.localPosition, new Vector3(0f, 0f, 0.4f), 3f * Time.deltaTime);
        if (movableObject.transform.localPosition.z >= 0.3f)
        {
            movableObject.transform.position = initialMovableObjPos;
            isWrongPanelMoving = false;
        }
    }

    private bool rayMousePosition(string _tag)
    {
        p_ray = p_camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(p_ray, out p_hit) && p_hit.collider.CompareTag(_tag))
        {
            return true;
        }

        return false;
    }


    public void AddTargetToTheList(GameObject target)
    {
        _targetList.Add(target);
        MoveTargetPosition(target);
    }

    public void MoveTargetPosition(GameObject target)
    {
        Enemy _enemyComponent = target.GetComponent<Enemy>();
        if (_enemyComponent != null)
        {
            target.transform.position = positionForEnemy;
            canShoot = false;
            _enemyComponent.HitThePlayer(p_hero);
            isCanNotMove = true;
        }
        else
        {
            target.transform.position = positionForTargetPlace;
            positionForTargetPlace += new Vector3(2f, 0f, 0f);

            //int _hostagesCount = FindObjectsOfType<hostage>().Length;

            hostage _hostage = target.GetComponent<hostage>();
            if (_hostage != null)
            {
                _hostage.RunDanceAnimation(p_hero);
            }

            //if (_hostagesCount == _targetList.Count)
            if (pulledHostageCount == 4)
            {
                canShoot = false;
                p_hero.RunWinEvents();
            }
        }
    }
}
