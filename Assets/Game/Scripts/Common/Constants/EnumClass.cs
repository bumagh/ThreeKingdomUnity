/**
* UnityVersion: 2019.3.15f1
* FileName:     EnumClass.cs
* Author:       TANYUQING
* CreateTime:   2020/08/31 15:10:46
* Description:  
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 常用枚举类
/// </summary>
public class EnumClass { }

/// <summary>
/// 方块颜色
/// </summary>
public enum BlockColor
{
    /// <summary>
    /// 未设定
    /// </summary>
    None = 0,
    /// <summary>
    /// 绿色方块
    /// </summary>
    Green = 1,
    /// <summary>
    /// 红色方块
    /// </summary>
    Red = 2,
    /// <summary>
    /// 蓝色方块
    /// </summary>
    Blue = 3,
    /// <summary>
    /// 黄色方块
    /// </summary>
    Yellow = 4,
    /// <summary>
    /// 万能方块
    /// </summary>
    AllPowerful = 5
}

/// <summary>
/// 方块归属
/// </summary>
public enum BlockOwner
{
    /// <summary>
    /// 上方（对手）
    /// </summary>
    Up = 1,
    /// <summary>
    /// 下方（我）
    /// </summary>
    Down = 2
}

/// <summary>
/// 回合顺序
/// </summary>
public enum RoundTurn
{
    /// <summary>
    /// 未指定
    /// </summary>
    None = 0,
    /// <summary>
    /// 地图上方的回合(左上0,0 右下4,5)
    /// </summary>
    UpTurn = 1,
    /// <summary>
    /// 地图下方的回合(左上0,6,右下4,11)
    /// </summary>
    DownTurn = 2
}

/// <summary>
/// 消除方向
/// </summary>
public enum ClearDirection
{
    /// <summary>
    /// 无
    /// </summary>
    None = 0,
    /// <summary>
    /// 向上消除（即消除后，方块向屏幕上滑落）
    /// </summary>
    Up = 1,
    /// <summary>
    /// 向下消除（即消除后，方块向屏幕下滑落）
    /// </summary>
    Down = 2,
}

/// <summary>
/// 英雄颜色
/// </summary>
public enum HeroColor
{
    /// <summary>
    ///无
    /// </summary>
    None = 0,
    /// <summary>
    /// 绿
    /// </summary>
    Green = 1,
    /// <summary>
    /// 红
    /// </summary>
    Red = 2,
    /// <summary>
    /// 蓝
    /// </summary>
    Blue = 3,
    /// <summary>
    /// 黄
    /// </summary>
    Yellow = 4
}

/// <summary>
/// 英雄状态
/// </summary>
public enum HeroState
{
    /// <summary>
    /// 未设定
    /// </summary>
    None = 0,
    /// <summary>
    /// 休闲
    /// </summary>
    Idle = 1,
    /// <summary>
    /// 攻击
    /// </summary>
    Attack = 2,
    /// <summary>
    /// 死亡
    /// </summary>
    Die = 3,
    /// <summary>
    /// 下落
    /// </summary>
    Run,
    fall,
    /// <summary>
    /// 施法
    /// </summary>
    Shifa,
    /// <summary>
    /// 受法
    /// </summary>
    //Shoufa,
    /// <summary>
    /// 受击
    /// </summary>
    //Shouji,
    /// <summary>
    /// 被点击
    /// </summary>
    Click
}
/// <summary>
/// 子弹状态
/// </summary>
public enum BulletState
{
    /// <summary>
    /// 未设定
    /// </summary>
    None = 0,
    /// <summary>
    /// 攻击
    /// </summary>
    Attack = 1,
    /// <summary>
    /// 施法
    /// </summary>
    Shifa,
    /// <summary>
    /// 受法
    /// </summary>
    Shoufa,
    /// <summary>
    /// 受击
    /// </summary>
    Shouji
}
/// <summary>
/// 战斗类型
/// </summary>
public enum BattleType
{
    /// <summary>
    /// 无
    /// </summary>
    None = 0,
    /// <summary>
    /// 推关卡打怪
    /// </summary>
    PvE = 1,
    /// <summary>
    /// 玩家竞技
    /// </summary>
    PvP = 2,
    /// <summary>
    /// 引导模式
    /// </summary>
    Guide
}

/// <summary>
/// 地图布局
/// </summary>
public enum MapLayout
{
    /// <summary>
    /// 无
    /// </summary>
    None,
    /// <summary>
    /// 上4下6型（适用于普通pve关卡）
    /// </summary>
    Up4Down6,
    /// <summary>
    /// 上下均5(适用于pve的boss关卡和pve)
    /// </summary>
    Up5Down5
}

/// <summary>
/// 方块类型
/// </summary>
public enum BlockType
{
    /// <summary>
    /// 无
    /// </summary>
    None,
    /// <summary>
    /// 普通方块
    /// </summary>
    Normal,
    /// <summary>
    /// 英雄方块
    /// </summary>
    Hero,
    /// <summary>
    /// 障碍物块
    /// </summary>
    Obstacle
}

/// <summary>
/// 障碍物（方块）类型
/// </summary>
public enum ObstacleType
{
    /// <summary>
    /// 无
    /// </summary>
    None,
    /// <summary>
    /// 箱子型（可被摧毁，不可移动，不可穿过）
    /// </summary>
    Case,
    /// <summary>
    /// 石块型（不可摧毁，不可移动，不可穿过）
    /// </summary>
    Stone,
    /// <summary>
    /// 黑洞型（不可摧毁，不可移动，可被穿过）
    /// </summary>
    BlackHole,
    /// <summary>
    /// 机关型（不可摧毁，不可移动，不可穿过）
    /// </summary>
    Trap
}

/// <summary>
/// 方块拖拽方向
/// </summary>
public enum BlockDragDir
{
    /// <summary>
    /// 无
    /// </summary>
    None = -1,
    /// <summary>
    /// 上
    /// </summary>
    Up = 0,
    /// <summary>
    /// 右上
    /// </summary>
    RightUp = 1,
    /// <summary>
    /// 右
    /// </summary>
    Right = 2,
    /// <summary>
    /// 右下
    /// </summary>
    RightDown = 3,
    /// <summary>
    /// 下
    /// </summary>
    Down = 4,
    /// <summary>
    /// 左下
    /// </summary>
    LeftDown = 5,
    /// <summary>
    /// 左
    /// </summary>
    Left = 6,
    /// <summary>
    /// 左上
    /// </summary>
    LeftUp = 7
}

/// <summary>
/// 英雄品质
/// </summary>
public enum HeroQuality
{
    C = 1,
    B = 2,
    A = 3,
    S = 4
}
public enum CenterBtnEnums
{
    /// <summary>
    /// 未指定
    /// </summary>
    PersonItems = 0,
    /// <summary>
    /// 地图上方的回合(左上0,0 右下4,5)
    /// </summary>
    FacilityItems = 1,
    /// <summary>
    /// 地图下方的回合(左上0,6,右下4,11)
    /// </summary>
    MapItems = 2,
    FuncItems = 3
}
public enum EquipTypeEnums
{
    Helmet = 1,
    Weapon = 2,
    Boots = 3,
    Armor = 4,
    Necklace = 5,
    Wristband = 6,
}