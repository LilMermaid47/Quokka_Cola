using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    Transform endPosition;

    NavMeshAgent navMeshAgent;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetDestination();
    }

    private void SetDestination()
    {
        Vector3 targetVector = endPosition.transform.position;
        navMeshAgent.SetDestination(targetVector);
    }
}
