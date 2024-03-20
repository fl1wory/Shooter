using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    [SerializeField] private Transform[] targets;
    private NavMeshAgent agent;

    private int targetIndex;
    private bool goForward;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        targetIndex = 0;
        MoveTarget();
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveTarget();
        }
    }
    private void MoveTarget()
    {
        agent.SetDestination(targets[targetIndex].position);
        if (goForward)
        {
            if (targetIndex >= targets.Length - 1) goForward = false;
            else targetIndex++;
           
        }
        else
        {
            if (targetIndex <= 0) goForward = true;
            else targetIndex--;
        }
    }
}
