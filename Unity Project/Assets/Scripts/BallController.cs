using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    
    public PaddleController paddle;
    public bool gameStarted = false;

    private Vector3 paddleVector;

    private Vector2 LAUNCH_VECTOR =  new Vector2(2.0f, 10.0f);

    void Start()
    {
        paddleVector = this.transform.position - paddle.transform.position;
    }
    
    void Update()
    {
        // Before game starts, stick ball to bat; mouse click = launch
        if (!gameStarted) {
            this.transform.position = paddle.transform.position + paddleVector;
            if (Input.GetMouseButtonDown(0)) {
                gameStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = LAUNCH_VECTOR;
            }
        }
    }

}
