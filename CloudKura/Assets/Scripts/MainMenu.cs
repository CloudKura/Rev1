using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenu;

    public GameObject addItemCamera;

    private Button btnCloseMainMenu;
    private Button btnAddItem;

    // Use this for initialization
    void Start () {

		btnCloseMainMenu = GameObject.Find("btnMainMenuClose").GetComponent<Button>();
		btnAddItem = GameObject.Find("btnAddItemList").GetComponent<Button>();

		// ボタンクリックイベントの追加
		btnCloseMainMenu.onClick.AddListener(onClickCloseMainMenu);
		btnAddItem.onClick.AddListener(onClickAddItem);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // メインメニュー閉じるボタンをクリックしたときの処理
    public void onClickCloseMainMenu()
    {
        mainMenu.SetActive(false);
    }

    public void onClickAddItem()
    {
        addItemCamera.SetActive(true);
    }

}
