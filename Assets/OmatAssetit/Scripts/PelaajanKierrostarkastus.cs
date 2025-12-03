using UnityEngine;

public class PelaajanKierrostarkastus : MonoBehaviour
{
    public int checkpointCount = 5;
    private bool[] visited;
    private int visitedCount;

    void Awake()
    {
        ResetLap();
    }
    public void ResetLap()
    {
        visited = new bool[checkpointCount];
        visitedCount = 0;
    }
    public void MarkVisited(int index)
    {
        if (!visited[index])
        {
            visited[index] = true;
            visitedCount++;
        }
    }
    public bool AllVisitedThisLap => visitedCount == checkpointCount;
}
