/**
* UnityVersion: 2018.3.10f1
* FileName:     Constants.cs
* Author:       Tan Yuqing
* CreateTime:   2019/05/27 17:41:47
* Description:  
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    #region 常量定义

    /// <summary>
    /// 方块下落一层的时间(s)
    /// </summary>
    //public const float BLOCK_DROP_INTERVAL = 0.065f;
    public const float BLOCK_DROP_INTERVAL = 0.065f;
    /// <summary>

    /// <summary>
    /// 离线奖励最低时限（分钟）
    /// </summary>
    public const int OFFLINE_LOWER_LIMIT = 1;
    /// <summary>
    /// （临时敌我最大生命值，测试用）
    /// </summary>
    public const int TEMP_MAX_LIFE = 300;

    /// <summary>
    /// 回合操作时间（秒）
    /// </summary>
    public const int ROUND_OPERATION_TIME = 30;
    /// <summary>
    /// 最后x秒显示计时
    /// </summary>
    public const int SHOW_TIMER_LIMIT = 10;

    #endregion

    #region 路径定义
    /// <summary>
    /// 数据在Resources下的路径
    /// </summary>
    public const string LEVEL_DATA_RES_DIR = "Data/";
    /// <summary>
    /// 预制体路径
    /// </summary>
    public const string PATH_PREFAB = "Prefab/";
    /// <summary>
    /// 弹窗路径
    /// </summary>
    public const string PATH_POPUP_WND = "Prefab/PopUpWnd/";
    /// <summary>
    /// 动画和特效相关预制体路径
    /// </summary>
    public const string PATH_ANIM_EFFECT_PREFAB = "Prefab/AnimEffect/";

    #endregion

    #region PlayerPrefs数据Key定义
    /// <summary>
    /// 玩家数据键-音效开发 
    /// </summary>
    public const string DATA_KEY_SOUND_SWITCH = "SwitchSound";
    /// <summary>
    /// 玩家数据键-音乐开关
    /// </summary>
    public const string DATA_KEY_MUSIC_SWITCH = "SwitchMusic";
    /// <summary>
    /// 玩家数据键-震动开关
    /// </summary>
    public const string DATA_KEY_VIBRATE_SWITCH = "SwitchVibrate";
    /// 玩家数据键-离线时间
    /// </summary>
    public const string DATA_KEY_OFFLINE_TIME = "OfflineTime";

    ///<summary>
    /// 玩家数据键-Buff数据
    /// </summary>
    public const string DATA_KEY_BUFF_DATA = "BuffData";

    /// 玩家数据键-是否启用vip
    /// </summary>
    public const string DATA_KEY_VIP_ENABLE = "VIPEnable";

    /// <summary>
    /// 玩家名称是否输入设置
    /// 0 默认未设置  1设置
    /// </summary>
    public const string DATA_KEY_NAME_SET = "NameSet";

    /// <summary>
    /// 主界面按钮 收回展开状态
    /// 0 默认收回  1 按钮展开
    /// </summary>
    public const string DATA_KEY_MAIN_BTN_STATE_SET = "MainBtnState";

    #endregion

    #region 埋点字符串定义 
    /// <summary>
    /// 战斗按钮点击
    /// </summary>
    public const string battle_button_clicks = "Total number of battle button clicks";
    /// <summary>
    /// 设置按钮点击
    /// </summary>
    public const string set_button_clicks = "Total number of set button clicks";
    /// <summary>
    /// 返回按钮点击
    /// </summary>
    public const string back_button_clicks = "Total number of back button clicks";
    /// <summary>
    /// 任务按钮点击
    /// </summary>
    public const string task_button_clicks = "Total number of task button clicks";
    /// <summary>
    /// 排行榜按钮点击
    /// </summary>
    public const string rank_button_clicks = "Total number of rank button clicks";
    /// <summary>
    /// 个人数据按钮点击
    /// </summary>
    public const string personaldetails_button_clicks = "Total number of personaldetails button clicks";
    /// <summary>
    /// 投降按钮点击
    /// </summary>
    public const string capitulate_button_clicks = "Total number of capitulate button clicks";
    /// <summary>
    /// 重置任务按钮点击
    /// </summary>
    public const string resettask_button_clicks = "Total number of resettask button clicks";
    /// <summary>
    /// 底部英雄按钮点击
    /// </summary>
    public const string bottomhero_button_clicks = "Total number of bottomhero button clicks";
    /// <summary>
    /// 底部战斗按钮点击
    /// </summary>
    public const string bottombattle_button_clicks = "Total number of bottombattle button clicks";
    /// <summary>
    /// 底部商店按钮点击
    /// </summary>
    public const string bottomshop_button_clicks = "Total number of bottombattle button clicks";
    #endregion


    #region 

    #endregion
}
