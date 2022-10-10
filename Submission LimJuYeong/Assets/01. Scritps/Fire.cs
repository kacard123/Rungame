using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public float speed;

    public float distance;
    public LayerMask isLayer;


    private void Start()
    {
        // DestroyBullet 함수를 2초 후에 실행한다
        Invoke("DestroyBullet", 2);
    }

    void Update()
    {
        //RaycastHit2D ray = Physics.Raycast(transform.position, transform.right, distance, isLayer);
        //if(ray.collider != null)

        // 맨처음 시작할 때 불꽃의 상태인 transform.rotation.y가 0
        // 초당 스피드의 속도로 오른쪽으로 날아간다
        if (transform.rotation.y == 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);

        }


    }

    void DestroyBullet()
    {
        // 3초 뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f);
    }

    // 트리거 충돌 시 자동으로 실행되는 메서드
    void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if (other.tag == "Spark")
        {
            // 상대방 게임 오브젝트에서 RedMonsterController 컴포넌트 가져오기
            RedMonsterController redMonsterController = other.GetComponent<RedMonsterController>();

            // 상대방으로부터 RedMonsterController 컴포넌트를 가져오는 데 성공했다면
            if (redMonsterController != null)
            {
                // 상대방 RedMonsterController 컴포넌트의 Die() 메서드 실행
                redMonsterController.Die();
                DestroyBullet();
            }
        }
    }
}