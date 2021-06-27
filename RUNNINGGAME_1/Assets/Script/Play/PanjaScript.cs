using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanjaScript : MonoBehaviour
{
    //���� ������� ���� -> PanjaScriptrk ������Ʈ�� add�� ����. ���� ���ڶ�� ������Ʈ�� ������� ������ �ƴϴ�.
    [SerializeField]
    private int Count;

    public int FloorCount
    {
        set
        {
            Count = value;

            float MoveSize = Count * -0.5f;

            for (int i = 0; i < Count; i++)
            {
                GameObject NewObj = new GameObject("Floor");

                NewObj.transform.SetParent(transform);
                NewObj.transform.localPosition = new Vector3(i + MoveSize, 0, 0);
                SpriteRenderer SR =  NewObj.AddComponent<SpriteRenderer>();

                SR.sprite = LogicValue.MainFloorSprite;

                GameObject NewCoin = GameObject.Instantiate(LogicValue.CoinPrefab);
                NewCoin.transform.position = NewObj.transform.position + Vector3.up;


            }

            GameObject Left = new GameObject("LeftFloor");
            Left.transform.SetParent(transform);
            Left.transform.localPosition = new Vector3(-0.134f - 0.5f + MoveSize, 0, 0);
            SpriteRenderer LeftSR = Left.AddComponent<SpriteRenderer>();
            LeftSR.sprite = LogicValue.LeftFloorSprite;

            GameObject Right = new GameObject("RightFloor");
            Right.transform.SetParent(transform);
            Right.transform.localPosition = new Vector3(Count + 0.134f - 0.5f + MoveSize, 0, 0);
            SpriteRenderer RightSR = Right.AddComponent<SpriteRenderer>();
            RightSR.sprite = LogicValue.RightFloorSprite;

            


        }

        get
        {
            return Count;
        }
    }
    
    private void Awake()
    {
        if (null == LogicValue.CoinPrefab)
        {
            //�����ؾ� �� �͸� �� �����ض�. public�� �����ϸ� �� �ȴ�.
            Debug.LogError("if (null == LogicValue.CoinPrefab)");
            Destroy(gameObject);
            return;
        }

        //��������� ���� �� ��ũ��Ʈ�� add�ϴ� ������ �߸��Ǿ��ٸ� ������ �� ���� �����̴�.

        //float�� int�� ����Ǵ� ���� �Ҽ����� ���ư���.



    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (PlayerScript.PlayerPos.x - transform.position.x >= 10.0f)
        {
            //���� ������ �ִ� ������Ʈ�� �����Ѵ�.

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
