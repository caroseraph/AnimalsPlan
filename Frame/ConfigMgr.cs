using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class ConigMgr : Singleton<ConigMgr>  
{
	//加载配置表
	public void LoadConigs()
	{
		LoadMsg();
		LoadGuideText();
		LoadTipsText();
        LoadTargetText();
        Internationalization.Startup();
	}
	
	#region 加载动物离别发言配置表

	Dictionary<int, string> dicMsg = new Dictionary<int, string>();
	private void LoadMsg()
	{
		dicMsg.Clear();
		TextAsset asset = Resources.Load(LocalResConfig.ConfigMessage, typeof(TextAsset)) as TextAsset;
		if (asset){
			XmlDocument doc = new XmlDocument ();
			doc.LoadXml(asset.text);

			XmlNode rootNode = doc.DocumentElement;
			XmlNodeList nodes = rootNode.ChildNodes;
			for(int i = 0; i < nodes.Count; i++)
			{
				XmlNode node = nodes[i];
				int id = System.Convert.ToInt32(node.Attributes["id"].Value);
				string text = node.Attributes["text"].Value;
				dicMsg.Add(id, text);
			}
		}
	}

	//随机离别发言
	public string RandomMsg(int index)
	{
		return dicMsg[index];
	}

	#endregion

	#region 加载引导文字配置表
	/// <summary>
	/// 引导语字典
	/// </summary>
	Dictionary<int, string> dicGuideText = new Dictionary<int, string>();

	private void LoadGuideText()
	{
		dicGuideText.Clear();
		TextAsset asset = Resources.Load(LocalResConfig.ConfigGuideText, typeof(TextAsset)) as TextAsset;
		if (asset)
		{
			XmlDocument doc = new XmlDocument ();
			doc.LoadXml(asset.text);

			XmlNode rootNode = doc.DocumentElement;
			XmlNodeList nodes = rootNode.ChildNodes;
			for(int i = 0; i < nodes.Count; i++)
			{
				XmlNode node = nodes[i];
				int id = System.Convert.ToInt32(node.Attributes["id"].Value);
				string text = node.Attributes["text"].Value;
				dicGuideText.Add(id, text);
                m_listVoice.Add(id);
            }
		}
	}

	/// <summary>
	/// 根据ID查询引导语
	/// </summary>
	public string QueryGuideTextById(int id)
	{
		if (dicGuideText.ContainsKey(id))
		{
			return dicGuideText[id];
		}
		return string.Empty;
	}

    public List<int> m_listVoice = new List<int>();

    #endregion

    #region 目标引导文字配置表

    Dictionary<int, string> dicTarget = new Dictionary<int, string>();
    private void LoadTargetText()
    {
        dicTarget.Clear();
        TextAsset asset = Resources.Load(LocalResConfig.ConfigTargetText, typeof(TextAsset)) as TextAsset;
        if (asset)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(asset.text);

            XmlNode rootNode = doc.DocumentElement;
            XmlNodeList nodes = rootNode.ChildNodes;
            for (int i = 0; i < nodes.Count; i++)
            {
                XmlNode node = nodes[i];
                int id = System.Convert.ToInt32(node.Attributes["id"].Value);
                string text = node.Attributes["text"].Value;
                dicTarget.Add(id, text);
                m_listTarget.Add(id);
            }
        }
    }

    /// <summary>
    /// 根据ID查询目标引导文字
    /// </summary>
    public string QueryTargetTextById(int id)
    {
        if (dicTarget.ContainsKey(id))
        {
            return dicTarget[id];
        }
        return string.Empty;
    }

    public List<int> m_listTarget = new List<int>();

    #endregion

    #region Tips配置表

    List<string> listTips = new List<string>();

	private void LoadTipsText()
	{
		listTips.Clear();
		TextAsset asset = Resources.Load(LocalResConfig.ConfigLoading, typeof(TextAsset)) as TextAsset;
        if (asset)
		{
			XmlDocument doc = new XmlDocument ();
			doc.LoadXml(asset.text);

			XmlNode rootNode = doc.DocumentElement;
			XmlNodeList nodes = rootNode.ChildNodes;
			for(int i = 0; i < nodes.Count; i++)
			{
				XmlNode node = nodes[i];
				string text = node.Attributes["text"].Value;
				listTips.Add(text);
			}
		}
	}

	//随机Tips
	public string RandomTips{
		get{
			return listTips[Random.Range(0, listTips.Count)];
		}
	}

	#endregion

}
