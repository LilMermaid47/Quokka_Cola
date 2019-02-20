using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuilderScript : MonoBehaviour
{

    [SerializeField]
    float buildRayon = 10f;
    [SerializeField]
    int buildFrequence = 1000;
    [SerializeField]
    float playerDistance = 15f;
    [SerializeField]
    Transform playerTransform;


    private NavMeshAgent navMeshAgent;
    private bool isNotBuilding = true;
    private int randomBuildNumber;
    private Vector3 positionBuild;
    private float randomBuildX;
    private float randomBuildZ;
    private Vector3 fleeVector;
    private float fleeDistance;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance < playerDistance)
        {
            RunAway();
        }
        else
        {
            randomBuildNumber = UnityEngine.Random.Range(0, (int)buildFrequence + 1);
            if (randomBuildNumber == 1)
            {
                BuildNewBuilding();
            }
        }
    }

    private void RunAway()
    {
        fleeVector = transform.position + (transform.position - playerTransform.position);
        navMeshAgent.SetDestination(fleeVector);
    }

    private void BuildNewBuilding()
    {
        isNotBuilding = false;
        randomBuildX = UnityEngine.Random.Range(0.0f, buildRayon);
        randomBuildZ = UnityEngine.Random.Range(0.0f, buildRayon);
        positionBuild = new Vector3(transform.position.x + randomBuildX, 0, transform.position.z + randomBuildZ);
        Debug.Log(positionBuild);
        navMeshAgent.SetDestination(positionBuild);
    }
}
