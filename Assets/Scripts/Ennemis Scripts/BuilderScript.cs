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

    public UnityEngine.Object usine;
    private NavMeshAgent navMeshAgent;

    private bool canBuild = true;
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
            if (canBuild == false)
            {
                RandomPositionMovement();
            }
            if (navMeshAgent.destination.x == transform.position.x 
                && navMeshAgent.destination.z==transform.position.z
                &&canBuild)
            {
                canBuild = false;
                Instantiate(usine,transform.position,Quaternion.identity);
                RandomPositionMovement();
            }
        }
    }

    private void RunAway()
    {
        fleeVector = transform.position + (transform.position - playerTransform.position);
        navMeshAgent.SetDestination(fleeVector);
    }
    private Vector3 RandomPositionGenerator()
    {
        randomBuildX = UnityEngine.Random.Range(0.0f, buildRayon);
        randomBuildZ = UnityEngine.Random.Range(0.0f, buildRayon);
        return( new Vector3(randomBuildX, randomBuildZ));
    }
    private void RandomPositionMovement()
    {
        Vector3 randomPosition = RandomPositionGenerator();
        navMeshAgent.SetDestination(randomPosition);
    }
}
