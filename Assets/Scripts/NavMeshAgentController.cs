using UnityEngine.AI;
using UnityEngine;

public class NavMeshAgentController : MonoBehaviour
{
    public Transform[] targets; // ����� �������� ����� ��� �������� 
    private NavMeshAgent agent; // ��������� �� ��������� NavMeshAgent 
    private int currentTargetIndex; // ������ ������� ������� ����� 
    private bool goingForward = true; // �� �������� ����� ������ �� ������

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentTargetIndex = 0; // �������� � ����� ������� ����� 
        MoveToNextTarget(); // ����������� �� ����� ������� �����
    }

    void Update()
    {
        // ���� ����� ����� ������� ����� (��� �������� �� ��), ����������� �� ��������
        if (agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToNextTarget();
        }
    }

    void MoveToNextTarget()
    {
        if (targets.Length == 0)
            return;

        // ������������ ������� ����� ��� ������
        agent.SetDestination(targets[currentTargetIndex].position);

        // ���� �� �������� ������, �������� ������
        if (goingForward)
        {
            if (currentTargetIndex >= targets.Length - 1)
            {
                goingForward = false; // ������� ��������, ���� ������� ���� ������
            }
            else
            {
                currentTargetIndex++;
            }
        }
        else // ���� �������� �����, �������� ������
        {
            if (currentTargetIndex <= 0)
            {
                goingForward = true; // ������� ��������, ���� ������� ������� ������
            }
            else
            {
                currentTargetIndex--;
            }
        }
    }
}
