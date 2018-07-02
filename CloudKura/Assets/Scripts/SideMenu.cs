using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideMenu : MonoBehaviour {

    public GameObject sideMenu;

    private Button btnCloseSideMenu;

    // Use this for initialization
    void Start () {
		
		btnCloseSideMenu = GameObject.Find("btnSideMenuClose").GetComponent<Button>();

		// ボタンクリックイベントの追加
		btnCloseSideMenu.onClick.AddListener(onClickCloseSideMenu);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // サイドメニュー閉じるボタンをクリックしたときの処理
    public void onClickCloseSideMenu()
    {
        sideMenu.SetActive(false);
    }
}
