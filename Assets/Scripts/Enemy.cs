using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Animator animator;
    public List<Vector3> movePoint;

    private CastSystem _castSystem;
    private int index = 0;

    private bool _isEndOfRoad;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        
        _castSystem = GameObject.Find("Hero").GetComponent<CastSystem>();
        
        movePoint.Add(new Vector3(-9f, 23.3f, 2.51f));
        movePoint.Add(new Vector3(-9f, 23.3f, -3.22f));
        movePoint.Add(new Vector3(11.5f, 23.3f, -3.22f));

        transform.Rotate(0f, -90f, 0f);
        
        animator.SetTrigger("isRun");
    }

    private void Update()
    {
        if (!_castSystem.isCanNotMove)
        {
            if (index < movePoint.Count)
            {
                transform.position = Vector3.MoveTowards(transform.position, movePoint[index], 4f * Time.deltaTime);

                if (Vector3.Distance(transform.position, movePoint[index]) < 0.2f)
                {
                    index++;

                    transform.Rotate(0f, transform.rotation.y - 90f, 0f);
                }
            }
        }
        
        if (Vector3.Distance(transform.position, movePoint[movePoint.Count-1]) < 0.5f)
        {
            _isEndOfRoad = true;
        }

        if (_isEndOfRoad)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(transform.position.x, -10f, transform.position.z), 15f * Time.deltaTime);
            if (transform.position.y < 21f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void HitThePlayer(CController player)
    {
        transform.LookAt(player.transform);

        animator.SetTrigger("isGrab");
        player.RunDieEvents();
    }
}
