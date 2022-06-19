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

        // ī�带 �������� ������ ����
        CardList.RemoveRange(RandomIndex, RandomNum);

        // ���� ī�带 �ٽ� ���� �ڷ� �߰�
        CardList.AddRange(ShuppleDeck);
    }

    void MashShupple()
    {
        // �ӽ÷� ���� ���� ī�� 2����� �����ϴ� ����Ʈ ����
        List<GameObject> ShuppleDeck1 = new List<GameObject>();
        List<GameObject> ShuppleDeck2 = new List<GameObject>();

        // ���� �� ���� ī�� ������ �Է¹���
        int CardNum = CardList.Count;

        //�� ������ 1�� 2�� ����
        ShuppleDeck1 = CardList.GetRange(0, CardNum / 2);
        ShuppleDeck2 = CardList.GetRange(CardNum / 2, CardNum - CardNum / 2);

        // Ȧ�� ���� �ƴ��� ����(Ȧ�� �ϰ�� 1���� ���� ��)
        if (CardNum % 2 == 1)
        {
            // ������ 1���� ���� ������
            GameObject another = CardList[CardNum - 1];
            // ī�� ������ �� �����
            CardList.RemoveAll(x => true);
            // 1�� 2���� 1�徿 ���
            for (int re = 0; re < CardNum / 2; re++)
            {
                CardList.Add(ShuppleDeck1[re]);
                CardList.Add(ShuppleDeck2[re]);
            }
            // ������ 1���� ����
            CardList.Add(another);
        }
        else
        {
            // ī�� ������ �� �����
            CardList.RemoveAll(x => true);
            // 1�� 2���� 1�徿 ���
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
