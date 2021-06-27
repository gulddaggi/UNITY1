using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2d 렌더링을 할 때는 렌더링 순서가 중요할 때가 있다. 기본적으로 우리가 제어하지 않으면
//z값이 더 뒤에있는 것이 먼저 그려진다고 볼 수 있다. 그런데 카메라의 이동에따라 이들이 변경될 수 있고
//일반적으로 2d게임에서 그것을 설정해 주는 것이 sortingorder이다.

public class BackGround : MonoBehaviour
{
    [SerializeField]
    private float Inter;
    [SerializeField]
    int Sort = 0;


    bool m_IsNext = false;

    void Awake()
    {
        SpriteRenderer SR = GetComponent<SpriteRenderer>();
        SR.sortingOrder = Sort;
    }

    void Update()
    {
        //만드는 로직
        if (m_IsNext == false && PlayerScript.PlayerPos.x > transform.position.x)
        {
            GameObject NextBG = Instantiate<GameObject>(gameObject);
            NextBG.name = gameObject.name;

            Vector3 Pos = transform.position;

            Pos.x += Inter;
            NextBG.transform.position = Pos;
            m_IsNext = true;
        }

        //지우는 로직
        if (Inter * 2 <= PlayerScript.PlayerPos.x - transform.position.x)
        {
            Destroy(gameObject);
        }

        


    }

    private void LateUpdate()
    {
        if (true == PlayerScript.IsDeath)
        {
            Destroy(gameObject);
        }
    }
}
