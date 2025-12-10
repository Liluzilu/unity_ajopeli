using UnityEngine;

public class CheckpointTarkistus : MonoBehaviour
{
    public int orderIndex = 0;
    private void OnTriggerEnter(Collider other)
    {
        PelaajanKierrostarkastus validator = other.GetComponent<PelaajanKierrostarkastus>();
        if(validator != null)
        {
            validator.MarkVisited(orderIndex);
        }
    }
}
