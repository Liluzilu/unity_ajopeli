using UnityEditor;
using UnityEngine;
using TMPro;
public class Referee : MonoBehaviour
{
    public TMP_Text  resultText;
    private bool winnerDeclared = false;
    private void Start()
    {
        resultText.text = "";
    }
    private void OnTriggerEnter(Collider car)
    {
        CarIdentify id = car.GetComponent<CarIdentify>();
        string winnerName = id.displayName;
        if (id.kind == Carkind.Player)
        {
            var validator = car.GetComponent<PelaajanKierrostarkastus>();
            if (validator == null)
            {
                Debug.LogError("Puuttuu PelaajanKierrostarkastus scripti");
                return;

            }
            if (!validator.AllVisitedThisLap)
            {
                Debug.Log("Player finished the race but all checkpoints are not alright -> no victory!");
                return;
            }
        }
        if(winnerDeclared == false)
        {
            resultText.text = $"WINNER: {winnerName}";
            winnerDeclared = true;

        }
    }
    
 }
