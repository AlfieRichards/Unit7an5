using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class currentDif : MonoBehaviour
{
    public TextMeshProUGUI diffText;
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        difficulty = PlayerPrefs.GetInt("Difficulty");
        if(difficulty == 0){
            diffText.text = "Current: easy";
        }
        if(difficulty == 1){
            diffText.text = "Current: medium";
        }
        if(difficulty == 2){
            diffText.text = "Current: hard";
        }
        else{
            Debug.Log("panic");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
