using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD

public class PasserbyMove : MonoBehaviour {

    private GameObject[] allPositions;
    private float[] allDistances;
    private int currentPosition = 0;
    private float minDistance;

    public float walkSpeed;


	void Start()
	{
        allPositions = GameObject.FindGameObjectsWithTag("position");
        allDistances = new float[allPositions.Length];
	}

    void Update()
    {
        Invoke("searchDistance",minDistance/(Time.deltaTime * walkSpeed));
        
        PMoveBehaviour(allPositions[currentPosition].transform.position);

        if (Vector3.Distance(transform.position, allPositions[currentPosition].transform.position) <= 2)
        {
            currentPosition++;
        }
        if (currentPosition == allPositions.Length)
        {
            currentPosition = 0;
        } 
	}

    public void PMoveBehaviour(Vector3 nextAim)
    {
        transform.LookAt(nextAim);
        transform.position = Vector3.Lerp(transform.position, nextAim, Time.deltaTime * walkSpeed);
    }

    public void searchDistance()
    {
        minDistance = allDistances[0];
        for (int i = 0; i < allPositions.Length; i++)
        {
            allDistances[i] = Vector3.Distance(transform.position, allPositions[i].transform.position);
            if (minDistance > allDistances[i])
            {
                minDistance = allDistances[i];
                currentPosition = i;
            }
=======
using Pathfinding;
public class PasserbyMove : MonoBehaviour {

    //private GameObject[] allPositions;
    private float[] allDistances;
    private int currentPosition = 0;
    private float minDistance;
    public List<GameObject> allPositions = new List<GameObject>();
    public float walkSpeed;
    public int i = 0;
	

    void Update()
    {
        
        
        PMoveBehaviour();

	}

    public void PMoveBehaviour()
    {
        transform.LookAt(allPositions[i].transform.position);
        //transform.position = Vector3.Lerp(transform.position, allPositions[i].transform.position, Time.deltaTime * walkSpeed);
        transform.Translate(Vector3.forward*Time.deltaTime * walkSpeed);

    
        if (Vector3.Distance(transform.position, allPositions[i].transform.position) < 1)
        {
            i++;
            i %= allPositions.Count;
            Debug.Log(i);
        }
    
      
    }

   public void OnTriggerEnter(Collider col)
    {
        if(col.tag==Tags.player)
        {

            Bounds b = this.GetComponent<Collider>().bounds;
            GraphUpdateObject guo = new GraphUpdateObject(b);
            AstarPath.active.UpdateGraphs(guo);
>>>>>>> development
        }
    }
}
