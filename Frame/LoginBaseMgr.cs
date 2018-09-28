using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoginBaseMgr : MonoBehaviour {

	//所有子节点字典
	private static Dictionary<string, GameObject> childMembers = new Dictionary<string, GameObject>();

	/// <summary>
	/// 添加GameObject到字典
	/// </summary>
	public void RegisterGameObject(string strName, GameObject go)
	{
		if(!childMembers.ContainsKey(strName))
		{
			childMembers.Add(strName, go);
		}
	}

	/// <summary>
	/// 根据名称移除字典里的元素
	/// </summary>
	public void UnRegisterGameObject(string strName)
	{
		if(childMembers.ContainsKey(strName))
		{
			childMembers.Remove(strName);
		}
	}

    /// <summary>
    /// 设置label文本内容
    /// </summary>
    public void SetLabelText(string strName, string strText)
    {
        if (childMembers.ContainsKey(strName))
        {
            UILabel lab = childMembers[strName].GetComponent<UILabel>();
            if (lab)
                lab.text = strText;
        }
    }

    /// <summary>
    /// 针对任意GameObject设置label文本内容
    /// </summary>
    public void SetLabelText(GameObject goTarget, string strText)
    {
        UILabel lab = goTarget.GetComponent<UILabel>();
        if (lab)
            lab.text = strText;
    }

	/// <summary>
	/// 清除全部成员
	/// </summary>
	public void ClearAllMembers()
	{
		childMembers.Clear();
	}

	/// <summary>
	/// 根据名称获得字典中的GameObject
	/// </summary>
	public GameObject GetGameObject(string strName)
	{
		if(childMembers.ContainsKey(strName))
		{
			return childMembers[strName];
		}
		return null;
	}

	/// <summary>
	/// 注册字典成员点击事件
	/// </summary>
	public void RegisterClickEvent(string strName, UIEventListener.VoidDelegate execute)
	{
		if(childMembers.ContainsKey(strName))
		{
			UIEventListener.Get(childMembers[strName]).onClick = execute;
		}
	}

}
