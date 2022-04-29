using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseController : MonoBehaviour
{

    private BallController ball;
    private GameManager gameManager;

    void OnTriggerEnter2D (Collider2D trigger){
        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.SwitchState(GameState.Failed);

        StartCoroutine(Pause());
    }
    
    IEnumerator Pause() {
        yield return new WaitForSeconds(2);

        //Find the ball and reset game start
        ball = GameObject.FindObjectOfType<BallController>();
        ball.gameStarted = false;

        //Reload level
        int current = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current);

    }

}
