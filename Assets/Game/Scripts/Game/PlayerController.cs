
using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    private TextMeshPro nameTmp;
    [HideInInspector]
    private TextMeshPro hpTmp;
    [HideInInspector]
    private TextMeshPro atkTmp;
    [HideInInspector]
    private TextMeshPro speedTmp;
    public Player player = new Player();
    public bool isLeft = true;
    public GameObject target;           // 被攻击的目标
    public float moveSpeed = 15f;        // 移动速度
    public float attackRange = 1f;      // 攻击范围
    public float attackDamage = 10f;    // 攻击伤害
    public float returnDelay = 0.25f;      // 攻击后返回原地的延迟时间

    private Vector3 originalPosition;   // 原始位置
    private bool isAttacking = false;   // 是否正在攻击
    private bool isReturning = false;   // 是否正在返回
    void Awake()
    {
        nameTmp = transform.Find("NameTextTmp").GetComponent<TextMeshPro>();
        hpTmp = transform.Find("HpTextTmp").GetComponent<TextMeshPro>();
        atkTmp = transform.Find("AtkTextTmp").GetComponent<TextMeshPro>();
        speedTmp = transform.Find("SpeedTextTmp").GetComponent<TextMeshPro>();
    }
    void Start()
    {
        // 记录原始位置
        originalPosition = transform.position;
    }
    public void Init(string name, int hp, int atk, int speed, Soldier soldier)
    {
        nameTmp = transform.Find("NameTextTmp").GetComponent<TextMeshPro>();
        hpTmp = transform.Find("HpTextTmp").GetComponent<TextMeshPro>();
        atkTmp = transform.Find("AtkTextTmp").GetComponent<TextMeshPro>();
        speedTmp = transform.Find("SpeedTextTmp").GetComponent<TextMeshPro>();
        nameTmp.text = name;
        hpTmp.text = "hp:" + hp.ToString();
        atkTmp.text = "atk:" + atk.ToString();
        speedTmp.text = "sp:" + speed.ToString();
        player.hp = hp;
        player.atk = atk;
        player.mp = hp;
        player.sp = speed;
        player.sodierName = soldier.SodierName;
        player.soldierId = soldier.SoldierId;
        player.uuid = Guid.NewGuid().ToString();
    }
    public void TakeDamage(int damage)
    {
        player.hp -= damage;
        if (player.sodierName == "主将")
        {
            PlayerData.SetInt(PlayerData.Hp, player.hp);
        }
        if (player.hp <= 0)
        {
            player.hp = 0;
            Die();
        }
        else
            hpTmp.text = "hp:" + player.hp.ToString();
    }
    public void Die()
    {
        hpTmp.text = "已阵亡";
    }
    public void PlayAttackAnim()
    {

    }
    void Update()
    {
        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            if (!isAttacking && distanceToTarget <= attackRange)
            {
                // 进入攻击范围，开始攻击
                Attack();
                isAttacking = true;
                StartCoroutine(ReturnAfterDelay(returnDelay));
            }
            else if (!isAttacking && !isReturning)
            {
                // 不在攻击范围内且不在返回过程中，移动到目标
                MoveToTarget();
            }
            else if (isReturning)
            {
                // 在返回过程中，移动到原始位置
                ReturnToOriginalPosition();
            }
        }
    }
    void Attack()
    {
        // 在这里添加攻击逻辑，例如减少目标的生命值
        //TODO:增加防御
        int realDmg = player.atk;
        target.GetComponent<PlayerController>()?.TakeDamage(realDmg);
    }
    void MoveToTarget()
    {
        // 计算朝向目标的移动方向
        Vector3 direction = (target.transform.position - transform.position).normalized;
        // 移动对象
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
    void ReturnToOriginalPosition()
    {
        // 计算朝向原始位置的移动方向
        Vector3 direction = (originalPosition - transform.position).normalized;
        // 移动对象
        transform.position += direction * moveSpeed * Time.deltaTime;

        // 检查是否到达原始位置
        if (Vector3.Distance(transform.position, originalPosition) < 0.1f)
        {
            StopAllCoroutines();
            isAttacking = false;
            isReturning = false;
            target = null;
            EventManager.DispatchEvent(EventName.SetNextRoundPlayerId);

        }
    }

    private System.Collections.IEnumerator ReturnAfterDelay(float delay)
    {
        // 等待一段时间
        yield return new WaitForSeconds(delay);
        // 开始返回
        isReturning = true;
    }
}