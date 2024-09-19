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
        dialogTexts.Add(new DialogData("��Ȳ����: �䳢��, �� �� �ص� ���� ���Ҵ�.", "Rabbit"));

        //dialogTexts.Add(new DialogData("I am Sa. Popped out to let you know Asset can show other characters.", "Sa"));
        dialogTexts.Add(new DialogData("��Ȳ����: ���п� �蹦���� ������ ���� �� �־���.", "Rabbit"));

        //dialogTexts.Add(new DialogData("This Asset, The D'Dialog System has many features.", "Li"));
        dialogTexts.Add(new DialogData("��Ȳ����: ���� �� ���� �� ������, ���� ������ ������ �����.", "Rabbit"));

        //dialogTexts.Add(new DialogData("You can easily change text /color:red/color, /color:white/and /size:up//size:up/size/size:init/ like this.", "Li", () => Show_Example(0)));
        dialogTexts.Add(new DialogData("�䳢: �����մϴ�, ��Ȳ������!", "Rabbit"));

        DialogManager.Show(dialogTexts);
    }
}
