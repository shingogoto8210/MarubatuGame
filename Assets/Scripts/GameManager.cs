using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //ブロックに割り当てた番号０～８
    public int[,] blockNumbers = new int[3, 3];
    //ブロックの中の記号
    public Text[] txtBlocks;

    //勝敗の結果表示
    public Text txtMyResult;
    public Text txtOpponentResult;

    // Start is called before the first frame update
    void Start()
    {
        //すべてのブロックの中身を空にする
        for (int i = 0; i < txtBlocks.Length; i++)
        {
            txtBlocks[i].text = "";
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                blockNumbers[i, j] = 0;
            }
        }
    }

    public void OnClickMyTurn(int number)
    {
        if (JudgeWriting(number))
        {
            Write(1, number);

            OpponentTurn();
        }
    }
    
    void OpponentTurn()
    {
        while (true)
        {
            int number = Random.Range(0, 9);
            if (JudgeWriting(number))
            {
                Write(2, number);

                break;
            }
        }
    }

    void Write(int symbol, int number)
    {
        int i = 0;
        int j = 0;

        if (number == 0)
        {
            i = 0;
            j = 0;
        }
        if (number == 1)
        {
            i = 0;
            j = 1;
        }
        if (number == 2)
        {
            i = 0;
            j = 2;
        }
        if (number == 3)
        {
            i = 1;
            j = 0;
        }
        if (number == 4)
        {
            i = 1;
            j = 1;
        }
        if (number == 5)
        {
            i = 1;
            j = 2;
        }
        if (number == 6)
        {
            i = 2;
            j = 0;
        }
        if (number == 7)
        {
            i = 2;
            j = 1;
        }
        if (number == 8)
        {
            i = 2;
            j = 2;
        }

        blockNumbers[i, j] = symbol;

        if(symbol == 1)
        {
            txtBlocks[number].text = "〇";
        }
        if (symbol == 2)
        {
            txtBlocks[number].text = "×";
        }

        JudgeResult();
    }

    public bool JudgeWriting(int number)
    {
        int i = 0;
        int j = 0;

        if(number == 0)
        {
            i = 0;
            j = 0;
        }
        if(number == 1)
        {
            i = 0;
            j = 1;
        }
        if(number == 2)
        {
            i = 0;
            j = 2;
        }
        if (number == 3)
        {
            i = 1;
            j = 0;
        }
        if (number == 4)
        {
            i = 1;
            j = 1;
        }
        if (number == 5)
        {
            i = 1;
            j = 2;
        }
        if (number == 6)
        {
            i = 2;
            j = 0;
        }
        if (number == 7)
        {
            i = 2;
            j = 1;
        }
        if (number == 8)
        {
            i = 2;
            j = 2;
        }

        if(blockNumbers[i,j] == 0)
        {
            return true;
        }

        return false;

    }

    public void JudgeResult()
    {
        if(blockNumbers[0,0] == 1 && blockNumbers[0, 1] == 1 && blockNumbers[0, 2] == 1)
        {
            Win();
        }
        if (blockNumbers[1, 0] == 1 && blockNumbers[1, 1] == 1 && blockNumbers[1, 2] == 1)
        {
            Win();
        }
        if (blockNumbers[2, 0] == 1 && blockNumbers[2, 1] == 1 && blockNumbers[2, 2] == 1)
        {
            Win();
        }
        if (blockNumbers[0, 0] == 2 && blockNumbers[0, 1] == 2 && blockNumbers[0, 2] == 2)
        {
            Lose();
        }
        if (blockNumbers[1, 0] == 2 && blockNumbers[1, 1] == 2 && blockNumbers[1, 2] == 2)
        {
            Lose();
        }
        if (blockNumbers[2, 0] == 2 && blockNumbers[2, 1] == 2 && blockNumbers[2, 2] == 2)
        {
            Lose();
        }

        if (blockNumbers[0, 0] == 1 && blockNumbers[1, 0] == 1 && blockNumbers[2, 0] == 1)
        {
            Win();
        }
        if (blockNumbers[0, 1] == 1 && blockNumbers[1, 1] == 1 && blockNumbers[2, 1] == 1)
        {
            Win();
        }
        if (blockNumbers[0, 2] == 1 && blockNumbers[1, 2] == 1 && blockNumbers[2, 2] == 1)
        {
            Win();
        }
        if (blockNumbers[0, 0] == 2 && blockNumbers[1, 0] == 2 && blockNumbers[2, 0] == 2)
        {
            Lose();
        }
        if (blockNumbers[0, 1] == 2 && blockNumbers[1, 1] == 2 && blockNumbers[2, 1] == 2)
        {
            Lose();
        }
        if (blockNumbers[0, 2] == 2 && blockNumbers[1, 2] == 2 && blockNumbers[2, 2] == 2)
        {
            Lose();
        }

        if (blockNumbers[0, 0] == 1 && blockNumbers[1, 1] == 1 && blockNumbers[2, 2] == 1)
        {
            Win();
        }
        if (blockNumbers[1, 2] == 1 && blockNumbers[1, 1] == 1 && blockNumbers[2, 1] == 1)
        {
            Win();
        }
        if (blockNumbers[0, 0] == 2 && blockNumbers[1, 1] == 2 && blockNumbers[2, 2] == 2)
        {
            Lose();
        }
        if (blockNumbers[1, 2] == 2 && blockNumbers[1, 1] == 2 && blockNumbers[2, 1] == 2)
        {
            Lose();
        }

    }

    public void Win()
    {
        txtMyResult.text = "勝ち";
        txtOpponentResult.text = "負け";
    }
    
    public void Lose()
    {
        txtMyResult.text = "負け";
        txtOpponentResult.text = "勝ち";
    }
}
