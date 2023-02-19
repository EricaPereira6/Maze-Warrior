using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpBar : MonoBehaviour
{

    private Transform self;
    private Transform cameraTransform;

    private RectTransform npcHpBg, npcHpBar;
    private float npcHpBarWidth;

    private void Awake()
    {

        self = transform;
        cameraTransform = Camera.main.transform;

        npcHpBg = self.Find("npc_hp_bg").GetComponent<RectTransform>();
        npcHpBar = self.Find("npc_hp_bar").GetComponent<RectTransform>();

        npcHpBarWidth = npcHpBg.sizeDelta.x;
    }


    void Start()
    {

        
    }

    void Update()
    {
        self.LookAt(cameraTransform);
    }

    public void SetHp(float hp, float maxHp)
    {
        Vector2 size = npcHpBar.sizeDelta;
        size.x = Mathf.Max(hp, 0) / maxHp * npcHpBarWidth;

        npcHpBar.sizeDelta = size;
    }
}
