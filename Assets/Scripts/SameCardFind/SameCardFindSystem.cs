using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SameCardFindSystem : MonoBehaviour
{
    public int x, y;
    int positionx;
    int positiony;
    public GameObject Select;
    public SameCardFind Cards;
    int count;
    List<bool> FrontCard;
    List<GameObject> temp;
    int[] save;
    bool stop;
    public void Start()
    {
        x = 0; y = 0; count = 0;
        temp = new List<GameObject>();
        FrontCard = new List<bool>();
        save = new int[2];
        stop = false;
        CreateList();
    }
    public void Update()
    {
        move();
        objectmove();
        if (Input.GetKeyDown(KeyCode.Return) && !stop) 
        { 
            CardMove(); 
        }
    }
    void CreateList()
    {
        for(int i = 0; i < 24; i++)
        {
            FrontCard.Add(false);
        }
    }
    void CardMove()
    {
        int num = x + y * 6;
        if (!FrontCard[num])
        {
            Cards.CardList[num].transform.rotation = Quaternion.Euler(0, 0, 0);
            FrontCard[num] = true;
            save[count] = num;
            temp.Add(Cards.CardList[num]);
            count++;
            if (count > 1)
            {
                stop = true;
                Check();
                count = 0;
            }
        }
    }
    void Check()
    {
        if (!temp[0].name.Equals(temp[1].name))
        {
            Invoke("CardBehind", 1);
            FrontCard[save[0]] = false;
            FrontCard[save[1]] = false;
        }
        Invoke("Clear", 1);
        Invoke("AllFront", 1);
    }
    void CardBehind()
    {
        temp[0].transform.rotation = Quaternion.Euler(0, 180, 0);
        temp[1].transform.rotation = Quaternion.Euler(0, 180, 0);
        
    }
    void AllFront()
    {
        foreach(var i in FrontCard)
        {
            if (!i) return;
        }
        Scenemove();
    }
    void Scenemove()
    {
        SceneManager.LoadScene("Clear");
    }
    void Clear()
    {
        temp.Clear();
        stop = false;
    }
    void move()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && y > 0) y -= 1;
        if (Input.GetKeyDown(KeyCode.DownArrow) && y < 3) y += 1;
        if (Input.GetKeyDown(KeyCode.LeftArrow) && x > 0) x -= 1;
        if (Input.GetKeyDown(KeyCode.RightArrow) && x < 5) x += 1;
    }
    void objectmove()
    {
        positionx = -250 + x*100;
        positiony = 150 - y * 100;
        Select.transform.position = new Vector3(positionx, positiony, 400);
    }
}
