using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour{
    // Start is called before the first frame update
    [SerializeField] TMP_Text guessText;
    [SerializeField] TMP_InputField textInput;
    [SerializeField] Button submitButton;
    [SerializeField] Button resetButton;


    private int correctNumber;
    private int userGuess;
    private int chancesLeft = 3;



    void Start(){
        GameSetup();
    }

    // Update is called once per frame
    void Update(){
        
    }

    void GameSetup(){
        //Sets up the starting values of multiple variables
        correctNumber = GetRandomNumber();
        chancesLeft = 3;
        guessText.text = "Welcom to the guessing game. You have " + chancesLeft.ToString() + " chances  to guess a number between 1-10.";
        textInput.text = "Enter A Number...";
    }

    int GetRandomNumber(){
        //gets a random number between 1 and 10
        int num = Random.Range(1,10+1);
        return num;
    }

    public void SubmitGuess(){
        if (textInput != null && !(chancesLeft <= 0)){
            userGuess = int.Parse(textInput.text);
            Debug.Log("Guess Has Been Saved");
        }
    }
}
