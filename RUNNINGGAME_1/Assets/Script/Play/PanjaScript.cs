using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanjaScript : MonoBehaviour
{
    //내가 만들어진 순간 -> PanjaScriptrk 오브젝트에 add된 순간. 절대 판자라는 오브젝트가 만들어진 순간이 아니다.
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
            //공개해야 할 것만 잘 공개해라. public을 남발하면 안 된다.
            Debug.LogError("if (null == LogicValue.CoinPrefab)");
            Destroy(gameObject);
            return;
        }

        //만들어지는 순간 이 스크립트를 add하는 순서가 잘못되었다면 실행할 수 없는 로직이다.

        //float가 int로 변경되는 순간 소수점이 날아간다.



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
            //나를 가지고 있는 오브젝트를 삭제한다.

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
