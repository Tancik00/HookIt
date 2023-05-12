using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObjects : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToGenerate = new List<GameObject>();
    public List<GameObject> generatedObjects = new List<GameObject>();
    [SerializeField] private float timeOffset = 0;

    [SerializeField] private Vector2 Z_range;
    [SerializeField] private float Y_position;

    public int maxCountToGenerate;
    public int currentGenerated = 0;

    private bool canGenerate = true;

    void Update()
    {
        if (currentGenerated < maxCountToGenerate && canGenerate)
        {
            currentGenerated++;
            StartCoroutine(GenerateObject());
        }
    }

    IEnumerator GenerateObject()
    {
        canGenerate = false;

        Vector3 position = new Vector3(transform.position.x, Y_position, Random.Range(Z_range.x, Z_range.y));

        GameObject _obj = Instantiate(objectsToGenerate[Random.Range(0, objectsToGenerate.Count)], position, Quaternion.identity);
        generatedObjects.Add(_obj);

        yield return new WaitForSeconds(timeOffset);
      
        canGenerate = true;
    }
}
