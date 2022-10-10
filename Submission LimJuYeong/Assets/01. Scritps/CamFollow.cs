using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target; // 추적할 대상
    public float speed; // 카메라 이동 속력

    // 카메라를 일정 영역 안에서만 움직이도록 설정
    public Vector2 center; // 2차원 백터와 위치 
    public Vector2 size; // 백터 사이즈
    float height; // 높이
    float width; // 넓이

    void Start()
    {
        // 스크린의 가로, 세로 비율을 이용해서 월드공간의 가로 크기를 구하기
        // 월드 가로 = 월드 세로 * 스크린 가로 / 스크린 세로
        height = Camera.main.orthographicSize; // 높이는 오쏘그래픽 모드일 때 메인 카메라 크이에 절반이다.
        width = height * Screen.width / Screen.height;
    }


    void LateUpdate() // LateUpdate는 Update 메소드가 끝나면 LateUpdate가 이루어진다
                      // 그래서, 정확한 위치를 파악할 수 있음.
    {
        // 추적 카메라 위치 설정
        // 카메라의 position 값에 플레이어의 position값을 대입
        // Vector3Lerp는 A와 B 사이의 벡터 값을 반환
        // A와 B가 고정이라면 반환된 벡터는 +값(0.0~1.0)에 따라 변함
        // 카메라의 위치는 매 프레임 조금씩 플레이어에 다가감
        // 이때 Time.deltaTime의 값에 speed 변수 선언하고 곱하기
        // speed의 값에 따라서 카메라의 이동속도가 결정
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);

        // Mathf.Clamp(value,min,max)
        // vlaue값이 min과 max의 사이면 value를 반환하고
        // vlue값이 min보다 작으면 min을 max보다 크면 max를 반환 
        float lx = size.x * 0.5f - width;

        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        float ly = size.y * 0.5f - height;
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX, clampY, -10f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // 눈에 띌 수 있도록 기즈모의 색은 빨간색으로 설정
        Gizmos.DrawWireCube(center, size); // center를 중심으로 size크기의 큐브를 표시
    }
}
