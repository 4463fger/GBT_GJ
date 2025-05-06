using UnityEngine;
using JKFrame;
using System.Collections.Generic;
using TMPro;
using Game;
public class UI_TalentTree : UI_WindowBase
{
    [SerializeField] private RectTransform content;
    [SerializeField] private Transform contentRoot;
    [SerializeField] private GameObject talentPrefab;
    [SerializeField] private GameObject linePrefab;
    [SerializeField] private Transform DescriptionTf;
    [SerializeField] private TextMeshProUGUI talentNameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI isCanLockedText;
    private Dictionary<string,GameObject> currentTalent=new Dictionary<string,GameObject>();
    private float border=250;
    private float minY = -340;
    private float maxY = 340;
    private float gap = 400;
    private float lineGap = 15;
    private float outlineHeight = 50;
    private void Start()
    {
        TalentDataConfigList = TalentTreeManager.Instance.talentConfig.talantDatas;
        content.sizeDelta = new Vector2(TalentTreeManager.Instance.talentConfig.talantDatas.Count*500, 0);
        EventSystem.AddEventListener<TalentDataConfig>(Defines.SetDescription, SetDescription);
        ShowTree();
    }
    private void OnDestroy()
    {
        EventSystem.AddEventListener<TalentDataConfig>(Defines.SetDescription, SetDescription);
    }
    private List<TalentDataConfig> TalentDataConfigList;
    private void ShowTree()
    {
        float startX = -800;
        float spacing = 0;
        int currentLevel=-1;
        float currentY=0;
        for (int i = 0;i< TalentDataConfigList.Count;i++) 
        {
            if(currentLevel!= TalentDataConfigList[i].currentLevelMaxIndex)
            {
                currentLevel = TalentDataConfigList[i].currentLevelMaxIndex;
                print(currentLevel);
                if(currentLevel==1)//如果该层只有1个天赋
                {
                    spacing = 0;
                }
                else
                {
                    spacing = (maxY - minY) / (currentLevel + 1);//更新同层相隔距离
                    startX += gap;//更新层数位置
                    currentY = minY;//刷新y轴
                }
            }
            if(spacing==0)
            {
                CreateGameObject(TalentDataConfigList[i],startX,0);
            }
            else
            {
                currentY += spacing;
                CreateGameObject(TalentDataConfigList[i], startX, currentY);
            }
            
        }
    }
    private void CreateGameObject(TalentDataConfig talentDataConfig,float x,float y)
    {
        print("x:" + x + "y:" + y);
        GameObject prefab=Instantiate(talentPrefab,contentRoot);
        prefab.GetComponent<TalentPrefab>().InitPrefab(talentDataConfig,x,y);
        currentTalent.Add(talentDataConfig.talentName, prefab);
        print(currentTalent.Count);
        CreateLine(prefab);
    }
    private void CreateLine(GameObject curTalent)
    {
        TalentDataConfig talentDataConfig = curTalent.GetComponent<TalentPrefab>().currentTalent;
        if(talentDataConfig.preData.Count!=0)
        {
            for(int i = 0;i<talentDataConfig.preData.Count;i++)
            {
                if (currentTalent.ContainsKey(talentDataConfig.preData[i].talentName))
                {
                    Vector2 prePos = currentTalent[talentDataConfig.preData[i].talentName].GetComponent<RectTransform>().anchoredPosition;
                    Vector2 curPos = curTalent.GetComponent<RectTransform>().anchoredPosition;
                    //创建第一折
                    float x1=((curPos.x-prePos.x)-2*outlineHeight)/4+prePos.x+outlineHeight;
                    float y1 = prePos.y;
                    GameObject line1=Instantiate(linePrefab,contentRoot);
                    line1.GetComponent<RectTransform>().anchoredPosition=new Vector2(x1,y1);
                    line1.GetComponent<RectTransform>().sizeDelta = new Vector2((curPos.x - prePos.x-2*outlineHeight) / 2,lineGap);
                    //创建第二折
                    float x2, y2;
                    GameObject line2 = Instantiate(linePrefab, contentRoot);
                    if (curPos.x!=prePos.x)
                    {
                        x2 = prePos.x + ((curPos.x - prePos.x)) / 2;
                        y2 = prePos.y + (curPos.y - prePos.y) / 2;
                        line2.GetComponent<RectTransform>().sizeDelta = new Vector2(lineGap, Mathf.Abs(Mathf.Abs(curPos.y) - Mathf.Abs(prePos.y)) + lineGap);
                    }
                    else
                    {
                        x2= prePos.x;
                        y2=prePos.y-(prePos.y-curPos.y)/2;
                        float Yimage = Mathf.Abs(Mathf.Abs(prePos.y) - Mathf.Abs(curPos.y))-2*outlineHeight;
                        line2.GetComponent<RectTransform>().sizeDelta = new Vector2(lineGap,Yimage);
                    }
                    line2.GetComponent<RectTransform>().anchoredPosition = new Vector2(x2, y2);
                    
                    //创建第三折
                    float x3=curPos.x-(((curPos.x - prePos.x) - 2 * outlineHeight) / 4)-outlineHeight;
                    float y3 = curPos.y;
                    GameObject line3= Instantiate(linePrefab, contentRoot);
                    line3.GetComponent<RectTransform>().anchoredPosition = new Vector2(x3, y3);
                    line3.GetComponent<RectTransform>().sizeDelta = new Vector2((curPos.x - prePos.x - 2 * outlineHeight) / 2, lineGap);
                    line1.transform.SetSiblingIndex(0);
                    line2.transform.SetSiblingIndex(0);
                    line3.transform.SetSiblingIndex(0);
                }
            }
        }
    }
    private void SetDescription(TalentDataConfig talentDataConfig)
    {
        DescriptionTf.gameObject.SetActive(true);
        talentNameText.text = talentDataConfig.talentName;
        descriptionText.text = talentDataConfig.talentDescription;
        bool isCanActive=true;
        for(int i = 0; i < talentDataConfig.preData.Count; i++) 
        {
            if (!TalentTreeManager.Instance.talentDataConfigs.Contains(talentDataConfig.preData[i])) 
            {
                isCanActive = false;
                return;
            }
        }
        isCanLockedText.text = isCanActive ? "可解锁" : "未解锁";
    }
}
