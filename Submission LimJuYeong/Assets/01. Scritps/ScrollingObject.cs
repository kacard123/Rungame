using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f;

    private void Update()
    {
        // 게임 오버가 아니라면
        if (!GameManager.instance.isGameover)
        {
            // 초당 speed의 속도로 왼쪽으로 평행 이동
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

    }
}

