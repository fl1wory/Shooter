using UnityEngine.AI;
using UnityEngine;

public class NavMeshAgentController : MonoBehaviour
{
    public Transform[] targets; // Масив цільових точок для навігації 
    private NavMeshAgent agent; // Посилання на компонент NavMeshAgent 
    private int currentTargetIndex; // Індекс поточної цільової точки 
    private bool goingForward = true; // Чи рухається агент вперед по масиву

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentTargetIndex = 0; // Починаємо з першої цільової точки 
        MoveToNextTarget(); // Переміщуємося до першої цільової точки
    }

    void Update()
    {
        // Якщо агент досяг цільової точки (або близький до неї), переміщуємося до наступної
        if (agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToNextTarget();
        }
    }

    void MoveToNextTarget()
    {
        if (targets.Length == 0)
            return;

        // Встановлюємо цільову точку для агента
        agent.SetDestination(targets[currentTargetIndex].position);

        // Якщо ми рухаємося вперед, збільшуємо індекс
        if (goingForward)
        {
            if (currentTargetIndex >= targets.Length - 1)
            {
                goingForward = false; // Змінюємо напрямок, якщо досягли кінця масиву
            }
            else
            {
                currentTargetIndex++;
            }
        }
        else // Якщо рухаємося назад, зменшуємо індекс
        {
            if (currentTargetIndex <= 0)
            {
                goingForward = true; // Змінюємо напрямок, якщо досягли початку масиву
            }
            else
            {
                currentTargetIndex--;
            }
        }
    }
}
