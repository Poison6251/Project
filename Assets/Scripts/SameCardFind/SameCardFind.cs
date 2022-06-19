using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SameCardFind : MonoBehaviour
{
    public List<GameObject> CardList;

    public void Awake()
    {
        Shupple();
        position();
    }
    void Shupple()
    {
        for (int num = 0; num < 5; num++)
        {
            HinduShupple();
            MashShupple();
        }
    }
    void HinduShupple()
    {

        List<GameObject> ShuppleDeck = new List<GameObject>();

        int CardNum = CardList.Count;

        int RandomIndex = Random.Range(0, CardNum - 11);

        int RandomNum = Random.Range(10, CardNum - RandomIndex - 1);

        ShuppleDeck = CardList.GetRange(RandomIndex, RandomNum);

        // 카드를 꺼냈으니 덱에서 제거
        CardList.RemoveRange(RandomIndex, RandomNum);

        // 꺼낸 카드를 다시 제일 뒤로 추가
        CardList.AddRange(ShuppleDeck);
    }

    void MashShupple()
    {
        // 임시로 빠져 나온 카드 2덩어리를 저장하는 리스트 생성
        List<GameObject> ShuppleDeck1 = new List<GameObject>();
        List<GameObject> ShuppleDeck2 = new List<GameObject>();

        // 셔플 할 덱의 카드 갯수를 입력받음
        int CardNum = CardList.Count;

        //반 나눠서 1과 2에 저장
        ShuppleDeck1 = CardList.GetRange(0, CardNum / 2);
        ShuppleDeck2 = CardList.GetRange(CardNum / 2, CardNum - CardNum / 2);

        // 홀수 인지 아닌지 구분(홀수 일경우 1장이 남게 됨)
        if (CardNum % 2 == 1)
        {
            // 마지막 1장을 따로 저장후
            GameObject another = CardList[CardNum - 1];
            // 카드 정보를 다 지우고
            CardList.RemoveAll(x => true);
            // 1과 2에서 1장씩 배분
            for (int re = 0; re < CardNum / 2; re++)
            {
                CardList.Add(ShuppleDeck1[re]);
                CardList.Add(ShuppleDeck2[re]);
            }
            // 마지막 1장을 대입
            CardList.Add(another);
        }
        else
        {
            // 카드 정보를 다 지우고
            CardList.RemoveAll(x => true);
            // 1과 2에서 1장씩 배분
            for (int re = 0; re < CardNum / 2; re++)
            {
                CardList.Add(ShuppleDeck2[re]);
                CardList.Add(ShuppleDeck1[re]);
            }
        }
    }
    void position()
    {
        for (int i = 0; i < CardList.Count; i++)
        {
            int positionx = -250 + (i%6) * 100;
            int positiony = 150 - (i / 6) * 100;
            CardList[i].transform.position = new Vector3(positionx, positiony, 400);
        }
        foreach(var i in CardList)
        {
            i.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
