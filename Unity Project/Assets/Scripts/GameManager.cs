using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState {
    NotStarted,
    Playing,
    Completed,
    Failed
}

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
   
    public AudioClip StartSound;
    public AudioClip FailedSound;

    private GameState currentState = GameState.NotStarted;
    
    private BrickController[] allBricks;
    private BallController[] allBalls;
    private PaddleController paddle;
    
    public float Timer=0.0f;
    
    private int minutes;
    private int seconds;
    
    public string formattedTime;

    void Start () {

        Time.timeScale=1;

        // Find all the blocks in this scene
        allBricks = FindObjectsOfType(typeof(BrickController)) as BrickController[];

        // Find all the balls in this scene
        allBalls = FindObjectsOfType(typeof(BallController)) as BallController[];

        // Find paddle
        paddle = GameObject.FindObjectOfType<PaddleController>();

        //Prepare the start of the level
        SwitchState(GameState.NotStarted);

        ChangeText("Click to Begin");

    }

    public void SwitchState(GameState newState)
    {
        currentState = newState;
        switch (currentState)
        {
        default:
        case GameState.NotStarted:
            break;
        case GameState.Playing:
            GetComponent<AudioSource>().PlayOneShot(StartSound);
            break;
        case GameState.Completed:
            GetComponent<AudioSource>().PlayOneShot(StartSound);
            break;
        case GameState.Failed:
            GetComponent<AudioSource>().PlayOneShot(FailedSound);
            break;
        }
    }

    void Update () {

        switch (currentState) {

        case GameState.NotStarted:

            ChangeText("Click to Begin");

            //Check if the player taps/clicks (NB: mobile = first touch/finger)
            if (Input.GetMouseButtonDown(0))
                SwitchState(GameState.Playing);
            break;

        case GameState.Playing:

            Timer += Time.deltaTime;
            minutes = Mathf.FloorToInt(Timer / 60.0f);
            seconds = Mathf.FloorToInt(Timer - minutes * 60);
            formattedTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            ChangeText("Time: " + formattedTime);

            bool allBlocksDestroyed = false;

            //Are there no balls left?
            if (FindObjectOfType(typeof(BallController)) == null)
                SwitchState(GameState.Failed);

            if (allBlocksDestroyed)
                SwitchState(GameState.Completed);
            break;

        case GameState.Failed:

            ChangeText("You Lose!");

            break;

        case GameState.Completed:

            //bool allBlocksDestroyedFinal = false;

            //Destroy all the balls
            BallController[] others = FindObjectsOfType(typeof(BallController)) as BallController[];
            foreach(BallController other in others) {
                Destroy(other.gameObject);
            }
            break;
        }

    }

    public void ChangeText(string text) {
        GameObject canvas = GameObject.Find("Canvas");
        Text[] textValue = canvas.GetComponentsInChildren<Text>();
        textValue[0].text = text;
    }

}
