using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 발판으로서 필요한 동작을 담은 스크립
public class Platform : MonoBehaviour
{
    // 장애물 오브젝트들을 담는 배열
    public GameObject[] obstacles;
    // 플레이어 캐릭터가 밟았는지
    private bool stepped = false;

    // 코인(아이템류) 오브젝트들을 담는 배열
    public GameObject[] carrots;

    public GameObject[] hpcount;

    // 새로운 유니티 이벤트 메서드를 확인
    private void OnEnable()
    {
        // 발판을 리셋하는 처리

        // 밟힘 상태를 리셋
        stepped = false;

        // 장애물의 수만큼 루프
        for (int i = 0; i < obstacles.Length; i++)
        {
            // 현재 순번의 장애물을 1/3의 확률로 활성화
            if (Random.Range(0, 3) == 0)
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }

            // 조건연산자 : obstacles[i].SetActive(Random.Range(0,3)) == 0? true:false);
        }

        for (int i = 0; i < carrots.Length; i++)
        {
            // 현재 순번의 코인(아이템류)을 1/5의 확률로 활성화
            if (Random.Range(0, 5) == 0)
            {
                carrots[i].SetActive(true);
            }
            else
            {
                carrots[i].SetActive(false);
            }

            // 조건연산자 : coins[i].SetActive(Random.Range(0,3)) == 0? true:false);

        }

        for (int i = 0; i < hpcount.Length; i++)
        {
            // 현재 순번의 장애물을 1/3의 확률로 활성화
            if (Random.Range(0, 3) == 0)
            {
                hpcount[i].SetActive(true);
            }
            else
            {
                hpcount[i].SetActive(false);
            }

        }

    }
    // 플레이어 캐릭터가 자신을 밟았을 때 점수를 추가하는 처리
    private void OnCollisionEnter2D(Collision2D collision)

    {
        // 플레이어 캐릭터가 자신을 밟았을 때 점수를 추가하는 처리
        // 충돌한 상대방의 태그가 Player이고
        // 이전에 플레이어 캐릭터가 밟지 않았다면
        if (collision.collider.tag == "Player" && !stepped)
        {
            // 점수를 추가하고 밟힘 상태를 참으로 변경
            stepped = true;
            GameManager.instance.AddScore(1);
        }

    }
    // 플레이어가 아이템과 충돌했을 때 처리
    private void OnTriggerEnter2D(Collider2D other)

    {
        // 태그가 Bonus라면
        if (other.gameObject.tag == "Bonus")

        {
            // 플레이어의 생명횟수인 Hp가 1씩 증가한다.
            stepped = true;
            GameManager.instance.hp += 1;
            GameManager.instance.HpText();
            Destroy(gameObject);
            //게임 매니저의 게임오버 처리 실행
        }
    }
}