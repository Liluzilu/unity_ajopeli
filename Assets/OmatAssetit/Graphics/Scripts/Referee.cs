using UnityEditor;
using UnityEngine;
using TMPro;
public class Referee : MonoBehaviour
{
    public TMP_Text  resultText;
    public int kierostenMaara = 3;
    private bool winnerDeclared = false;
    private void Start()
    {
        resultText.text = "";
    }
    private void OnTriggerEnter(Collider car)
    {
        CarIdentify id = car.GetComponent<CarIdentify>();
        if(id == null)
        {
            return;
        }
        LapCounter lap = car.GetComponent<LapCounter>();
        //string winnerName = id.displayName;
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
                Debug.Log("Player finished the race but all checkpoints have not been past-> no victory!");
                return;
            }
            int tmpLap =lap.lapsCompleted;
            validator.UpdateLapsText(tmpLap +1,kierostenMaara);
            validator.ResetLap();
        }
        lap.lapsCompleted++;
        if(winnerDeclared == false &&lap.lapsCompleted >=kierostenMaara)
        {
            string winnerName = id.displayName;
            resultText.text = $"WINNER: {winnerName}";
            winnerDeclared = true;
            GameManager.Instance.Phase = RacePhase.finished;
        }
    }
    
 }
