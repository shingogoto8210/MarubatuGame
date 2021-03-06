using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //勝敗の結果表示
    public Text txtMyResult, txtOpponentResult;

    [SerializeField]
    private GameManager gameManager;
   

    public void UpdateGrid(int symbol, int blockNum)
    {
        //ブロックの記号の種類を決定（〇か×か）
        gameManager.blockManagersList[blockNum].symbolNum = symbol;

        gameManager.blockManagersList[blockNum].txtBlock.text = symbol == 1 ? "〇" : symbol == 2 ? "×" : "";
    }

    public void UpdateResultDisplay()
    {
        if (gameManager.currentGameState == GameState.Win)
        {
            txtMyResult.text = "勝ち";
            txtOpponentResult.text = "負け";
        }
        else if (gameManager.currentGameState == GameState.Lose)
        {
            txtMyResult.text = "負け";
            txtOpponentResult.text = "勝ち";
        }
    }

    public void JudgeDraw()
    {
        if (gameManager.currentGameState == GameState.Play)
        {
            gameManager.currentGameState = GameState.Draw;
            txtMyResult.text = "引き分け";
            txtOpponentResult.text = "引き分け";
        }
    }
}
