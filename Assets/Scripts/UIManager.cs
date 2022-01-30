using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Ÿ”s‚ÌŒ‹‰Ê•\¦
    public Text txtMyResult, txtOpponentResult;

    [SerializeField]
    private GameManager gameManager;
   

    public void UpdateGrid(int symbol, int blockNum)
    {
        //ƒuƒƒbƒN‚Ì‹L†‚Ìí—Ş‚ğŒˆ’èiZ‚©~‚©j
        gameManager.blockManagersList[blockNum].symbolNum = symbol;

        gameManager.blockManagersList[blockNum].txtBlock.text = symbol == 1 ? "Z" : symbol == 2 ? "~" : "";
    }

    public void UpdateResultDisplay()
    {
        if (gameManager.currentGameState == GameState.Win)
        {
            txtMyResult.text = "Ÿ‚¿";
            txtOpponentResult.text = "•‰‚¯";
        }
        else if (gameManager.currentGameState == GameState.Lose)
        {
            txtMyResult.text = "•‰‚¯";
            txtOpponentResult.text = "Ÿ‚¿";
        }
    }

    public void JudgeDraw()
    {
        if (gameManager.currentGameState == GameState.Play)
        {
            gameManager.currentGameState = GameState.Draw;
            txtMyResult.text = "ˆø‚«•ª‚¯";
            txtOpponentResult.text = "ˆø‚«•ª‚¯";
        }
    }
}
