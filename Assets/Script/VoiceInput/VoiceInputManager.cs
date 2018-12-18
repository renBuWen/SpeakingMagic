using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class VoiceInputManager : MonoBehaviour
{
    //-----------------------------------//
    // 关键词识别对象
    private KeywordRecognizer keywordRecognizer;
    // 存放关键词的字典
    private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    private bool Changed = false;

    //对外接口：添加 语音识别输入 事件
    public void AddEvent(string key, System.Action action)
    {
        keywords.Add(key, action);
        Changed = true;
    }

    // Use this for initialization
    void Start()
    {

    }

    public void HandleInputString(string str){
        System.Action keywordAction;
        // if the keyword recognized is in our dictionary, call that Action.
        // 如果关键字在我们的字典中被识别，调用该action。
        if (keywords.TryGetValue(str, out keywordAction))
        {
            //执行该action
            keywordAction.Invoke();
        }
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args){
        HandleInputString(args.text);
    }

    // Update is called once per frame
    void Update()
    {
        if (Changed)
        {
            Changed = false;
            // 向字典中添加关键词，key为关键词， vallue为一个匿名action
            // 初始化关键词识别对象
            keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
            // 添加关键词代理事件
            keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
            // 注意：这方法一定要写，开始执行监听
            keywordRecognizer.Start();
            Debug.Log("VoiceInputStart");
        }
    }
}