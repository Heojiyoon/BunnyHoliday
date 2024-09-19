using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Doublsb.Dialog;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    public DialogManager DialogManager;

    private void Awake()
    {

        var dialogTexts = new List<DialogData>();

        //dialogTexts.Add(new DialogData("/size:up/Hi, /size:init/my name is Li.", "Li"));
        dialogTexts.Add(new DialogData("옥황상제: 토끼야, 올 한 해도 수고 많았다.", "Rabbit"));

        //dialogTexts.Add(new DialogData("I am Sa. Popped out to let you know Asset can show other characters.", "Sa"));
        dialogTexts.Add(new DialogData("옥황상제: 덕분에 계묘년을 무사히 보낼 수 있었어.", "Rabbit"));

        //dialogTexts.Add(new DialogData("This Asset, The D'Dialog System has many features.", "Li"));
        dialogTexts.Add(new DialogData("옥황상제: 너의 할 일을 다 했으니, 이제 육지로 내려가 쉬어라.", "Rabbit"));

        //dialogTexts.Add(new DialogData("You can easily change text /color:red/color, /color:white/and /size:up//size:up/size/size:init/ like this.", "Li", () => Show_Example(0)));
        dialogTexts.Add(new DialogData("토끼: 감사합니다, 옥황상제님!", "Rabbit"));

        DialogManager.Show(dialogTexts);
    }
}
