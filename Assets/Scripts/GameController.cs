using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using BoardF;

public class GameController : MonoBehaviour {
    const int size = 4;
    Game game;
    public Text TextMoves;
    public Text TextStatus;
    void Awake () {
        game = new Game (size);
    }

    void OnEnable () {
        game.Start (50);
        ShowButtons ();
        TextStatus.text = "";
    }

    public void OnClick () {
        if (game.Solved ())
            return;

        string name = EventSystem.current.currentSelectedGameObject.name;
        int x = int.Parse (name.Substring (0, 1));    
        int y = int.Parse (name.Substring (1, 1));

        game.PressAt (x, y);
        ShowButtons ();
        if (game.Solved ())
            TextStatus.text = "You WIN!";
    }

    void HideButtons () {
        for (int x = 0; x < size; x++)
            for (int y = 0; y < size; y++)
                ShowDigitAt (0, x , y);

        // txtResult.Text - game.moves;                
    }

    void ShowButtons () {
        for (int x = 0; x < size; x++)
            for (int y = 0; y < size; y++)
                ShowDigitAt (game.GetDigitAt (x, y), x , y);

        TextMoves.text = game.moves.ToString ();                
    }

    void ShowDigitAt (int digit, int x, int y) {
        string name = x + "" + y;
        var button = GameObject.Find(name);
        var text = button.GetComponentInChildren<Text>();
        var color = button.GetComponentInChildren<Image>();

        text.text = DecToHex (digit);
        color.color = (digit > 0) ? Color.white : Color.clear;
    }

    string DecToHex (int digit) {
        if (digit == 0) return "";
        if (digit < 10) return digit.ToString();

        return ((char)('A' + digit - 10)).ToString();
    }

    void Update () {
        
    }
}
