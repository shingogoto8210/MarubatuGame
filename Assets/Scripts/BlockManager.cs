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

    //0�͂Ȃ��A1�́Z�A2�́~
    public int symbolNum;

    public ReactiveProperty<bool> ButtonReactiveProperty = new ReactiveProperty<bool>(false);

    //�{�^���̏����ݒ�
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
