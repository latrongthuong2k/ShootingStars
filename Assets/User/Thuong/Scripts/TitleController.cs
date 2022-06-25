using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    [SerializeField] Image _cursor;
    [SerializeField] GameObject[] _titleText;
    [SerializeField] float _cursorLength = -600;
    private int _selectNum = 0;
    Vector2 vec = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        vec = _titleText[0].transform.position;
        vec += new Vector2(_cursorLength, 0);
        _cursor.transform.position = vec;

        //X軸を加算させる
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    _selectNum--;
        //    SelectText();
        //}
        //else if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    _selectNum++;
        //    SelectText();
        //}
         if (Input.GetKeyDown(KeyCode.X))
        {
            SceneChange();
        }
    }

    private void SelectText()
    {
        if (_selectNum >= _titleText.Length)
        {
            _selectNum = _titleText.Length - 1;
        }
        else if (_selectNum <= 0)
        {
            _selectNum = 0;
        }

        vec = _titleText[_selectNum].transform.position;
        vec += new Vector2(_cursorLength, 0);
        _cursor.transform.position = vec;
    }

    private void SceneChange()
    {
        // 選択しているモードに応じて遷移
        if (_selectNum == 0)
        {
            FadeContoller.Instance.LoadScene(0.2f, GameScene.Game);
        }
        // おわるが選ばれているときは終了
        else if (_selectNum == 1)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
        }
    }
}