using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UntakableObject : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    private bool removed = false;
    private void FixedUpdate()
    {
        if (removed) return;
        transform.Translate(-Vector3.right * speed);

        if(transform.position.x < -70)
        {
            RemoveObject();
        }
    }

    public void RemoveObject()
    {
        removed = true;
        GenerateObjects generator = FindObjectOfType<GenerateObjects>();
        generator.currentGenerated--;
        Destroy(this.gameObject);
    }
}
