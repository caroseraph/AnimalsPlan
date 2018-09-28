using UnityEngine;
using System.Collections.Generic;

public class SoundMgr : MonoBehaviour {

	//单例
	private static readonly GameObject instance = new GameObject("SoundMgr");
	private static SoundMgr component;

	public static SoundMgr GetSingleton()
	{
		if(!component)
		{
			component = instance.AddComponent<SoundMgr>();
			if(!component)
				throw new System.NullReferenceException();
            DontDestroyOnLoad(instance);
		}
		return component;
	}

	/// <summary>
	/// 环境音（鸟叫等）
	/// </summary>
	AudioSource m_asEnvironment;
	//背景音乐
	AudioSource m_asBgm;
	AudioClip m_acBgm1;
	AudioClip m_acBgm2;


	/// <summary>
	/// 主界面音效
	/// </summary>
	AudioSource m_asMain;
	//玩家升级
	AudioClip m_acLevelUp;
	//界面打开
    AudioClip m_acInterfaceOpen;
	//界面关闭
    AudioClip m_acInterfaceClose;
	//点击
	AudioClip m_acClick;
	//钻石音效
	AudioClip m_acDiamond;
	//获得金币音效
	AudioClip m_acGoldGain;
	//花费金币音效
	AudioClip m_acGoldUse;
	//稀有度1、2时播放
	AudioClip m_acRare1;
	//稀有度3、4时播放
	AudioClip m_acRare3;
	//稀有度5及以上播放
	AudioClip m_acRare5;
	//动物升级成年
	AudioClip m_acAnimalUpgrade;
	//展馆升级改建完成
	AudioClip m_acParkUpgrade;
	/// <summary>
	/// 吃食物的声音
	/// </summary>
	List<AudioClip> m_listood = new List<AudioClip>();
	/// <summary>
	/// 放生音效
	/// </summary>
	List<AudioClip> m_listRelease = new List<AudioClip>();

	//语音
	AudioSource m_asVoice;
	Dictionary<int, AudioClip> m_dicVoiceClip = new Dictionary<int, AudioClip>();
    //目标引导语音
    Dictionary<int, AudioClip> m_dicTargetClip = new Dictionary<int, AudioClip>();

	// Use this or initialization
	void Start () {

        InvokeRepeating("PlayRandomBgm", 0, 60);
		SetMainSound();	
		LoadVoice();
        //设置默认音量
        SetBGMVolume(PlayerPrefsManager.OpenMusic);
        SetSoundVolume(PlayerPrefsManager.OpenSound);
    }

	#region 加载音效

	//初始化
	public void InitializeSound()
	{
		m_asEnvironment = gameObject.AddComponent<AudioSource>();
		m_asEnvironment.clip = Resources.Load("Sound/backGround1") as AudioClip;
		m_asEnvironment.loop = true;
		m_asEnvironment.Play();
		//背景音乐
		m_asBgm = gameObject.AddComponent<AudioSource>();
		m_asBgm.loop = false;
		m_acBgm1 = Resources.Load("Sound/backGround2") as AudioClip;
		m_acBgm2 = Resources.Load("Sound/backGround3") as AudioClip;
	}

	//设置主界面音效
	void SetMainSound()
	{
		m_asMain = gameObject.AddComponent<AudioSource>();
		m_asMain.playOnAwake = false;
		m_asMain.loop = false;
		//角色升级
		m_acLevelUp = Resources.Load("Sound/levelUp") as AudioClip;
		//界面打开
		m_acInterfaceOpen = Resources.Load("Sound/interfaceOpen") as AudioClip;
		//界面关闭
		m_acInterfaceClose = Resources.Load("Sound/interfaceClose") as AudioClip;
		//点击
		m_acClick = Resources.Load("Sound/click") as AudioClip;
		//钻石音效
		m_acDiamond = Resources.Load("Sound/diamond") as AudioClip;
		//获得金币音效
		m_acGoldGain = Resources.Load("Sound/goldGain") as AudioClip;
		//花费金币音效
		m_acGoldUse = Resources.Load("Sound/goldUse") as AudioClip;
		//获得动物/基因音效
		m_acRare1 = Resources.Load("Sound/rare_1") as AudioClip;
		m_acRare3 = Resources.Load("Sound/rare_3") as AudioClip;
		m_acRare5 = Resources.Load("Sound/rare_5") as AudioClip;
		//动物升级/成年
		m_acAnimalUpgrade = Resources.Load("Sound/animalUpgrade") as AudioClip;
		//展馆升级改建完成
		m_acParkUpgrade = Resources.Load("Sound/parkUpgrade") as AudioClip;
		//吃食物声音
		for (int i = 0; i < 9; i++)
		{
			AudioClip ac = Resources.Load(string.Format("Sound/food_{0}", i + 1)) as AudioClip;
			m_listood.Add(ac);
		}
		//放生音效
		for (int i = 1; i <= 3; i++)
		{
			AudioClip ac = Resources.Load(string.Format("Sound/release_{0}", i)) as AudioClip;
			m_listRelease.Add(ac);
		}
	}


