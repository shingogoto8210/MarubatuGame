using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class BlockManager : MonoBehaviour
{
    public int blockNum;

    public Text txtBlock;

    private GameManager gameManager;

    //0はなし、1は〇、2は×
    public int symbolNum;

    public ReactiveProperty<bool> ButtonReactiveProperty = new ReactiveProperty<bool>(false);

    //ボタンの初期設定
    public void SetUpButton(GameManager gameManager)
    {
        Button btnGrid = GetComponent<Button>();

        this.gameManager = gameManager;

        txtBlock.text = "";

        btnGrid.onClick.AddListener(OnClickGrid);

    }

    public void OnClickGrid()
    {
        ButtonReactiveProperty.Value = true;
    }
}
