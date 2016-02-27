using UnityEngine;
using System.Collections;

public class AI_3_Controller : MonoBehaviour {

	public Transform[] points;
	private int destPoint;
	private NavMeshAgent ai3;
	public Transform a3hidepoint;
	public RaycastHit hit;

	void Start(){
		ai3 = GetComponent<NavMeshAgent> ();
		//ai3 = autoBraking = false;
		GoToNextPoint ();
	}

	void GoToNextPoint()
	{
		if (points.Length == 0) 
			return;
		ai3.destination = points [destPoint].position;
		destPoint = (destPoint + 1) % points.Length;
		
	}

	void Update()
	{
		if (ai3.remainingDistance < 0.5f){
			GoToNextPoint ();
		}
			//this uses raycast to check if the other ai is nearby
		if (Physics.Raycast (transform.position, transform.forward, out hit)) {
			if (hit.collider.gameObject.tag == "ai2") {
				StartCoroutine ("pauseAI03");
				Debug.Log ("i saw ai 2");
			}
		}
	}

	IEnumerator pauseAI03()
	{
		ai3.GetComponent<NavMeshAgent>().Stop ();
		Debug.Log ("ai 3 scared");
		yield return new WaitForSeconds (10f);
		ai3.GetComponent<NavMeshAgent>().Resume ();
	}
}

