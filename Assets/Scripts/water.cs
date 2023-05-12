using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    public Material material;
    public float speed = 0.5f;

    private float x;

    public void Start()
    {
        material = GetComponent<MeshRenderer>().materials[0];
        x = material.mainTextureOffset.x;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        x -= speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", new Vector2(x, material.mainTextureOffset.y));
    }
}
