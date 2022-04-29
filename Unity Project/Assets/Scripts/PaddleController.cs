using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public int i = 0;
    
    private const float WORLD_WIDTH = 16.0f;
    private const float PADDLE_MARGIN = 0.5f;

    void Update()
    {
        float mousePos = (Input.mousePosition.x / Screen.width) * WORLD_WIDTH;

        Vector3 paddlePos = new Vector3 (WORLD_WIDTH / 2, this.transform.position.y, 0.0f);
        paddlePos.x = Mathf.Clamp(mousePos, PADDLE_MARGIN, WORLD_WIDTH - PADDLE_MARGIN);
        this.transform.position = paddlePos;

    }
}
