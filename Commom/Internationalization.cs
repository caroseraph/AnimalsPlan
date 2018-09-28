using UnityEngine;
using System.Collections.Generic;
using System.Xml;

public static class Internationalization  
{
    /// <summary>
    /// The d text.
    /// </summary>
    private static readonly Dictionary<int, string> dText = new Dictionary<int, string>();

    /// <summary>
    /// The language.
    /// </summary>
    static string[] Language = {
		LocalResConfig.ConfigLanguage,
	};

	/// <summary>
	/// Initlizations the language.
	/// </summary>
	public static void 		InitlizationLanguage(int nType)
	{
		dText.Clear();
		int idx;
		string content;
		TextAsset asset = Resources.Load(Language[nType], typeof(TextAsset)) as TextAsset;
		if (asset)
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(asset.text);
			// get root node list
			XmlNodeList root = doc.SelectNodes("Root");
			foreach(XmlNode node in root)
			{
				XmlNodeList textNodeList = node.SelectNodes("item");
				foreach(XmlNode item in textNodeList)
				{
					try{
						idx = System.Convert.ToInt32(item.Attributes["id"].Value);
						content = item.Attributes["text"].Value;
						dText.Add(idx,content);
					}catch(System.Exception e){
						Debug.LogError(e.Message);
					}
				}
			}
		}

		Resources.UnloadUnusedAssets();
	}

	/// <summary>
	/// Queries the local text.
	/// </summary>
	/// <returns>The local text.</returns>
	/// <param name="index">Index.</param>
	public static string 	QueryLocalText(int index)
	{
		if (dText.ContainsKey(index))
			return dText[index];

		return string.Empty;
	}

	/// <summary>
	/// Awake this instance.
	/// </summary>
	public static void 		Startup()
	{
		int nLanguage = 0;
		InitlizationLanguage(nLanguage);
	}

	/// <summary>
	/// Convers the result.
	/// </summary>
	/// <returns>The result.</returns>
	/// <param name="text">Text.</param>
	public static int 		ConverResult(string text)
	{
		int iBegin = text.IndexOf("ret", System.StringComparison.Ordinal);
		if (iBegin < 0)
			throw new System.ArgumentNullException(nameof(text), "Http Data Error");

		int iEnd = text.IndexOf(",", iBegin, System.StringComparison.Ordinal);
		if (iEnd < 0)
		{
			iEnd = text.IndexOf("}", iBegin, System.StringComparison.Ordinal);
			if (iEnd < 0)
				throw new System.ArgumentNullException(nameof(text), "Http Data Error");
		}

		string result = text.Substring(iBegin, iEnd - iBegin);
		return System.Int32.Parse(result.Substring(5));
	}

	/// <summary>
	/// Shutdown this instance.
	/// </summary>
	public static void 		Shutdown()
	{
		dText.Clear();
	}
}
