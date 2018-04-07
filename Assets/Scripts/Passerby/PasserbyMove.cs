using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        }
    }
}
