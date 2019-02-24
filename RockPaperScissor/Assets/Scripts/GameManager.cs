using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject Rock;
    public GameObject Paper;
    public GameObject Scissor;
    public GameObject Cycle;
    public GameObject WinnerPrompt; //this is just the WinnerPromt text that contains the script "AutoText"

    private int playerMove = -1;
    private int cpuMove = 0;
    public static bool play = true;
    public int gamePlayed = 10;
    private int gameWin = 0;
    private  int computerWin = 0;
    private bool readyToClick = true;   //in order to counter the fact that someone may spam a button while the round has not finished yet
    private int exitOrPlay = -1;
    
    public Text playerScoreCounter;
    public Text cpuScoreCounter;
    public Text roundCount;
    void Awake()
    {
        playerScoreCounter.text = "0";
        cpuScoreCounter.text = "0";
        roundCount.text = "0";

        GameObject.Find("Canvas").transform.GetChild(7).gameObject.SetActive(false);    //set exit button object to false
        GameObject.Find("Canvas").transform.GetChild(8).gameObject.SetActive(false);    //set retry button to false
        WinnerPrompt.SetActive(false);  //set the winner promt text to false

        //Setting the +1 animiation off
        GameObject.Find("Canvas").transform.GetChild(9).gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(10).gameObject.SetActive(false);
        
    }
    


    IEnumerator Start()
    {    
        for(int i = 0 ; i < gamePlayed; i++)
        {
            while(playerMove == -1) yield return null;
            {
                readyToClick = false;  //player wont be able to spam buttons while round in proccess
                Cycle.GetComponent<Alternating_Animation>().loop = false;   //turns off the cycle animaton loop from script Alternating_Animations 
                
                cpuMove = Random.Range(1,4);

                yield return new WaitForSeconds(0.1f);

                if(cpuMove == 1)
                    Cycle.GetComponent<Alternating_Animation>().ActivateRockR();
                else if(cpuMove == 2)
                    Cycle.GetComponent<Alternating_Animation>().ActivatePaperR();
                else if(cpuMove == 3)
                    Cycle.GetComponent<Alternating_Animation>().ActivateScissorR();

                playerMoveSet(playerMove);
                
                roundCount.text = (i+1).ToString();

                if(playerMove == cpuMove)
                {   
                    
                }
                else if( (playerMove == 1 && cpuMove == 3) || (playerMove == 2 && cpuMove == 1) || (playerMove == 3 && cpuMove == 2) )
                {   
                    Activation(playerMove);
                    gameWin++;
                    playerScoreCounter.text = gameWin.ToString();
                    GameObject.Find("Canvas").transform.GetChild(9).gameObject.SetActive(true);
                } else
                {
                    Activation(playerMove);
                    computerWin++;
                    cpuScoreCounter.text = computerWin.ToString();
                    GameObject.Find("Canvas").transform.GetChild(10).gameObject.SetActive(true);
                }
                
            }
            playerMove = -1;
            yield return new WaitForSeconds(1.5f);
            GameObject.Find("Canvas").transform.GetChild(9).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(10).gameObject.SetActive(false);
            Cycle.GetComponent<Alternating_Animation>().loop = true;
            //Cycle.GetComponent<Alternating_Animation>().AlternateL();
            //Cycle.GetComponent<Alternating_Animation>().AlternateR();
            Cycle.GetComponent<Alternating_Animation>().StartCoroutine(Cycle.GetComponent<Alternating_Animation>().AlternateL());
            Cycle.GetComponent<Alternating_Animation>().StartCoroutine(Cycle.GetComponent<Alternating_Animation>().AlternateR());
            readyToClick = true;
        }

        Cycle.GetComponent<Alternating_Animation>().loop = false;

        //GameObject.Find("Exit_Button").SetActive(true);
        //GameObject.Find("Retry_Button").SetActive(true);
        GameObject.Find("Canvas").transform.GetChild(7).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.GetChild(8).gameObject.SetActive(true);

        if(gameWin > computerWin)
        {
            WinnerPrompt.GetComponent<AutoText>().fullText = "YOU WIN! :>";
        } 
        else if(computerWin > gameWin)
        {
            WinnerPrompt.GetComponent<AutoText>().fullText = "YOU LOSE! :(";
        }   
        else
        {
            WinnerPrompt.GetComponent<AutoText>().fullText = "DRAW!";
        }
        WinnerPrompt.SetActive(true);
        yield return new WaitForSeconds(3f);

        while(exitOrPlay == -1) yield return null;
        {
            //reload game
            if(exitOrPlay == 1)
                SceneManager.LoadScene("Scene_0");

        }
        
        WinnerPrompt.GetComponent<AutoText>().fullText = "BYE!";
        StartCoroutine(WinnerPrompt.GetComponent<AutoText>().ShowText());

        yield return new WaitForSeconds(2f);

        
        QuitGame(); //this ONLY WORKS if the game is BUILT 
    }

    // 1 == Rock , 2 == paper, 3 == scissor
    public void Activation(int option)
    {
        
        //NOTE: the "readToClick" boolean variable is to counter spamming while a round has not yet finish
        if(option == 1 && readyToClick)     //Rock
        {
            playerMove = 1;
        }
        else if(option == 2 && readyToClick)    //paper
        {    
            playerMove = 2;
        }
        else if(option == 3 && readyToClick)       //scissors
        {
            playerMove = 3;
        }    
    }

    public void playerMoveSet(int option)
    {
        if(option == 1 )     //Rock
        {
            Rock.SetActive(true);
            Paper.SetActive(false);
            Scissor.SetActive(false);
        }
        else if(option == 2)    //paper
        {    
            Paper.SetActive(true);
            Rock.SetActive(false);
            Scissor.SetActive(false);
        }
        else if(option == 3 )       //scissors
        {
            Scissor.SetActive(true);
            Paper.SetActive(false);
            Rock.SetActive(false);
        }   
    }

    //input == 1 is RETRY 
    //input != 1 is QUIT
    public void RetryOrQuit(int input)
    {
        exitOrPlay = input;
    }
    

    //This function is needed because my entire game is done in the 
    //Start Coroutine (Which isn't optimized, but since the game is small its fine)
    //and "Application.Quit()" does not work insidena couritine... Therefore, it will be called by this function.
    public void QuitGame()
    {
        Application.Quit();
    }

}
