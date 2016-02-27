using UnityEngine;
using System.Collections;

public class AI_Controller : MonoBehaviour {


		public NavMeshAgent agent_1;
		public GameObject ai_1;
		public GameObject p1start;
		public GameObject p1_1;
		public GameObject p1_2;
		public GameObject p1_3;
		public GameObject p1_4;
		public GameObject p1_5;
		public GameObject rat;
		public RaycastHit looking;
		public bool atp1_1;
		public bool atp1_2;
		public bool atp1_3;
		public bool atp1_4;
		public bool atp1_5;
		public bool atstart1;
		public bool seenRat;
		public bool patrolling;
		public float randTime;
		public CameraControls cams;
		public bool ratsactive = true;




		void Start ()
		{
			agent_1 = ai_1.GetComponent<NavMeshAgent>();
			agent_1.GetComponent<NavMeshAgent>().SetDestination (p1_1.transform.position);
			randTime = Random.Range(0,50);
			cams.Cam1.enabled = true;
			seenRat = false;
			patrolling = true;
		}


//handles the patrol of agent 1
		void OnTriggerEnter(Collider col)
		{
		if (patrolling == true){
			if (col.gameObject.tag == "point1") {
				atp1_1 = true;
				GoToPoint2 ();
				Debug.Log ("reached point 1 1");

			}
			if (col.gameObject.tag == "point2") {
				atp1_2 = true;
				Debug.Log ("reached point 1 2");
				GoToPoint3 ();

			}
			if (col.gameObject.tag == "point3") {
				atp1_3 = true;
				Debug.Log ("reached point 1 3");
				GoToPoint4 ();
			}
			if (col.gameObject.tag == "point4") {
				atp1_4 = true;
				Debug.Log ("reached point 1 4");
				GoToPoint5 ();
			}
			if (col.gameObject.tag == "point5") {
				atp1_5 = true;
				Debug.Log ("reached point 5");
				GoToStart1 ();
			}
			if (col.gameObject.tag == "agent1start") {
				atstart1 = true;
				Debug.Log ("reached start");
				GoToPoint2 ();
			}
//			if (col.gameObject.tag == "rat") {
//				//DestroyObject (rat);
//				rat.SetActive(false);
//				Debug.Log ("I caught the rat");
//				//ratsinscene.ratactive = false;
//				seenRat = false;
//				patrolling = true;
//				GoToPoint2 ();
//				}
		}
		}

		void GoToStart1 ()
		{
			if (patrolling == true) {
				agent_1.GetComponent<NavMeshAgent> ().SetDestination (p1start.transform.position);
				Debug.Log ("agent 1 going to start");
			}
		}


		void GoToPoint2 ()
		{
			if (patrolling == true) {
				agent_1.GetComponent<NavMeshAgent> ().SetDestination (p1_2.transform.position);
				Debug.Log ("going to point 2");
			}
		}

		void GoToPoint3 ()
		{
			if (patrolling == true) {
				agent_1.GetComponent<NavMeshAgent> ().SetDestination (p1_3.transform.position);
				Debug.Log ("going to point 2");
			}
		}

		void GoToPoint4 ()
		{	
			if (patrolling == true) {
				agent_1.GetComponent<NavMeshAgent> ().SetDestination (p1_4.transform.position);
				Debug.Log ("going to point 4");
			}
		}

		void GoToPoint5 ()
		{
			if (patrolling == true) {
				agent_1.GetComponent<NavMeshAgent> ().SetDestination (p1_5.transform.position);
				Debug.Log ("going to point 5");
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
		if (patrolling == true && ratsactive == true) {
					CheckForRat ();
					//StartCoroutine ("Bored");
					//			if (Physics.Raycast (transform.position, transform.forward, out looking)) {
					//				if (looking.collider.gameObject.tag == "ai") {
					//					pacer.GetComponent<NavMeshAgent> ().Stop ();
					//					Debug.Log ("I saw someone!");
					//					WaitnRun ();
					//				}
				}

		if (seenRat == true) {
			patrolling = false;
			agent_1.GetComponent<NavMeshAgent> ().SetDestination (rat.transform.position);
			agent_1.speed = 10f;
			Debug.Log ("chasing rat");
		} else {
			return;
		}
		if (ratsactive == false) {
			agent_1.speed = 3.5f;
			Start ();
		}
//		if (ratsactive == false) {
//			patrolling == true;
//		}
		//		if (seenRat == false && ratsinscene.ratactive == false) {
		//			patrolling = true;
		//		}

	}


	void CheckForRat()
	{
		if (Physics.Raycast (transform.position, transform.forward, out looking)) {
				if (looking.collider.gameObject.tag == "rat") {
					seenRat = true;
					Debug.Log ("yay, a rat!");
					//ChaseRat ();
				} else {
					seenRat = false;
					Debug.Log ("no rats here");
					patrolling = true;
					return;
					
				}
			}
		
	}
		

//		void ChaseRat()
//		{
//			
//			if (seenRat == true) {
//				patrolling = false;
//				agent_1.GetComponent<NavMeshAgent> ().SetDestination (rat.transform.position);
//				agent_1.speed = 10;
//				Debug.Log ("chasing rat");
//			}
//		}

	}
	
