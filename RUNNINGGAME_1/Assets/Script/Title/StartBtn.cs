using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Text나 Button같은 UGUI의 컴포넌트를 사용할 수 있다.
using UnityEngine.EventSystems;//ipointer 이벤트를 등록
using UnityEngine.SceneManagement; //씬 넘기는 일을 실행


/*유니티에서 지원하는 UGUI의 기본은 UI적인 요소를 렌더링하고 그 기능을 이용하기 위한 컴포넌트들의 모음이다.
보통 일반적으로UI를 만들때는 공간자체를 비율이나 척도를 변경해서 만들 때가 많다.
UI만큼은 스크린크기를 기준으로 할 때가 많다. 비율형은 해상도가 달라져도 비슷하게 나오며 그 비율을 제어하는 것이 캔버스 컴포넌트이다.
모든 UGUI는 캔버스 컴포넌트를 가진 오브젝트 아래 존재해야만 그 기능을 수행한다.

캔버스 : UGUI의 기본적인 기능을 제어한다.
캔버스 스케일러 : 캔버스 공간의 크기에 대해서 제어
캔버스 레이캐스트 : 캔버스 내부의 충돌과 이벤트에 대해서 제어. 버튼, 스크롤바가 작동하도록 하며 이벤트시스템이라는 컴포넌트의 힘을 빌린다.

 
 
 */

public class StartBtn : MonoBehaviour, IPointerDownHandler, IPointerExitHandler, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("PlayScene");
        //씬을 넘기고 싶다.
        //Scene in build에서 미리 등록해야 한다.

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void SceneChange()
    {
        Debug.Log("씬을 넘기는 일을 해보겠습니다.");
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
