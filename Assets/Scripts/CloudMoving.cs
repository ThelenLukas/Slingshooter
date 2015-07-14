using UnityEngine;
using System.Collections;

public class CloudMoving : MonoBehaviour {

	[SerializeField]
	Transform Cloud;
	
	[SerializeField]
	Transform startTransform;

	[SerializeField]
	Transform endTransform;
	[SerializeField]
	float CloudSpeed;

	Vector3 direction;
	Transform destination;

	void Start(){
		SetDestination(startTransform);
	}

	void FixedUpdate(){
		Cloud.GetComponent<Rigidbody>().MovePosition(Cloud.position + direction * CloudSpeed * Time.fixedDeltaTime);

		if (Vector3.Distance (Cloud.position, destination.position) < CloudSpeed * Time.fixedDeltaTime) {
			SetDestination(destination == startTransform ? endTransform : startTransform);
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(startTransform.position, Cloud.localScale);

		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(endTransform.position, Cloud.localScale);
	}

	void SetDestination(Transform dest){
		destination = dest;
		direction = (destination.position - Cloud.position).normalized;
	}

}
