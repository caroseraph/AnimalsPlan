using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Player pres manager.
/// </summary>
public class PlayerPrefsManager : MonoBehaviour 
{
	/// <summary>
	/// The instance.
	/// </summary>
	private static readonly GameObject 	instance = new GameObject("PlayerPrefsManager");
	
	/// <summary>
	/// The script.
	/// </summary>
	private static PlayerPrefsManager		component;
	
	/// <summary>
	/// Gets the singleton.
	/// </summary>
	/// <returns>The singleton.</returns>
	public static PlayerPrefsManager 		GetSingleton()
	{
		if (!component)
		{
			component = instance.AddComponent<PlayerPrefsManager>();
			if (!component)
				throw new System.NullReferenceException();

            DontDestroyOnLoad(instance);
		}
		
		return component;
	}

	#region 玩家信息

	//设备号，每一个设备有唯一设备号（换包会更新设备号）
	public static string	Account
	{
		set{
			PlayerPrefs.SetString("ANIMAL_ACCOUNT", value);
		}
		get{
			return PlayerPrefs.GetString("ANIMAL_ACCOUNT");
		}
	}

    /// <summary>
    /// UserCode，SDK返回
    /// </summary>
    public static string UserCode
    {
        set{
            PlayerPrefs.SetString("USER_CODE", value);
        }
        get{
            return PlayerPrefs.GetString("USER_CODE");
        }
    }

	/// <summary>
	/// 钻石数目
	/// </summary>
	public static int Diamond
	{
		set{
			PlayerPrefs.SetInt("ANIMAL_DIAMOND", value);
		}
		get{
			return PlayerPrefs.GetInt("ANIMAL_DIAMOND", 100);
		}
	}

	/// <summary>
	/// 动物币数目
	/// </summary>
	public static int Money
	{
		set{
			PlayerPrefs.SetInt("ANIMAL_MONEY", value);
		}
		get{
			return PlayerPrefs.GetInt("ANIMAL_MONEY", 1000);
		}
	}

	/// <summary>
	/// 通过动物赚的钱
	/// </summary>
	public static int GainMoney
	{
		set{
			PlayerPrefs.SetInt("GAIN_MONEY", value);
		}
		get{
			return PlayerPrefs.GetInt("GAIN_MONEY", 0);
		}
	}

	/// <summary>
	/// 背景音乐
	/// </summary>
	public static float OpenMusic
	{
		set{
            PlayerPrefs.SetFloat("ANIMAL_OPENMUSIC", value);
		}
		get{
            return PlayerPrefs.GetFloat("ANIMAL_OPENMUSIC", 0.35f);
		}
	}

	/// <summary>
	/// 音效
	/// </summary>
	public static float OpenSound
	{
		set{
			PlayerPrefs.SetFloat("ANIMAL_OPENSOUND", value);
		}
		get{
			return PlayerPrefs.GetFloat("ANIMAL_OPENSOUND", 1f);
		}
	}

	/// <summary>
	/// 引导编号
	/// </summary>
	public static int GuideNum
	{
		set{
			PlayerPrefs.SetInt("ANIMAL_GUIDE", value);
		}
		get{
			return PlayerPrefs.GetInt("ANIMAL_GUIDE", 101);
		}
	}

    /// <summary>
    /// 目标引导编号
    /// </summary>
    public static int TargetNum
    {
        set
        {
            PlayerPrefs.SetInt("ANIMAL_TARGET", value);
        }
        get
        {
            return PlayerPrefs.GetInt("ANIMAL_TARGET", 1);
        }
    }

    /// <summary>
    /// 目标引导进程
    /// </summary>
    public static int TargetProgress
    {
        set
        {
            PlayerPrefs.SetInt("ANIMAL_PROGRESS", value);
        }
        get
        {
            return PlayerPrefs.GetInt("ANIMAL_PROGRESS", 0);
        }
    }

    /// <summary>
    /// 购买6、8展馆
    /// </summary>
    public static int BoughtPark
    {
        set{
            PlayerPrefs.SetInt("ANIMAL_PARK", value);
        }
        get{
            return PlayerPrefs.GetInt("ANIMAL_PARK", 0);
        }
    }

    /// <summary>
    /// 购买道具
    /// </summary>
    public static int BoughtProps
    {
        set
        {
            PlayerPrefs.SetInt("ANIMAL_PROPS", value);
        }
        get
        {
            return PlayerPrefs.GetInt("ANIMAL_PROPS", 0);
        }
    }

    /// <summary>
    /// 成就（百万富翁）
    /// </summary>
    public static int Achievement
    {
        set
        {
            PlayerPrefs.SetInt("ANIMAL_ACHIEVE", value);
        }
        get
        {
            return PlayerPrefs.GetInt("ANIMAL_ACHIEVE", 0);
        }
    }

    /// <summary>
    /// 离开主场景的时间记录
    /// </summary>
    public static int LeaveMainSceneTime
    {
        set
        {
            PlayerPrefs.SetInt("ANIMAL_LEAVETIME", value);
        }
        get
        {
            return PlayerPrefs.GetInt("ANIMAL_LEAVETIME", 0);
        }
    }

	#endregion
}
