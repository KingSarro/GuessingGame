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

    private int min = 1;
    private int max = 10;

    void Start(){
        GameSetup();
    }


    void GameSetup(){
        //Sets up the starting values of multiple variables
        correctNumber = GetRandomNumber();
        chancesLeft = 3;
        guessText.text = "Welcome to the guessing game. You have " + chancesLeft.ToString() + " chances  to guess a number between 1-10.";
        textInput.text = "Enter A Number...";
        Debug.Log("the answer is " + correctNumber.ToString());
    }
    public void SubmitGuess(){
        if (textInput != null && !(chancesLeft <= 0)){
            userGuess = int.Parse(textInput.text);
            //Debug.Log("Guess Has Been Saved");
            chancesLeft -= 1;
            isGuessInRange();
            Debug.Log("Guesses Left: " + chancesLeft.ToString());
        }
    }
    
    //============Excess Functions=================//
    public void ResetGame(){
        GameSetup();
    }
        int GetRandomNumber(){
        //gets a random number between 1 and 10
        int num = Random.Range(min,max+1);
        return num;
    }
    void isGuessInRange(){
        //Checks if the number is out of Range
        if (userGuess > max || userGuess < min){
            guessText.text = "That number is not between 1-10. Try Again.";
        }
        //If the number is in range
        else{
            IsGuessCorrect();
        }
    }
    void IsGuessCorrect(){
        //If the guess matches the correct number
        if (userGuess == correctNumber){
            guessText.text = "You have guessed the correct number!!! Restart to play again.";
            chancesLeft = 0;
        }
        //If the guess does not match the correct number
        else{
            switch (chancesLeft){
                case 2:
                    guessText.text = "Nope, try again. You have " + chancesLeft.ToString() + " chances left.";
                    break;
                case 1:
                    guessText.text = "Uh, oh. You have " + chancesLeft.ToString() + " chance left";
                    break;
                default:
                    guessText.text = "Your bad at guessing. The number was " + correctNumber.ToString() + ". Reset to try again.";
                    break;
            }
        }
    }
}

    
