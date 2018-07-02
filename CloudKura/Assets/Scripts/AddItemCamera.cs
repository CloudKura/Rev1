using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class AddItemCamera : MonoBehaviour {

	public GameObject addItemCamera;
    public RawImage    m_displayUI = null;
    public GameObject addItemDetail;

    private Button btnNext;
    private Button btnShutter;
    private Button btnClose;

	[SerializeField]
    private int     m_width     = 1920;
    [SerializeField]
    private int     m_height    = 1080;
    [SerializeField]
  
    private static WebCamTexture   m_webCamTexture     = null;

    private IEnumerator Start()
    {
		btnNext = GameObject.Find("btnAddItemNext").GetComponent<Button>();
		btnShutter = GameObject.Find("btnShutter").GetComponent<Button>();
        btnClose =  GameObject.Find("btnAddItemClose").GetComponent<Button>();

		// ボタンクリックイベントの追加
		btnNext.onClick.AddListener(onClickAddItemNext);
		btnShutter.onClick.AddListener(onClickShutter);
		btnClose.onClick.AddListener(onClickCloseAddItemCamera);

        if( WebCamTexture.devices.Length == 0 )
        {
            Debug.LogFormat( "カメラのデバイスが無い" );
            yield break;
        }

        yield return Application.RequestUserAuthorization( UserAuthorization.WebCam );
        if( !Application.HasUserAuthorization( UserAuthorization.WebCam ) )
        {
            Debug.LogFormat( "カメラを使うことが許可されていない" );
            yield break;
        }

        // とりあえず最初に取得されたデバイスを使ってテクスチャを作る
        WebCamDevice userCameraDevice = WebCamTexture.devices[ 0 ];
        m_webCamTexture = new WebCamTexture( userCameraDevice.name, m_width, m_height );

        m_displayUI.texture = m_webCamTexture;

        // 撮影開始
        m_webCamTexture.Play();
    }
	
    // 閉じるボタンをクリックしたときの処理
    public void onClickCloseAddItemCamera()
    {
        addItemCamera.SetActive(false);
    }

	// シャッターボタンをクリックしたときの処理
	public void onClickShutter()
	{

		if( AddItemCamera.m_webCamTexture == null )
		{
            Debug.LogFormat( "m_webCamTexture == null" );
			return;
		}

		if( !AddItemCamera.m_webCamTexture.isPlaying )
		{
            Debug.LogFormat( "!m_webCamTexture.isPlaying" );
			return;
		}

		AddItemCamera.m_webCamTexture.Stop();

	}

    // 次へボタンクリック時
    public void onClickAddItemNext()
    {
        addItemCamera.SetActive(false);
        addItemDetail.SetActive(true);
    }
}
