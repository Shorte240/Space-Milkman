using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {
	
	Vector3 
		posA, 
		posB, 
		nextPos;

	[SerializeField]
	float speed;

	[SerializeField]
	Transform childTransform;

	[SerializeField]
	Transform transformB;

	// Use this for initialization
	void Start ()
	{
		posA = childTransform.transform.localPosition;
		posB = transformB.transform.localPosition;
		nextPos = posB;
	}
		
	// Update is called once per frame
	void Update ()
	{
		Move ();
	}

	void Move()
	{
		childTransform.localPosition = Vector3.MoveTowards (childTransform.localPosition, nextPos, speed * Time.deltaTime);

		if (Vector3.Distance(childTransform.localPosition, nextPos) <= 0.1)
			ChangeDestination();
	}

	void ChangeDestination()
	{
		nextPos = nextPos != posA ? posA : posB;
	}
}
