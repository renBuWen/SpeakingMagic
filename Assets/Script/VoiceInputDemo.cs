using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class VoiceInputDemo : MonoBehaviour
{
    PlayerController player;
    public DialogManager dialogManager;
    public BoardManager boardManager;

    //-----------------------------------//
    // 关键词识别对象
    private KeywordRecognizer keywordRecognizer;
    // 存放关键词的字典
    private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    // Use this for initialization
    void Start()
    {
        player= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        Debug.Log("VoiceInputStart");
        // 向字典中添加关键词，key为关键词， vallue为一个匿名action
        keywords.Add("fire ball", () => { player.UseMagic(1); });
        keywords.Add("The sky set you aflame", () => { player.UseMagic(1); });
        keywords.Add("Sun strike", () => { player.UseMagic(2); });
        keywords.Add("follow my will", () => { player.UseMagic(4); });
        keywords.Add("leave for my will", () => { player.UseMagic(5); });


        keywords.Add("hello", () => { dialogManager.HandleInput("hello"); });
        keywords.Add("good bye", () => { dialogManager.HandleInput("good bye"); });
        keywords.Add("as you wish", () => { dialogManager.HandleInput("as you wish"); });
        keywords.Add("go fuck yourself", () => { dialogManager.HandleInput("go fuck yourself");});

        //keywords.Add("long ago two races ruled over earth humans and monster",()=> { boardManager.HandleInput("long ago two races ruled over earth humans and monster"); });  
        //keywords.Add("one day war broke out between the two races", () => { boardManager.HandleInput("one day war broke out between the two races"); });
        //keywords.Add("after a long battle the humans were victorious", () => { boardManager.HandleInput("after a long battle the humans were victorious"); });
        //keywords.Add("they sealed the monsters under ground with a magic spell", () => { boardManager.HandleInput("they sealed the monsters under ground with a magic spell"); });
        AddSingleWordsByBoradManager("long ago two races ruled over earth humans and monster one day war broke out between the two races after a long battle the humans were victorious they sealed the monsters under ground with a magic spell");
       
        // 初始化关键词识别对象
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        // 添加关键词代理事件
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        // 注意： 这方法一定要写，开始执行监听
        keywordRecognizer.Start();
    }

    public void AddSingleWordsByBoradManager(string words)
    {
        string[] split = words.Split(' ');
        foreach (string s in split)
        {
            if (s.Trim() != "" && !keywords.ContainsKey(s))
            {
                keywords.Add(s, () =>{ boardManager.HandleInput(s); });
            }
        }
    }

    public void HandleInputString(string str){
        System.Action keywordAction;
        // if the keyword recognized is in our dictionary, call that Action.
        // 如果关键字在我们的字典中被识别，调用该action。
        if (keywords.TryGetValue(str, out keywordAction))
        {
            //Debug.Log("听到了，进入了事件方法  关键词语 ： " + args.text.ToString());
            // 执行该action
            keywordAction.Invoke();
        }
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        HandleInputString(args.text);

    }

    // Update is called once per frame
    void Update()
    {

    }
}