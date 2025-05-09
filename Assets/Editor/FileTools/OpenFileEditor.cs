/*
* ┌──────────────────────────────────┐
* │  描    述: OpenFileEditor                      
* │  类    名: 快速打开文件夹.cs       
* │  创    建: By 4463fger                     
* └──────────────────────────────────┘
*/

using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class OpenFileEditor
    {
        [MenuItem("工具/文件夹工具/01.OpenPersistentDataPath")]
        static void OpenPersistentDataPath()
        {
            string path = Application.persistentDataPath.Replace("/", "\\");
            System.Diagnostics.Process.Start("explorer.exe",path);
        }
    }
}