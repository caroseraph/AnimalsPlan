using UnityEngine;
using System.Collections.Generic;
using System;

//常见函数
public static class Functions
{
    //单位换算
    public static string UnitsConversion(long iGetNumber)
    {
        double dTemp = iGetNumber * 0.0001;
        if (dTemp >= 100000000)
        {
            return string.Format("{0:####.##}万亿", dTemp * 0.00000001);
        }
        else if (dTemp >= 10000 && dTemp < 100000000)
        {
            return string.Format("{0:####.##}亿", dTemp * 0.0001);
        }
        else if (dTemp >= 10 && dTemp < 10000)
        {
            return string.Format("{0:####.##}万", dTemp);
        }
        else
        {
            return string.Format("{0}", iGetNumber);
        }
    }

    //时间换算
    public static string TimeConversion(int iGetSecond)
    {
        if (iGetSecond > 86400)
        {
            int iHour = (int)((iGetSecond % 86400) / 3600);
            int iDay = (int)(iGetSecond / 86400);
            if (iHour > 0)
                return string.Format("{0}天{1}小时", iDay, iHour);
            else
                return string.Format("{0}天", iDay);
        }
        else if (iGetSecond > 3600 && iGetSecond <= 86400)
        {
            int iSecond = iGetSecond % 60;
            int iMinute = (int)(iGetSecond % 3600 / 60);
            int iHour = (int)(iGetSecond / 3600);
            if (iMinute > 0)
                return string.Format("{0}小时{1}分", iHour, iMinute);
            else
            {
                return string.Format("{0}小时{1}秒", iHour, iSecond);
            }
        }
        else if (iGetSecond > 60 && iGetSecond <= 3600)
        {
            int iSecond = iGetSecond % 60;
            int iMinute = (int)(iGetSecond / 60);
            if (iSecond > 0)
                return string.Format("{0}分{1}秒", iMinute, iSecond);
            else
                return string.Format("{0}分钟", iMinute);
        }
        else
        {
            return string.Format("{0}秒", iGetSecond);
        }
    }

    /// <summary>
    /// 计算分钟（秒）
    /// </summary>
    public static int CalculateMinute(int iSecond)
    {
        int iMinute = (int)(iSecond / 60) + 1;
        return iMinute;
    }

