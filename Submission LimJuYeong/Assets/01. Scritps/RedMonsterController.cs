using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMonsterController : MonoBehaviour
{
    private Rigidbody redMonsterRigidbody; // 이동에 사용할 리지드바디 컴포넌트

    void Start() // 몬스터의 물리적인 요소를 감지하게 한다.
    {
        redMonsterRigidbody = GetComponent<Rigidbody>();
    }
    public void Die() // 몬스터 총알 맞으면 죽음 구현
    {
        gameObject.SetActive(false);
    }
}