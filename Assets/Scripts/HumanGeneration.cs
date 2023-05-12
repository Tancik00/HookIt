using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanGeneration : MonoBehaviour
{
    public List<GameObject> objects;

    private void Start()
    {
        StartCoroutine("GenerateObjects");
    }

    private IEnumerator GenerateObjects()
    {
        for (int i = 0; i < 6; i++)
        {
            int randomIndex = Random.Range(0, objects.Count);
            Instantiate(objects[randomIndex], new Vector3(9.62f, 23.3f, 2f), Quaternion.identity);
            objects.RemoveAt(randomIndex);
            yield return new WaitForSeconds(2f);
        }
    }
}
