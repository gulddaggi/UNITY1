using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2d �������� �� ���� ������ ������ �߿��� ���� �ִ�. �⺻������ �츮�� �������� ������
//z���� �� �ڿ��ִ� ���� ���� �׷����ٰ� �� �� �ִ�. �׷��� ī�޶��� �̵������� �̵��� ����� �� �ְ�
//�Ϲ������� 2d���ӿ��� �װ��� ������ �ִ� ���� sortingorder�̴�.

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
        //����� ����
        if (m_IsNext == false && PlayerScript.PlayerPos.x > transform.position.x)
        {
            GameObject NextBG = Instantiate<GameObject>(gameObject);
            NextBG.name = gameObject.name;

            Vector3 Pos = transform.position;

            Pos.x += Inter;
            NextBG.transform.position = Pos;
            m_IsNext = true;
        }

        //����� ����
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
