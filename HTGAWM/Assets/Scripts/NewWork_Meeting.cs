
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Text;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;
using agora_gaming_rtc;

namespace Project
{
public class NewWork_Meeting : MonoBehaviour
{

    // 자기 자신을 instance로 선언
	public static NewWork_Meeting instance;
    //  ':' 로 분리할 것
	static private readonly char[] Delimiter = new char[] {':'};
    
    Text RoleDesc;
    Text StoryName;
    Text StoryDesc;


    [Header("오브젝트 :")]
    public GameObject btn_exitMeeting;

    // Start is called before the first frame update
    void Start()
    {
        // 싱글 톤 코드
        if (instance == null) {
		    // 
            
		} else {
			//it destroys the class if already other class exists
			Destroy(this.gameObject);
		}

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void emitExitMeeting(){
        Debug.Log("[system] 미팅에서 나갑니다. ");
        btn_exitMeeting.SetActive(false);
        
        // 키 밸류 데이터 
		Dictionary<string, string> data = new Dictionary<string, string>();
		// 보낼 정보 저장
		data["callback_name"] = "exit_meeting";
        data["name"] = Client.name;

        // JSON으로 묶어서 보냄 
		Application.ExternalCall("socket.emit", data["callback_name"], new JSONObject(data));
		// server.js : exit_meeting 호출
    }

    public void onExitMeeting(){
        Debug.Log("[system] 게임으로 갑니다. ");
        SceneManager.LoadScene("Map", LoadSceneMode.Single);
    }

}
}

