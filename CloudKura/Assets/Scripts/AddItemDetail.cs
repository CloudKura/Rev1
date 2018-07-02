using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AddItemDetail : MonoBehaviour {

	public GameObject addItem;
    public GameObject addItemDetail;
	public GameObject MainMenu;

	private InputField itemName;
	private Button btnExec;
	private Button btnReturn;
	private Button btnClose;

	// Use this for initialization
	void Start () {
		itemName = GameObject.Find("txtItemName").GetComponent<InputField>();
		btnExec = GameObject.Find("btnAddItemExec").GetComponent<Button>();
		btnReturn = GameObject.Find("btnAddItemReturn").GetComponent<Button>();
		btnClose = GameObject.Find("btnAddItemDetailClose").GetComponent<Button>();

		// // ドロップダウンリストの設定
		// drpYYYY.options.Clear();
		// for (int i = 2000; i <= 2100; i++){
		// 	drpYYYY.options.Add(new Dropdown.OptionData { text = i.ToString() });
		// }
		// drpYYYY.RefreshShownValue();

		// ボタンクリックイベントの追加
		btnExec.onClick.AddListener(onClickAddItemExec);
		btnReturn.onClick.AddListener(onClickAddItemReturn);
		btnClose.onClick.AddListener(onClickCloseAddItemDetail);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // 戻るボタンクリック時
    public void onClickAddItemReturn()
    {
        addItemDetail.SetActive(false);
        addItem.SetActive(true);
    }

	// 登録ボタンクリック時
	public void onClickAddItemExec()
    {
		
		Debug.LogFormat( "memo..." + itemName.text);

		// SqliteDatabase sqlDB = new SqliteDatabase("CloudKura.db");
        // string sql = "insert into Item("
		//            + "ItemId, LimitDt, ItemCount, Memo"
		// 		   + ") values ("
		// 		   + "(select max(ItemId) + 1 from Item)"
		// 		   + ",'2020/12/01',1,''"
		// 		   + ")";
		// sqlDB.ExecuteQuery(sql);
		
        addItemDetail.SetActive(false);
        addItem.SetActive(false);
		MainMenu.SetActive(false);
    }

	// 閉じるボタンクリック時	
	public void onClickCloseAddItemDetail(){
        addItemDetail.SetActive(false);
        addItem.SetActive(false);
		MainMenu.SetActive(false);
	}
}
