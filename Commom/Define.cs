using UnityEngine;
using System;

#region 通用Define
public static class Define
{
	public static int ResolutionDesignWidth 	= Screen.width;
	public static int ResolutionDesignHeight 	= Screen.height;
	//屏幕高宽比
	public static float ScreenAspectRatio = 0.75f;

	/// <summary>
	/// Main底部Anchor高度
	/// </summary>
	public static float AnchorBottomHeight = -375f;

	public static float AnchorBottomLeft = -667f;

	/// <summary>
	/// 默认动物
	/// </summary>
	public static int DefaultAnimal = 1006;

	/// <summary>
	/// 是否需要引导
	/// </summary>
	public static bool NeedToGuide;
    /// <summary>
    /// 目标引导进行中
    /// </summary>
    public static bool TargetGuide;

	/// <summary>
	/// 动物饥饿时间
	/// </summary>
	public static float[] AnimalHungerTime = {
		60f,
		84f,
		117f,
		164f,
		230f, 
		322f,
		451f,
		632f,
		885f,
		1239f,
	};

    /// <summary>
    /// 动物中心升级需要金币（loading配置表前方便计算）
    /// </summary>
    public static int[] CenterLvCoin = { 
        0,//占位
        100,//1升级2
        5000,//2升3
        20000,//3升4
        100000,//4升5
        400000,//5升6
        800000,//6升7
        1400000,//7升8
        2200000,//8升9
        5000000,//9升10
        12000000,//10升11
        22000000,//11升12
    };

    /// <summary>
    /// 搜寻金币价格
    /// </summary>
    public static int[] SearchPrice = { 
        300,//占位
        300,
        800,
        1800,
        4800,
        8750,
        14400,
        24500,
        32000,
        40000,
        50000,
        60000,
        72000,
    };

    /// <summary>
    /// 搜寻等级（低等级）
    /// </summary>
    public static int[] SearchLvLow = { 
        1,1,1,1,2,2,2,3,3,3,4,4,5
    };

    /// <summary>
    /// 搜寻等级（高等级）
    /// </summary>
    public static int[] SearchLvHigh = { 
        1,1,1,2,3,4,4,5,5,6,6,7,8
    };

	/// <summary>
	/// AR场景中的动物
	/// </summary>
	public static string AnimalNameInAR;
	/// <summary>
	/// AR场景中动物的稀有度
	/// </summary>
	public static int AnimalRareAR;

    /// <summary>
    /// 中国时区
    /// </summary>
    public static TimeZoneInfo TimaZoneChina;

    /// <summary>
    /// 每一种食物对应数量
    /// </summary>
    public static int[] arrayFoodNum = {
        16, //草料
        9, //树叶
        3, //水草
        3, //藻类
        3, //竹子
        8, //松果
        8, //水果
        7, //谷物
        1, //蜂蜜
        4, //鱼饲料
        1, //鸟饲料
        20,//昆虫
        4,//浮游生物
        30,//肉
        33 //鱼肉
    };

    /// <summary>
    /// 放生给的钻石，按稀有度1-6（每级）
    /// </summary>
    public static int[] ReleaseDiamond = { 
        0, 0, 1, 2, 4, 6
    };


    /// <summary>
    /// 尺寸为1的展馆所拥有的位置
    /// </summary>
    public static int[] arrayParkSize1Pos = { 
        -60, 60
    };

    /// <summary>
    /// 尺寸为2的展馆所拥有的位置
    /// </summary>
    public static int[] arrayParkSize2Pos = {
        -210, -105, 0, 105, 210
    };

    /// <summary>
    /// 尺寸为3的展馆所拥有的位置
    /// </summary>
    public static int[] arrayParkSize3Pos = {
        -360, -240, -120, 0, 120, 240, 360
    };

    /// <summary>
    /// 尺寸为4的展馆所拥有的位置
    /// </summary>
    public static int[] arrayParkSize4Pos = {
        -520, -405, -290, -175, -60, 60, 175, 290, 405, 520
    };

    /// <summary>
    /// 尺寸为5的展馆所拥有的位置
    /// </summary>
    public static int[] arrayParkSize5Pos = {
        -660, -550, -440, -330, -220, -110, 0, 110, 220, 330, 440, 550, 660
    };
}
#endregion
