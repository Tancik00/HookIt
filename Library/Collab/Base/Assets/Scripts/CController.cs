using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Windows.WebCam;

public class CController : MonoBehaviour
{
    public bool isDead = false;
    
    private UIController _UiController;
    private NavMeshAgent p_agent = null;
    private Camera p_camera = null;
    private Animator p_animator = null;
    private Hero p_hero = null;
    private Vector3 _moveVector;
    private float _speed = 0.15f;

    private void Start()
    {
        p_agent = GetComponent<NavMeshAgent>();
        p_animator = GetComponentInChildren<Animator>();
        p_hero = GetComponent<Hero>();
        p_camera = Camera.main;
        _UiController = GetComponent<UIController>();
    }

    private void Update()
    {
        Move();
        if (transform.position.y < 0f)
        {
            RunDieEvents();
        }
    }
    
    private void Move()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = Input.GetAxis("Horizontal") * _speed;
        _moveVector.z = Input.GetAxis("Vertical") * _speed;

        if (Vector3.Angle(Vector3.forward, _moveVector) > 1f || Vector3.Angle(Vector3.forward, _moveVector) == 0f)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, _moveVector, 0.05f, 0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        transform.position += _moveVector * _speed;

        if (Input.GetAxis("Horizontal") !=0 || Input.GetAxis("Vertical") != 0)
        {
            p_animator.SetBool("isRun", true);
        }
        else
        {
            p_animator.SetBool("isRun", false);
        }
    }

    public void RunWinEvents()
    {
        p_animator.Play("Armature|WinDance");
        Debug.Log("Player wined!");
        _UiController.Win();
    }

    public void RunDieEvents()
    {
        isDead = true;
        p_animator.Play("Armature|FrontFall");
        Debug.Log("Player died");
        _UiController.Lose();
    }

    private void OnTriggerEnter(Collider _coll)
    {
        if (_coll.CompareTag("finish"))
        {
            Debug.Log("finish");
            RunWinEvents();
        }

        if (_coll.CompareTag("obstacle"))
        {
            RunDieEvents();
        }
    }
}
