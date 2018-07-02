using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject Item;
    public GameObject content;

    public Transform graph;
    public GameObject plate;

    private int[] sizeList;
    
    // Use this for initialization

    void Start () {

        // システム日付
        System.DateTime sysDate = System.DateTime.Now;

        // 一覧リスト表示
        SqliteDatabase sqlDB = new SqliteDatabase("CloudKura.db");
        string sql = "select * from Item";
        DataTable dt = sqlDB.ExecuteQuery(sql);
        foreach(DataRow dr in dt.Rows){
            // 残り日数
            System.DateTime dtLimit; 
            string limitDay = "";
            if (System.DateTime.TryParse(dr["LimitDt"].ToString(), out dtLimit)){
                System.TimeSpan ts = dtLimit - sysDate; 
                limitDay = ts.Days.ToString("#,##0");
            }
            Item.transform.Find("LimitDay").GetComponent<Text>().text = limitDay;
            // 個数
            Item.transform.Find("ItemCount").GetComponent<Text>().text = dr["ItemCount"].ToString();
            
            var instance = Instantiate(Item);
            instance.transform.SetParent(content.transform, false);
        }

        // グラフ表示
        // 既に作成したグラフがあれば削除する
        foreach (Transform tran in graph)
        {
            if (tran.name != "Plate") Destroy(tran.gameObject);
        }

        int kindCount = 3;  // 最大の色の数
        sizeList = new int[kindCount];       // 割合のリスト
        int max = 100;                      // グラフの比率 100が最大　ここからどんどん引いていく
        for (int i = 0; i < kindCount; i++)
        {
            if (max <= 0) break;
            // Plateをコピーしてサイズなどを調節
            GameObject plateCopy = Instantiate(plate) as GameObject;
            plateCopy.transform.SetParent(graph);
            plateCopy.transform.localPosition = Vector3.zero;
            plateCopy.transform.localScale = Vector3.one;

            // 最後の１つの場合は残りの全てをあてはめる
            if (i == kindCount - 1)
                sizeList[i] = max;
            else
            {
                // あまりに大きいのと小さいのはいやだったのでちょっといじいじ
                int no = max;
                if (max > 40) no = 40;

                if (max < 10)
                    no = max;
                else
                {
                    sizeList[i] = Random.Range(1, no + 1);
                    if (max - sizeList[i] < 10) sizeList[i] = max;
                }
            }
            // zの角度を設定
            plateCopy.transform.localEulerAngles = new Vector3(0, 0, (100f - (float)max) / 100f * -360f);

            // 円のサイズをfillAmountに設定
            plateCopy.GetComponent<Image>().fillAmount = (float)sizeList[i] / 100f;

            // 色をランダムに設定 明るめにしてます
            plateCopy.GetComponent<Image>().color = new Vector4(Random.Range(0.6f, 1f), Random.Range(0.6f, 1f), Random.Range(0.6f, 1f), 1); ;
            plateCopy.SetActive(true);
            max -= sizeList[i];

        }
        graph.GetComponent<Image>().fillAmount = 1;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
