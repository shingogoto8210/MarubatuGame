using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockManager : MonoBehaviour
{
    public int blockNum;

    public Text txtBlock;

    private GameManager gameManager;

    //0はなし、1は〇、2は×
    public int symbolNum;

    //ボタンの初期設定
    public void SetUpButton(GameManager gameManager)
    {
        this.gameManager = gameManager;

        txtBlock.text = "";

    }

    //自分のターン
    public void OnClickMyTurn()
    {
        //そのブロックに何も書かれていないとき
        if (gameManager.JudgeWriting(symbolNum) && gameManager.currentGameState == GameState.Play)
        {
            //ブロックに〇を書く
            gameManager.Write(1,blockNum);

            //相手のターン
            gameManager.OpponentTurn();
        }
    }
}
