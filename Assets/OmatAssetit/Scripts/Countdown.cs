using System.Collections;
using TMPro;
using UnityEngine;
using System.Collections;
public class Countdown : MonoBehaviour
{
    public TMP_Text uiText;
    public int countdownFrom = 3;
    public float stepSeconds = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        for(int i = countdownFrom; i > 0; i--)
        {
        uiText.text = i.ToString();
        yield return new WaitForSecondsRealtime(stepSeconds);
            
        }
        uiText.text = "GO";
        yield return new WaitForSecondsRealtime(0.5f);
        uiText.text = "";
        GameManager.Instance.Phase = RacePhase.Racing;
    }  

    // Update is called once per frame
    void Update()
    {
        
    }
}
