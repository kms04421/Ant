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
    {//Wrapping:  �޼��带 ����Ҷ� ���� ���ϱ� ���� �������ϰų� �߰��ϴ°��� �����̶����.
     //���忡 �α׸� ���Խ�Ű�� �ʴ¹� -> ��ó������ �̸� (������ �ɺ�)
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

    //! GameObject �޾Ƽ� Text ������Ʈ ã�Ƽ� text�ʵ尪 �����ϴ� �Լ�

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

    //Ư�� ������Ʈ�� �ڽ� ������Ʈ�� ��ġ�ؼ� ������Ʈ�� ã���ִ� �Լ� 
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
    //Ư��������Ʈ �ڽ� ������Ʈ ��ġ�ؼ� ã����
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

    //Ȱ��ȭ�� ������Ʈ ��ġ�ؼ� ã���ִ� �Լ�
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
