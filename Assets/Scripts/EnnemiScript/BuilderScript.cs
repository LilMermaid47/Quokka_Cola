using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuilderScript : MonoBehaviour
{
    [SerializeField]
    float buildRayon = 10f;
    [SerializeField]
    float buildFrequence = 100f;
    [SerializeField]
    Object usine;

    private NavMeshAgent navMeshAgent;
    private bool isNotBuilding = true;
    private bool isNotGoingToPosition = true;
    private int randomBuildNumber;
    private Vector3 positionBuild;
    private float randomBuildX;
    private float randomBuildZ;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (isNotBuilding && randomBuildNumber == 0)
        {
            randomBuildNumber = Random.Range(0, 101);
            isNotBuilding = false;
            randomBuildX = Random.Range(0.0f, buildRayon);
            randomBuildZ = Random.Range(0.0f, buildRayon);
            positionBuild = new Vector3(transform.position.x + randomBuildX, 2, transform.position.z + randomBuildZ);
            Debug.Log(positionBuild);
            navMeshAgent.SetDestination(positionBuild);
            
            object usineInstance = Instantiate(usine,positionBuild,Quaternion.identity);
        }
    }
}
