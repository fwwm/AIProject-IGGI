using UnityEngine;
using System.Collections;

public class AI_2_Controller_new : MonoBehaviour {

	public NavMeshAgent agent_2;
	public GameObject ai_2;
	public GameObject p2start;
	public GameObject p2_1;
	public GameObject p2_2;
	public GameObject p2_3;
	public GameObject p2_4;
	public GameObject p2_5;
	public GameObject hidepoint1;
	//		public RaycastHit looking;
	public bool atp2_1;
	public bool atp2_2;
	public bool atp2_3;
	public bool atp2_4;
	public bool atp2_5;
	public bool atstart2;
	//		public bool seenRat;
	public bool patrolling;
	public float randTime;
	public CameraControls cams;
	public Trigger trigger;
	public bool a2hiding;
	
	//* new bool to setup restart
	public bool restart;


	void Start ()
	{
		agent_2 = ai_2.GetComponent<NavMeshAgent>();
		agent_2.GetComponent<NavMeshAgent>().SetDestination (p2_1.transform.position);
		randTime = Random.Range(0,50);
		cams.Cam1.enabled = true;
		//seenRat = false;
		patrolling = true;
		a2hiding = false;
		//restart = false;
	}


	//handles the patrol of agent 2
	void OnTriggerEnter(Collider col)
	{
		//* This sets-up the restart when hiding
		if (col.gameObject.tag == "hidepoint1") {
				restart = true;
			}
		if (patrolling == true){
			if (col.gameObject.tag == "2point1") {
				atstart2 = false;
				//restart = false;
				atp2_1 = true;
				GoToPoint2 ();
				Debug.Log ("reached point 2 1");

			}
			if (col.gameObject.tag == "2point2") {
				atp2_2 = true;
				atp2_1 = false;
				Debug.Log ("reached point 2 2");
				GoToPoint3 ();

			}
			if (col.gameObject.tag == "2point3") {
				atp2_3 = true;
				atp2_2 = false;
				Debug.Log ("reached point 2 3");
				GoToPoint4 ();
			}
			if (col.gameObject.tag == "2point4") {
				atp2_4 = true;
				atp2_5 = false;				
				Debug.Log ("reached point 2 4");
				GoToPoint5 ();
			}
			if (col.gameObject.tag == "2point5") {
				atp2_5 = true;
				atp2_4 = false;
				Debug.Log ("reached point 2 5");
				GoToStart1 ();
			}
			if (col.gameObject.tag == "agent2start") {
				atstart2 = true;
				atp2_5 = false;
				Debug.Log ("reached 2 start");
				GoToPoint2 ();
			}
			
			//			if (col.gameObject.tag == "rat") {
			//				Destroy (rat);
			//				Debug.Log ("I caught the rat");
			//				GoToPoint2 ();
			//}
		}
	}

	void GoToStart1 ()
	{
		if (patrolling == true) {
			agent_2.GetComponent<NavMeshAgent> ().SetDestination (p2start.transform.position);
			Debug.Log ("agent 2 going to start");
		}
	}


	void GoToPoint2 ()
	{
		if (patrolling == true) {
			agent_2.GetComponent<NavMeshAgent> ().SetDestination (p2_2.transform.position);
			Debug.Log ("2 going to point 2");
		}
	}

	void GoToPoint3 ()
	{
		if (patrolling == true) {
			agent_2.GetComponent<NavMeshAgent> ().SetDestination (p2_3.transform.position);
			Debug.Log ("2 going to point 2");
		}
	}

	void GoToPoint4 ()
	{	
		if (patrolling == true) {
			agent_2.GetComponent<NavMeshAgent> ().SetDestination (p2_4.transform.position);
			Debug.Log ("2 going to point 4");
		}
	}

	void GoToPoint5 ()
	{
		if (patrolling == true) {
			agent_2.GetComponent<NavMeshAgent> ().SetDestination (p2_5.transform.position);
			Debug.Log ("2 going to point 5");
		}
	}

	public void AvoidLight ()
	{
		//StartCoroutine("pauseCamChange");

		if (trigger.lightson == true) {
			agent_2.GetComponent<NavMeshAgent> ().SetDestination (hidepoint1.transform.position);
			a2hiding = true;
			Debug.Log ("ai 2 hiding!");
//		}if (ai02.enabled == true && trigger.lightson == true) {
//			ai02.GetComponent<NavMeshAgent> ().SetDestination (hidepoint2.transform.position);
//			ai2hiding = true;
//			Debug.Log ("ai 2 hiding!");
		} else if (a2hiding == false) {
			restart = true;
			patrolling = true;
			GoToPoint2 ();
			return;
		}


	}

	//		void WaitnRun ()
	//		{
	//			if (patrolling == true) {
	//				StartCoroutine ("pause");
	//				pacer.GetComponent<NavMeshAgent> ().SetDestination (home.transform.position);
	//				pacer.speed = 7;
	//			}
	//		}

	//		void NewRoute()
	//		{
	//			if (patrolling == true) {
	//				pacer.GetComponent<NavMeshAgent> ().SetDestination (otherpatrolstart.transform.position);
	//			} 
	//		}
	//
	//		IEnumerator Bored ()
	//		//at a random time, change patrol route
	//		{
	//			yield return new WaitForSeconds (randTime);
	//			Debug.Log (randTime);
	////			NewRoute ();
	//			Debug.Log ("changing route");
	//		}

	//		IEnumerator pause()
	//		{
	//			yield return new WaitForSeconds (0.5f);
	//			pacer.GetComponent<NavMeshAgent> ().Resume ();
	//			Debug.Log ("I'd better run home");
	//		}

	void Update()
	{
		if (a2hiding == false && restart == true) {
			//* restarts the script
			Restarting();
			patrolling = true;
			restart = false;
			//CheckForRat ();
			//StartCoroutine ("Bored");
			//			if (Physics.Raycast (transform.position, transform.forward, out looking)) {
			//				if (looking.collider.gameObject.tag == "ai") {
			//					pacer.GetComponent<NavMeshAgent> ().Stop ();
			//					Debug.Log ("I saw someone!");
			//					WaitnRun ();
			//				}
		//}
		}
		if (trigger.lightson == true) {
			patrolling = false;
			AvoidLight ();
			Debug.Log ("avoiding lights");
			
		} else {
			a2hiding = false;
			//restart = true;
			//Debug.Log ("walking about");
		}
	}
	void Restarting(){
		if (restart == true) {
			Start ();
		} else {
			return;
		}
	}
}

