using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "pageData", menuName = "Datas/PageData")]
public class PageData : ScriptableObject
{
    [TextArea]
    public string content;
}
