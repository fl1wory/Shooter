
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    //Patroling
    /*public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    */
    [Header("Patroling")]
    [SerializeField] private Transform[] targets;
    private int targetIndex;
    public List<Transform> targetsList;
    public float StartWaitTime;
    private float waitTime;
    private float AFCTime;
    public float StartAFCTime;
    

    [Header("Attacking")]
    [SerializeField]private float timeBetweenAttacks;
    bool alreadyAttacked;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform gunpoint;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        foreach (Transform target in targets)
        {
            targetsList.Add(target);
        }
        waitTime = StartWaitTime;
        AFCTime = StartAFCTime;
        targetIndex = Random.Range(0, targetsList.Count);
        player = Camera.main.transform.parent;
    }
    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        //������ ������ ����� � ������ �� ��� �� ��
            agent.SetDestination(targetsList[targetIndex].position);
            float distanceToTarget = Vector3.Distance(transform.position, targetsList[targetIndex].position);
            if (distanceToTarget < 0.2f)
            {
                if(waitTime <= 0)
                {
                targetIndex = Random.Range(0, targetsList.Count);
                waitTime = StartWaitTime;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
    }


        /* if (!walkPointSet) SearchWalkPoint();

         if (walkPointSet)
             agent.SetDestination(walkPoint);

         Vector3 distanceToWalkPoint = transform.position - walkPoint;

         //Walkpoint reached
         if (distanceToWalkPoint.magnitude < 1f)
             walkPointSet = false;
        */
    /*private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    */

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, gunpoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
