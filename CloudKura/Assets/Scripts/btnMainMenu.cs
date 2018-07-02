using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnMainMenu : MonoBehaviour {

    public GameObject mainMenu;
    private Button btnShowMainMenu;

	// Use this for initialization
	void Start () {

		btnShowMainMenu = GameObject.Find("btnMainMenu").GetComponent<Button>();
		// ボタンクリックイベントの追加
		btnShowMainMenu.onClick.AddListener(onClickShowMainMenu);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // メインメニュー表示ボタンをクリックしたときの処理
    public void onClickShowMainMenu()
    {
        mainMenu.SetActive(true);
    }
}
