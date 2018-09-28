#region 通用枚举
//场景lag枚举
public enum Scenelag : int
{
	SCENE_LOGIN = 0,
	SCENE_MAIN,
	SCENE_AR,
}

//锚点lag枚举
public enum Anchorlag : int
{
	TopLet = 0,
	Top,
	TopRight,
	Let,
	Center,
	Right,
	BottomLet,
	Bottom,
	BottomRight,
}

/// <summary>
/// 场馆类型枚举
/// </summary>
public enum ScenePark : int
{
	orest = 0, //森林
	Grassland,//草原
	River,//河流
	Ocean,//海洋
	Desert,//沙漠
	Wetlands,//湿地
	Mountain,//高山
	Polar,//极地
}

#endregion
