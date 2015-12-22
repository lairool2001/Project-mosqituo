using UnityEngine;
using System.Collections;

public class NavVer2 : MonoBehaviour {

    // Use this for initialization
    public Transform TargetObject = null;
    public Transform way1;
    public Transform way2;
    public Transform way3;
    public Transform way4;
    private int random=1;
    private int startpoint = 1;
    private float movetime=4;
    public float time;
    public Transform navmob;


    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        pointmove();

    }
    void pointmove()
    {
        
        
            if (startpoint == 1)
            {
                TargetObject = way1;
                if (TargetObject != null)
                {
                    GetComponent<NavMeshAgent>().destination = TargetObject.position;
                    if (Vector3.Distance(navmob.position, TargetObject.position) < 1.5f)
                        {
                        startpoint++;
                        }
                }

            }
            else if(startpoint ==2)
            {
                TargetObject = way2;
                if (TargetObject != null)
                {
                    GetComponent<NavMeshAgent>().destination = TargetObject.position;
                    if (Vector3.Distance(navmob.position,TargetObject.position)<1.5f)
                     {
                         startpoint++;
                     }
            }
            }
            else if(startpoint ==3)
            {
                TargetObject = way3;
                if (TargetObject != null)
                {
                    GetComponent<NavMeshAgent>().destination = TargetObject.position;
                    if (Vector3.Distance(navmob.position, TargetObject.position) < 1.5f)
                     {
                            startpoint++;
                      }
            }
            }
            else if(startpoint ==4)
            {
                TargetObject = way4;
                if (TargetObject != null)
                {
                    GetComponent<NavMeshAgent>().destination = TargetObject.position;
                        if (Vector3.Distance(navmob.position, TargetObject.position) < 1.5f)
                        {
                            startpoint=1;
                        }
                 }
            }


        
        
    }


    void NavRandomMove()
    {
        if (movetime > 0)
        {
            if (random == 1)
            {
                TargetObject = way1;
                if (TargetObject != null)
                {
                    GetComponent<NavMeshAgent>().destination = TargetObject.position;
                }
                random = Random.Range(1, 5);
            }
            if (random == 2)
            {
                TargetObject = way2;
                if (TargetObject != null)
                {
                    GetComponent<NavMeshAgent>().destination = TargetObject.position;
                }
                random = Random.Range(1, 5);
            }
            if (random == 3)
            {
                TargetObject = way3;
                if (TargetObject != null)
                {
                    GetComponent<NavMeshAgent>().destination = TargetObject.position;
                }
                random = Random.Range(1, 5);
            }
            if (random == 4)
            {
                TargetObject = way4;
                if (TargetObject != null)
                {
                    GetComponent<NavMeshAgent>().destination = TargetObject.position;
                }
                random = Random.Range(1, 5);
            }
            
        }
    }
}
