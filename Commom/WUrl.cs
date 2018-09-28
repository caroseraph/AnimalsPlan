using UnityEngine;

public static class WUrl
{
	
	//The url or local path Assets/streamingAssetsPath
	public static string	LocalURL
	{
		get{
#if UNITY_IPHONE
			return string.Format("File://{0}/IOS/",Application.streamingAssetsPath);
#elif UNITY_ANDROID
			return string.Format("File://{0}/Android/",Application.streamingAssetsPath);
#elif UNITY_EDITOR
			return string.Format("File://{0}/",Application.streamingAssetsPath);
#else
			return string.Format("jar:ile://{0}!/assets/Android/",Application.dataPath);
#endif
//#endif
		}
	}

	public static string LocalStreamPath
	{
		get{ 
		#if UNITY_EDITOR
		return string.Format("File://{0}",Application.streamingAssetsPath);
		#elif UNITY_ANDROID
		return string.Format("{0}",Application.streamingAssetsPath);
		#else
		return string.Format("File://{0}",Application.streamingAssetsPath);
		#endif
		}
	}
}