    //字符串转换为整型字典
    public static Dictionary<int, int> StringHandling(string strGetString)
    {
        if (!strGetString.Equals(string.Empty) && !strGetString.Equals("0"))
        {
            Dictionary<int, int> dicTemp = new Dictionary<int, int>();
            if (strGetString.Contains("|"))
            {
                string[] strRes = strGetString.Split('|');
                for (int i = 0; i < strRes.Length; i++)
                {
                    string[] strTmp = strRes[i].Split(',');
                    dicTemp.Add(int.Parse(strTmp[0]), int.Parse(strTmp[1]));
                }
            }
            else
            {
                string[] strTmp = strGetString.Split(',');
                dicTemp.Add(int.Parse(strTmp[0]), int.Parse(strTmp[1]));
            }
            return dicTemp;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 字符串转化为浮点数字典
    /// </summary>
    public static Dictionary<int, float> StringToDic(string strGetString)
    {
        if (!strGetString.Equals(string.Empty) && !strGetString.Equals("0"))
        {
            Dictionary<int, float> dicTemp = new Dictionary<int, float>();
            if (strGetString.Contains("|"))
            {
                string[] strRes = strGetString.Split('|');
                for (int i = 0; i < strRes.Length; i++)
                {
                    string[] strTmp = strRes[i].Split(',');
                    dicTemp.Add(int.Parse(strTmp[0]), float.Parse(strTmp[1]));
                }
            }
            else
            {
                string[] strTmp = strGetString.Split(',');
                dicTemp.Add(int.Parse(strTmp[0]), float.Parse(strTmp[1]));
            }
            return dicTemp;
        }
        else
        {
            return null;
        }
    }

    //字符串转为整形List
    public static List<int> StringToList(string strGetString)
    {
        if (!strGetString.Equals(string.Empty) && !strGetString.Equals("0"))
        {
            List<int> list = new List<int>();
            if (strGetString.Contains("|"))
            {
                string[] strTmp = strGetString.Split('|');
                for (int i = 0; i < strTmp.Length; i++)
                {
                    list.Add(int.Parse(strTmp[i]));
                }
            }
            else if (strGetString.Contains(","))
            {
                string[] strTmp = strGetString.Split(',');
                for (int i = 0; i < strTmp.Length; i++)
                {
                    list.Add(int.Parse(strTmp[i]));
                }
            }
            else
            {
                list.Add(int.Parse(strGetString));
            }
            return list;
        }
        else
        {
            return null;
        }
    }

    //字符串转Vector2
    public static Vector2 Vector2Conversion(string strGetString)
    {
        if (strGetString.Contains(","))
        {
            string[] strTmp = strGetString.Split(',');
            Vector2 vec = new Vector2(float.Parse(strTmp[0]), float.Parse(strTmp[1]));
            return vec;
        }
        return Vector2.zero;
    }

    //字符串转为Vector3
    public static Vector3 Vector3Conversion(string strGetString)
    {
        if (strGetString.Contains(","))
        {
            string[] strTmp = strGetString.Split(',');
            Vector3 vec = new Vector3(float.Parse(strTmp[0]), float.Parse(strTmp[1]), float.Parse(strTmp[2]));
            return vec;
        }
        return Vector3.zero;
    }

    //时间戳转化为DateTime
    public static DateTime UnixConversion(int time)
    {
        DateTime dTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
#if UNITY_IOS && !UNITY_EDITOR
        dTime = TimeZoneInfo.ConvertTime(dTime, Define.TimaZoneChina);
#endif
        long lTime = ((long)time * 10000000);
        TimeSpan toNow = new TimeSpan(lTime);
        DateTime target = dTime.Add(toNow);
        return target;
    }

    //DateTime转为时间戳
    public static int DateTimeToUnix(DateTime datetime)
    {
        DateTime time = new DateTime(1970, 1, 1, 8, 0, 0, datetime.Kind);
        return Convert.ToInt32((datetime - time).TotalSeconds);
    }

    //已过去多少时间换算
    public static string PastTimeConversion(int iGetMinute)
    {
        //>30天
        if (iGetMinute >= 43200)
        {
            int iMonth = (int)(iGetMinute / 43200);
            int iDay = (int)((iGetMinute % 43200) / 3600);
            if (iDay > 0)
                return string.Format("{0}月{1}天", iMonth, iDay);
            else
                return string.Format("{0}月", iMonth);
        }
        //超过一天
        else if (iGetMinute >= 1440 && iGetMinute < 43200)
        {
            int iHour = (int)((iGetMinute % 1440) / 60);
            int iDay = (int)(iGetMinute / 1440);
            if (iHour > 0)
                return string.Format("{0}天{1}小时", iDay, iHour);
            else
            {
                return string.Format("{0}天", iDay);
            }
        }
        //超过1小时
        else if (iGetMinute >= 60 && iGetMinute < 1440)
        {
            int iMinute = (int)(iGetMinute % 60);
            int iHour = (int)(iGetMinute / 60);
            if (iMinute > 0)
                return string.Format("{0}小时{1}分", iHour, iMinute);
            else
            {
                return string.Format("{0}小时", iHour);
            }
        }
        else
        {
            return string.Format("{0}分钟", iGetMinute);
        }
    }

    /// <summary>
    /// 解锁时间转换
    /// </summary>
    public static string UnlockTimeConversion(int iTime)
    {
        DateTime dTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        #if UNITY_IOS && !UNITY_EDITOR
        dTime = TimeZoneInfo.ConvertTime(dTime, Define.TimaZoneChina);
        #endif
		long lTime = ((long)iTime*10000000);
		TimeSpan toNow = new TimeSpan(lTime);
		DateTime target = dTime.Add(toNow);
		return string.Format("{0}年{1}月{2}日", target.Year, target.Month, target.Day);
	}

	//查找Grey Shader
	public static Shader FindGreyShader()
	{
		Shader shaderGrey = Shader.Find("Unlit/Transparent Colored Grey");
		return shaderGrey;
	}

    //查找Transparent Colored Shader
	public static Shader FindTransColorShader()
	{
		Shader shaderTC = Shader.Find("Unlit/Transparent Colored");
		return shaderTC;
	}

	/// <summary>
	/// 数字转为罗马数字
	/// </summary>
	public static string NumberToRoman(int iNum)
	{
		string strNum = "I";
		switch (iNum)
		{
			case 1:
				strNum = "I";
				break;
			case 2:
				strNum = "II";
				break;
			case 3:
				strNum = "III";
				break;
			case 4:
				strNum = "IV";
				break;
			case 5:
				strNum = "V";
				break;
			case 6:
				strNum = "VI";
				break;
			case 7:
				strNum = "VII";
				break;
			case 8:
				strNum = "VIII";
				break;
			case 9:
				strNum = "IX";
				break;
			case 10:
				strNum = "X";
				break;
		}
		return strNum;
	}
}
