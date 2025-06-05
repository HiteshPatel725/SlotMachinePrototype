using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Symbol : MonoBehaviour
{
    public Sprite myIcon;
    public bool Special;
    public void GetRandomNumber()
    {
        GameObject Temp= Instantiate(Resources.Load("Text_Number"),this.transform) as GameObject;
        Temp.transform.localScale = Vector2.zero;
        Temp.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = Random.Range(150, 301).ToString();
        Temp.transform.DOScale(1,0.5f);
    }

}
