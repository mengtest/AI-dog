﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MasterDialogueItem : MonoBehaviour {
    private Text message;
    public List<string> keywords = new List<string>();
    public GameObject petMessage;
    //private Transform VerticalLayout;
    void Start()
    { 
        message= transform.Find("message_text").gameObject.GetComponent<Text>();
        if (this.transform.Find("dog_bg").gameObject.activeInHierarchy ==false)
        {
            SearchMessage();
        }
        }
    void SearchMessage()
    {
        int count = 0;
       if(message.text!=null&&message.text.Length!=0)
        {
            foreach(var item in keywords)
            {
                string currentMessage = item;             
                if (message.text.Contains(currentMessage))
                {
                    Message.instance.SetKeyCodes(currentMessage);
                    FilterMessage(currentMessage);
                }
                else
                {
                    count++;
                }
            }
        }
       if(count>=keywords.Count)
        {
            StartCoroutine(DefaultAnswer());
        }
    }
    void FilterMessage(string currentMessage)
    {
        switch(currentMessage)
        {
            case "启动":
            case "你好":
            case "小狗同学":   
               StartCoroutine(StartUp());
                break;
            case "巡逻":
            case "看家":
            case "出门":
            case "看下家":
                StartCoroutine(Trail());
                break;
            case "超市":
            case "买":
                StartCoroutine(Shopping());
                Debug.Log("超市");
                break;
            case "再见":
            case "关闭":
            case "拜拜":
            case "关机":
                StartCoroutine(SwitchClosing());
                break;
            case "过来":
            case "坐下":
            case "回来":
               StartCoroutine(Comeback());
                break;
            default:StartCoroutine(DefaultAnswer());
                break;             
        }
    }
	IEnumerator StartUp()
    {
        yield return new WaitForSeconds(1.0f);
        InstantiatePetMessage("你好,我的朋友");
    }
    IEnumerator DefaultAnswer()
    {
        yield return new WaitForSeconds(1.0f);
        InstantiatePetMessage("我不知道你在说什么");
    }
    IEnumerator Trail()
    {
        yield return new WaitForSeconds(1.0f);
        //TODO 巡逻
        InstantiatePetMessage("好的，我将保证没有一只苍蝇");
    }
    IEnumerator Shopping()
    {
        yield return new WaitForSeconds(1.0f);
        InstantiatePetMessage("好的你想购买点什么呢?");
        yield return new WaitForSeconds(1.0f);
        TransformState.instance.ShoppingState();
        //TODO 购物
    }
    IEnumerator SwitchClosing()
    {
        yield return new WaitForSeconds(1.0f);
        InstantiatePetMessage("拜拜");
    }
    IEnumerator Comeback()
    {
        yield return new WaitForSeconds(1.0f);
        InstantiatePetMessage("马上");
    }
    void InstantiatePetMessage(string message)
    {
        this.transform.Find("dog_message").gameObject.GetComponent<Text>().text = message;
        this.transform.Find("dog_bg").gameObject.SetActive(true);
        this.transform.Find("dog_name").gameObject.SetActive(true);
        this.transform.Find("dog_message").gameObject.SetActive(true);
        
    }
	
}
