using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteGeneratedObject : MonoBehaviour
{
    private GenerateObjects generator;
    private void Start()
    {
        generator = FindObjectOfType<GenerateObjects>();
    }
    private void OnCollisionEnter(Collision other)
    {
        
    }
}
