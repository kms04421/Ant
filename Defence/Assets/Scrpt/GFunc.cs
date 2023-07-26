using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static partial class GFunc
{
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message)
    {//Wrapping:  메서드를 사용할때 내가 편하기 위해 재정의하거나 추가하는것을 랩핑이라고함.
     //빌드에 로그를 포함시키지 않는법 -> 전처리기의 이름 (디파인 심볼)
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }

    //! GameObject 받아서 Text 컴포넌트 찾아서 text필드값 수정하는 함수

    public static void SetText(this GameObject target, string text)
    {
        Text textComponent = target.GetComponent<Text>();
        if(textComponent ==null || textComponent == default) { return; }
        
        textComponent.text = text;
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    //특정 오브젝트의 자식 오브젝트를 서치해서 컴포넌트를 찾아주는 함수 
    public static T FindChildComponent<T>(this GameObject tatgetObj,string objMame) where T :Component
    {
        T searchResultCompoment = default(T);
        GameObject searcgResultObj =default(GameObject);

        searcgResultObj = tatgetObj.FindChildObj(objMame);
        if(searcgResultObj != null || searcgResultObj != default)
        {
            searchResultCompoment =searcgResultObj.GetComponent<T>();

        }
        return searchResultCompoment;

    }
    //특정오브젝트 자식 오브젝트 서치해서 찾아줌
    public static GameObject FindChildObj(this GameObject targetObj,string objName)
    {
        GameObject searchResult = default;
        GameObject searchTarget = default;

        for(int i=0; i < targetObj.transform.childCount; i++)
        {
            searchTarget= targetObj.transform.GetChild(i).gameObject;
            if(searchTarget.name.Equals(objName))
            {
                searchResult = searchTarget;
                return searchResult;
            }
            else
            {
                searchResult = FindChildObj(searchTarget, objName);
                if (searchResult == null || searchResult == default) { }
                else
                {
                    return searchResult;
                }
            }
        }
        return searchResult;
    }

    //활성화된 오브젝트 서치해서 찾아주는 함수
    public static GameObject GetRootObj(string objName)
    {
        Scene activeScene_= SceneManager.GetActiveScene();
        GameObject[] rootObs= activeScene_.GetRootGameObjects();

        GameObject target = default;
        foreach(GameObject go in rootObs)
        {
           if(go.name.Equals(objName))
            {
                target = go;
                return target;

            }
            else { continue; }  
        }
        return target;
    }


}
