using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update

    Text TextCom = null;
    
    void Start()
    {
        TextCom = GetComponent<Text>();
        if (null == TextCom)
        {
            Debug.Log("null == TextCom");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (null == TextCom)
        {
            Debug.Log("null == TextCom");
            return;
        }
        TextCom.text = LogicValue.Score.ToString();
    }
}
