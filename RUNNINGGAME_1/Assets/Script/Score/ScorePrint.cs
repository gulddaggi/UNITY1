using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePrint : MonoBehaviour
{
    Text[] ArrText = null;

    [SerializeField]
    GameObject NameInputObj = null;

    // Start is called before the first frame update
    void Awake()
    {
        LogicValue.ScoreLoad();


        if (null == NameInputObj)
        {
            Debug.LogError("if (null == NameInputObj)");
            return;
        }


        if (true == LogicValue.ScoreCheck())
        {
            NameInputObj.SetActive(true);
        }

        LogicValue.ScoreCheck();

        //가장 위에 있는 하나만 가져온다.
        //GetComponent<Text>();
        //자신안의 모든 같은 종류의 컴포넌트를 배열로 가져온다.
        //GetComponents<Text>();
        //자신안의 자식까지 모두 검사해서 같은 종류의 컴포넌트를 배열로 가져온다.
        //GetComponentsInChildren<Text>()

        

    }

    // Update is called once per frame
    void Update()
    {
        ArrText = GetComponentsInChildren<Text>();

        if (LogicValue.ScoreArr.Count != ArrText.Length)
        {
            Debug.LogError("LogicValue.ScoreArr.Count != ArrText.Length");
            return;
        }


        for (int i = 0; i < ArrText.Length; i++)
        {
            if (LogicValue.ScoreArr[i].Score == 0)
            {
                ArrText[i].text = "미등록";
                continue;

            }

            string Name = LogicValue.ScoreArr[i].Name;

            if (Name == "")
            {
                Name = "NONAME";
            }

            ArrText[i].text = (i + 1).ToString() + ". " + Name + " " + LogicValue.ScoreArr[i].Score.ToString();
            //1. AAA 1231
        }
    }
}
