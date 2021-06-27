using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
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

    private void OnTriggerEnter(Collider other)
    {
        LogicValue.PlusScore(100);
        Destroy(gameObject);
        //Debug.Log("저는 코인입니다.");
    }

}
