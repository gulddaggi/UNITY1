using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBack : MonoBehaviour
{
    
    [SerializeField]
    private float DeathLen;
    [SerializeField]
    private float CreateLen;
    [SerializeField]
    private float CreateInter;
    private bool m_IsCreate = false;
    [SerializeField]
    private int Order;

    private float Speed = 1.0f;
    // Start is called before the first frame update
    void Awake()
    {
        SpriteRenderer SR = GetComponent<SpriteRenderer>();

        if (null == SR)
        {
            Debug.LogError("if (null == SR)");
        }

        SR.sortingOrder = Order;
    }

    // Update is called once per frame
    void Update()
    {
        //���� ������, �θ� �ִٸ� �θ���ġ + �ڽ��� ��ġ�� ���� ��ġ
        transform.position += Vector3.left * Time.deltaTime * Speed;
        if (m_IsCreate == false && (CreateLen > transform.position.x))
        {
            GameObject Obj = LogicValue.NameInst(gameObject);
            Obj.transform.position += (Vector3.right * CreateInter);
            m_IsCreate = true;

        }

        if (DeathLen > transform.position.x)
        {
            Destroy(gameObject);

        }

    }
}
