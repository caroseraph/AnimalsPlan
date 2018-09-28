using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARUIBaseMgr : MonoBehaviour {

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

	/// <summary>
	/// 注册GameObject点击事件
	/// </summary>
	public void RegisterClickEvent(GameObject goTarget, UIEventListener.VoidDelegate execute)
	{
		if (!goTarget)
			throw new System.NullReferenceException();
		UIEventListener.Get(goTarget).onClick = execute;
	}
}