	//加载语音
	void LoadVoice()
	{
		m_asVoice = gameObject.AddComponent<AudioSource>();
		m_asVoice.playOnAwake = false;
		m_asVoice.loop = false;
		for (int i = 0; i < ConigMgr.Instance.m_listVoice.Count; i++)
		{
			int id = ConigMgr.Instance.m_listVoice[i];
			if (!m_dicVoiceClip.ContainsKey(id))
			{
				AudioClip clip = Resources.Load(string.Format("Guide Voice/{0}", id.ToString())) as AudioClip;
				m_dicVoiceClip.Add(id, clip);
			}
		}

        for (int i = 0; i < ConigMgr.Instance.m_listTarget.Count; i++)
        {
            int id = ConigMgr.Instance.m_listTarget[i];
            if (!m_dicTargetClip.ContainsKey(id))
            {
                AudioClip clip = Resources.Load(string.Format("Target Voice/{0}_01", id.ToString())) as AudioClip;
                m_dicTargetClip.Add(id, clip);
            }
        }
    }

	#endregion

	#region 播放音效

	//随机播放背景音乐
	void PlayRandomBgm()
	{
		int iRandom = Random.Range(0, 10);
		m_asBgm.clip = iRandom % 2 == 0 ? m_acBgm1 : m_acBgm2;
        m_asBgm.Play();
	}

	/// <summary>
	/// 播放获得动物/基因音效
	/// </summary>
	public void PlayHighQuality(int iRare)
	{
		if (iRare >= 5)
		{
			m_asMain.clip = m_acRare5;
		}
		else if (iRare > 2 && iRare <= 4)
		{
			m_asMain.clip = m_acRare3;
		}
		else
		{
			m_asMain.clip = m_acRare1;
		}
		m_asMain.Play();
	}


	/// <summary>
	/// 播放升级音效
	/// </summary>
	public void PlayLevelUp()
	{
		m_asMain.clip = m_acLevelUp;
		m_asMain.Play();
	}

	/// <summary>
	/// 播放界面打开音效
	/// </summary>
	public void PlayInteraceOpen()
	{
		m_asMain.clip = m_acInterfaceOpen;
		m_asMain.Play();
	}

	/// <summary>
	/// 播放界面关闭音效
	/// </summary>
	public void PlayInteraceClose()
	{
		m_asMain.clip = m_acInterfaceClose;
		m_asMain.Play();
	}

	/// <summary>
	/// 播放点击音效
	/// </summary>
	public void PlayClick()
	{
		m_asMain.clip = m_acClick;
		m_asMain.Play();
	}

	//播放钻石音效
	public void PlayDiamond()
	{
		m_asMain.clip = m_acDiamond;
		m_asMain.Play();
	}

	/// <summary>
	/// 播放获得金币音效
	/// </summary>
	public void PlayGoldGain()
	{
		m_asMain.clip = m_acGoldGain;
		m_asMain.Play();
	}

	//播放花费金币音效
	public void PlayGoldUse()
	{
		m_asMain.clip = m_acGoldUse;
		m_asMain.Play();
	}

	/// <summary>
	/// 播放动物升级/成年音效
	/// </summary>
	public void PlayAnimalUpgrade()
	{
		m_asMain.clip = m_acAnimalUpgrade;
		m_asMain.Play();
	}

	/// <summary>
	/// 播放展馆解锁/升级/改建完成
	/// </summary>
	public void PlayParkUpgrade()
	{
		m_asMain.clip = m_acParkUpgrade;
		m_asMain.Play();
	}

	/// <summary>
	/// 播放吃食物音效
	/// </summary>
	public void Playood(int id)
	{
		m_asMain.clip = m_listood[id - 1];
		m_asMain.Play();
	}

	/// <summary>
	/// 播放放生音效
	/// </summary>
	public void PlayRelease(int index)
	{
		m_asMain.clip = m_listRelease[index];
		m_asMain.Play();
	}

	//播放语音
	public void PlayVoice(int iId)
	{
		if (m_dicVoiceClip.ContainsKey(iId))
		{
			m_asVoice.clip = m_dicVoiceClip[iId];
			m_asVoice.Play();
		}
	}

    /// <summary>
    /// 播放目标引导语音
    /// </summary>
    public void PlayTarget(int iId)
    {
        if (m_dicTargetClip.ContainsKey(iId))
        {
            m_asVoice.clip = m_dicTargetClip[iId];
            m_asVoice.Play();
        }
    }

	#endregion

	//设置背景音乐音量
	public void SetBGMVolume(float Volume)
	{
		m_asBgm.volume = Volume;
        m_asEnvironment.volume = Volume;
	}

    /// <summary>
    /// 设置背景音乐静音
    /// </summary>
    public void SetBGMMute(bool bMute)
    {
        m_asBgm.mute = bMute;
        m_asEnvironment.mute = bMute;
    }

	//设置场景中的其他音效音量
	public void SetSoundVolume(float Volume)
	{
		m_asMain.volume = Volume;
        m_asVoice.volume = Volume;
    }
}
