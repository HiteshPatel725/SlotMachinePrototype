using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Reels : MonoBehaviour
{
    [HideInInspector]
    public List<SymbolScriptableObject> DataList;

    public List<RectTransform> List_Symbol;
    public float timer;
    bool isTimerRunning = false;
    private bool isSpinning = true;
    float timeCount;
    // Start is called before the first frame update
    void Start()
    {
        timeCount = timer;
    }

    public void InitializeReel()
    {
        for (int i = 0; i < List_Symbol.Count; i++)
        {
            int range = Random.Range(0, DataList.Count);
            Symbol mySymbol = List_Symbol[i].GetComponent<Symbol>();
            List_Symbol[i].GetComponent<Image>().sprite = DataList[range].icon;
            mySymbol.myIcon = DataList[range].icon;
            mySymbol.Special = DataList[range].isSpecial;
        }
    }
    public void SpinReel()
    {
        isTimerRunning = true;

        StartCoroutine(StartRoundSpin());
    }
    public void ResetReel()
    {
        timeCount = timer;
        isTimerRunning = false;
        isSpinning = true;
    }
    void Update()
    {
        if (isTimerRunning)
        {
            timeCount -= Time.deltaTime;
            if (timeCount <= 0f)
            {
                isTimerRunning = false;
                isSpinning = false;
                //StopAllCoroutines();
            }
        }
    }
    IEnumerator StartRoundSpin()
    {
        while (isSpinning)
        {
            yield return MoveSymbol(Ease.Linear, 0.12f);
        }
        yield return MoveSymbol(Ease.OutElastic, 0.5f);
    }

    IEnumerator MoveSymbol(Ease effect, float time)
    {
        for (int i = 0; i < List_Symbol.Count; i++)
        {
            List_Symbol[i].DOAnchorPosY(List_Symbol[i].anchoredPosition.y - 150, time).SetEase(effect);
        }

        yield return new WaitForSeconds(time);

        RectTransform tempSymbol= List_Symbol[List_Symbol.Count - 1];
        for (int i = List_Symbol.Count-1; i > 0; i--)
        {
            
            List_Symbol[i] = List_Symbol[i - 1];
        }
        List_Symbol[0] = tempSymbol;


        int range = Random.Range(0, DataList.Count);
        Symbol mySymbol= List_Symbol[List_Symbol.Count - 1].GetComponent<Symbol>();
        List_Symbol[List_Symbol.Count - 1].GetComponent<Image>().sprite = DataList[range].icon;
        mySymbol.myIcon = DataList[range].icon;
        mySymbol.Special = DataList[range].isSpecial;
        List_Symbol[List_Symbol.Count - 1].anchoredPosition = new Vector2(0, 300);
        //StartCoroutine(MoveSymbol());
    }
    

}
