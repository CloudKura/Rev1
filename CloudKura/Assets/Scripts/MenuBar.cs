using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuBar : MonoBehaviour {

    public GameObject sideMenu;

	private Button btnShowSideMenu;

	// Use this for initialization
	void Start () {

		btnShowSideMenu = GameObject.Find("btnShowSideMenu").GetComponent<Button>();

		// ボタンクリックイベントの追加
		btnShowSideMenu.onClick.AddListener(onClickShowSideMenu);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // サイドメニュー表示ボタンをクリックしたときの処理
    public void onClickShowSideMenu()
    {
		// サイドメニュー表示
        sideMenu.SetActive(true);
    }

}
