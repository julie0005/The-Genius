using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DrawCards : MonoBehaviour
{ 
    public GameObject Card; // 플레이어 진영 카드 앞면 
    public GameObject EnemyCard; //적 진영 보이는 것.
    public GameObject PlayerArea;
    public GameObject EnemyArea;
    private List<int> EnemyInfo = new List<int>(new int[] { 0,1,0,1,0,1,0,1,0});
    // 적의 카드 배치를 나타냄. 0이면 흑, 1이면 백. 임의의 배열로 초기화. 
    // 네트워크 통신 시 0,1 정보를 받아내면 될듯.
    private string white;
    private string black;
    
    Sprite Zero, One, Two, Three, Four, Five, Six, Seven, Eight;
   
    void Awake()
    {
        Zero = Resources.Load<Sprite>("숫자/흑과백 0");
        One = Resources.Load<Sprite>("숫자/흑과백 1");
        Two = Resources.Load<Sprite>("숫자/흑과백 2");
        Three = Resources.Load<Sprite>("숫자/흑과백 3");
        Four = Resources.Load<Sprite>("숫자/흑과백 4");
        Five = Resources.Load<Sprite>("숫자/흑과백 5");
        Six = Resources.Load<Sprite>("숫자/흑과백 6");
        Seven = Resources.Load<Sprite>("숫자/흑과백 7");
        Eight = Resources.Load<Sprite>("숫자/흑과백 8");

        white = "#F1F1F1FF";
        black = "#292929FF";

    }

    //GameObject playerCard = Instantiate(Card2, new Vector3(0, 0, 0), Quaternion.identity);
    //playerCard.transform.SetParent(PlayerArea.transform, false);

    public void Draw()
    {   Image CardImage;
        Color color;
        for(int i=0; i<9; i++)
        {
            GameObject playerCard = Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);
            CardImage = playerCard.GetComponent<Image>();
            CardImage.sprite = Decide(i);
            playerCard.transform.SetParent(PlayerArea.transform, false);
            //player 진영 카드

            GameObject enemyCard = Instantiate(EnemyCard, new Vector3(0, 0, 0), Quaternion.identity);
            CardImage = enemyCard.GetComponent<Image>();
            if (EnemyInfo[i] % 2 == 0) ColorUtility.TryParseHtmlString(black, out color);
            else { ColorUtility.TryParseHtmlString(white, out color); }
            CardImage.color = color;
            enemyCard.transform.SetParent(EnemyArea.transform, false);
            //적 진영 카드 draw.

        }
       

    }

    private Sprite Decide(int i)
    {
        switch (i)
        {
            case 0: return Zero;
                
            case 1: return One;
               
            case 2: return Two;
                
            case 3: return Three;
               
            case 4: return Four;
               
            case 5: return Five;
               
            case 6: return Six;
                
            case 7: return Seven;
              
            case 8: return Eight;

            default: return null;

        }

    }
}
