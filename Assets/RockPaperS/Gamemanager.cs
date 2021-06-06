using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    enum elements { Scissor = 1 , Paper , Rock }

    private int pChoose = -1;
    private int bChoose = -1;

    private bool playersTurn = true;

    public GameObject WinnerText;

    public Sprite paperImg, rockImg, scissorImg;
    public GameObject botChooseImg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playersTurn && pChoose == -1) return;
        
        BotChoose();
        CheckWinner();
        pChoose = -1;
        playersTurn = true;
        
    }

    void CheckWinner()
    {
        if(pChoose == bChoose)
        {
            //E
            WinnerText.GetComponent<Text>().text = "平手";
        }
        else if(pChoose == (int)elements.Paper && bChoose == (int)elements.Rock)
        {
            //P W
            WinnerText.GetComponent<Text>().text = "玩家";
        }
        else if (pChoose == (int)elements.Rock && bChoose == (int)elements.Paper)
        {
            //B W
            WinnerText.GetComponent<Text>().text = "對手";
        }
        else if (pChoose == (int)elements.Scissor && bChoose == (int)elements.Rock)
        {
            //B W
            WinnerText.GetComponent<Text>().text = "對手";
        }
        else if (pChoose == (int)elements.Rock && bChoose == (int)elements.Scissor)
        {
            //P W
            WinnerText.GetComponent<Text>().text = "玩家";
        }
        else if (pChoose == (int)elements.Scissor && bChoose == (int)elements.Paper)
        {
            //B W
            WinnerText.GetComponent<Text>().text = "玩家";
        }
        else if (pChoose == (int)elements.Paper && bChoose == (int)elements.Scissor)
        {
            //P W
            WinnerText.GetComponent<Text>().text = "對手";
        }
    }

    public void PlayerChoose(int choose)
    {
        pChoose = choose;
        playersTurn = false;
    }

    public void BotChoose()
    {
        bChoose = Random.Range(1, 4);
        
        if(bChoose == 1)
        {
            botChooseImg.GetComponent<Image>().sprite = scissorImg;
        }
        else if (bChoose == 2)
        {
            botChooseImg.GetComponent<Image>().sprite = paperImg;
        }
        else
        {
            botChooseImg.GetComponent<Image>().sprite = rockImg;
        }
    }
}
