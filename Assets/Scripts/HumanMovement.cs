using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMovement : MonoBehaviour
{
	private List<Vector3> movePoint;

	private void Start()
	{
		movePoint[0] = new Vector3(-9f, 23.3f, 2.51f);
		movePoint[1] = new Vector3(-9f, 23.3f, -3.22f);
		movePoint[2] = new Vector3(11f, 23.3f, -3.22f);
	}
	private void Update()
	{
		int index = 0;
		transform.position = Vector3.MoveTowards(transform.position, movePoint[index], 5f * Time.deltaTime);

		if (Vector3.Distance(transform.position, movePoint[index]) < 0.2f)
		{
			index++;
		}

		if (transform.position == movePoint[2])
		{
			Destroy(gameObject);
		}
	}
}
