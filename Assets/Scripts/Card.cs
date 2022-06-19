using Enums;
using Interfaces;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour,ICard
{

    // 카드 숫자
    byte number;
    public byte Number
    {
        // 카드 숫자 바꾸는 용도. 
        get { return number; }
        set {
            number = value;

            // Front
            var child = transform.GetChild(1);

            // Front-Number_Up.text
            child.GetChild(1).GetComponent<TextMeshProUGUI>().text = number.ToString();

            // Front-Number_Down.text
            child.GetChild(2).GetComponent<TextMeshProUGUI>().text = number.ToString();
        }
    }
    // 카드 문양
    public CardSymbol symbol;



    public void Init(byte number, CardSymbol symbol, List<ICard> deck=null)
    {       
        // prefab 을 받아와서 해당 프리펩으로 오브젝트 생성
        // 숫자와 문양 지정
        // 덱에 저장


        Number = number;
        this.symbol = symbol;


        if(deck!=null)
            deck.Add(this);

    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
    //public void Delete()
    //{
    //    // 카드 제거
    //    Destroy(obj);


    //}
}




