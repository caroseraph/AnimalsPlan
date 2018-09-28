using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 所有界面元素底层处理
/// </summary>
public class UIBaseMgr : MonoBehaviour {

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

	/// <summary>
	/// 注册字典成员按下事件
	/// </summary>
	public void RegisterPressEvent(string strName, UIEventListener.BoolDelegate execute)
	{
		if(childMembers.ContainsKey(strName))
		{
			UIEventListener.Get(childMembers[strName]).onPress = execute;
		}
	}

	/// <summary>
	/// 设置label文本内容
	/// </summary>
	public void SetLabelText(string strName, string strText)
	{
		if(childMembers.ContainsKey(strName))
		{
			UILabel lab = childMembers[strName].GetComponent<UILabel> ();
			if (lab)
				lab.text = strText;
		}
	}

	/// <summary>
	/// 针对任意GameObject设置label文本内容
	/// </summary>
	public void SetLabelText(GameObject goTarget, string strText)
	{
		UILabel lab = goTarget.GetComponent<UILabel> ();
		if (lab)
			lab.text = strText;
	}

	/// <summary>
	/// 设置滑动条数值
	/// </summary>
	public void SetSliderValue(string strName, float Value)
	{
		if(childMembers.ContainsKey(strName))
		{
			UISlider slider = childMembers[strName].GetComponent<UISlider> ();
			if (slider)
				slider.value = Value;
		}
	}

	/// <summary>
	/// 设置精灵名
	/// </summary>
	public void SetSpriteName(string strName, string strSprite)
	{
		if(childMembers.ContainsKey(strName))
		{
			UISprite sprite = childMembers[strName].GetComponent<UISprite> ();
			if (sprite)
			{
				sprite.spriteName = strSprite;
				sprite.MakePixelPerfect();
			}
		}
	}

    /// <summary>
    /// 设置精灵尺寸
    /// </summary>
    public void SetSpriteSize(string strName, int iHeight, int iWidth)
    {
        if (childMembers.ContainsKey(strName))
        {
            UISprite sprite = childMembers[strName].GetComponent<UISprite>();
            if (sprite)
            {
                sprite.height = iHeight;
                sprite.width = iWidth;
            }
        }
    }

	/// <summary>
	/// 允许摄像机移动
	/// </summary>
	public void AllowCameraMoves()
	{
		CameraController.m_ccInstance.m_bMoveCamera = true;
	}

	/// <summary>
	/// 禁止摄像机移动
	/// </summary>
	public void BanCameraMoves()
	{
		CameraController.m_ccInstance.m_bMoveCamera = false;
	}
}
