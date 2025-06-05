using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class GameManager : MonoBehaviour
{
    public List<SymbolScriptableObject> SymbolDataList;
    public List<Reels> ReelsList;
    public List<Symbol> HighlightList;
    public Button SpinButton;
    int count = 0;
    Sprite currentSprite;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < ReelsList.Count; i++)
        {
            ReelsList[i].DataList = SymbolDataList;
            ReelsList[i].InitializeReel();
        }
    }
    public void OnClickSpinButton()
    {
        StartCoroutine(StartSpin());
    }
    public IEnumerator StartSpin()
    {
        SpinButton.interactable = false;
        ClearHighlightList();
        for (int i = 0; i < ReelsList.Count; i++)
        {
            ReelsList[i].ResetReel();
            ReelsList[i].SpinReel();
        }
        yield return new WaitForSeconds(4.5f);
        FindVisibleSymbols();
        CheckMatchingHighlight();
        SpinButton.interactable = true;
    }
    public void CheckMatchingHighlight()
    {
        for (int i = 0; i < HighlightList.Count; i++)
        {
            count = 0;
            List<Image> tempImage = new List<Image>();
            Sprite spriteCurrent = HighlightList[i].myIcon;
            for (int j = 0; j < HighlightList.Count; j++)
            {
                if(spriteCurrent == HighlightList[j].myIcon)
                {
                    tempImage.Add(HighlightList[j].GetComponent<Image>());
                    count++;
                }
            }
            if (count >= 3)
            {
                Debug.Log("Count=" + count);
                for (int k = 0; k < tempImage.Count; k++)
                {
                    tempImage[k].GetComponent<RectTransform>().DOScale(1.5f,0.2f).SetEase(Ease.InOutSine);
                }
            }
            else
            {
                tempImage.Clear();
            }
        }
        for (int i = 0; i < HighlightList.Count; i++)
        {
            if (HighlightList[i].Special == true)
            {
                HighlightList[i].GetRandomNumber();
            }
        }
    }

    public void FindVisibleSymbols()
    {
        for (int i = 0; i < ReelsList.Count; i++)
        {
            for (int j = 0; j < ReelsList[i].List_Symbol.Count; j++)
            {
                if(ReelsList[i].List_Symbol[j].anchoredPosition.y==150 ||
                    ReelsList[i].List_Symbol[j].anchoredPosition.y == 0||
                    ReelsList[i].List_Symbol[j].anchoredPosition.y == -150)
                {
                    //Debug.Log(ReelsList[i].List_Symbol[j].GetComponent<Image>().sprite);
                    HighlightList.Add(ReelsList[i].List_Symbol[j].GetComponent<Symbol>());
                }
            }
        }
    }
    void ClearHighlightList()
    {
        for (int j = 0; j < HighlightList.Count; j++)
        {
            HighlightList[j].GetComponent<RectTransform>().localScale = Vector2.one;
            if (HighlightList[j].Special == true)
            {
                HighlightList[j].Special = false;
                GameObject tempobj = HighlightList[j].gameObject.transform.GetChild(0).gameObject;
                Destroy(tempobj);
            }

        }
        HighlightList.Clear();
    }

}
