using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [Serializable]
    public class ExportedSOEntry
    {
        public string typeName;
        public string assetPath;
        public string dataJson;
    }
    public class SoExportJson : EditorWindow
    {
        private static readonly JsonSerializerSettings SerializerSettings = new()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented,
            Converters = new List<JsonConverter>(){new UnityTypeConverter()}
        };
        
        [MenuItem("工具/So导出JSON")]
        public static void ExportSelectedSo()
        {
            UnityEngine.Object[] selectedObjects = Selection.objects;

            if (selectedObjects.Length == 0)
            {
                Debug.LogError("请至少选择一个SO");
                return;
            }

            List<ExportedSOEntry> allExportedData = new();
            foreach (var obj in selectedObjects)
            {
                if (obj is SerializedScriptableObject so)
                {
                    ExportedSOEntry entry = new()
                    {
                        typeName = so.GetType().Name,
                        assetPath = AssetDatabase.GetAssetPath(so),
                        dataJson = ExportSoToJson(so),
                    };
                    allExportedData.Add(entry);
                }
            }

            string json = JsonConvert.SerializeObject(allExportedData, SerializerSettings);
            string path = EditorUtility.SaveFilePanel("保存导出的 SO 数据", "", "ExportedSOs.json", "json");

            if (!string.IsNullOrEmpty(path))
            {
                File.WriteAllText(path,json);
                AssetDatabase.Refresh();
                Debug.Log($"SO 数据已导出到：{path}");
            }
        }

        private static string ExportSoToJson(SerializedScriptableObject so)
        {
            Dictionary<string, object> exportedFields = new();
            var fields = so.GetType().GetFields(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fields)
            {
                object value = field.GetValue(so);
                if (value == null) continue;

                // 处理Unity的特殊类型
                exportedFields[field.Name] = ProcessUnityObject(value);
            }

            return JsonConvert.SerializeObject(exportedFields, SerializerSettings);
        }

        private static object ProcessUnityObject(object value)
        {
            return value switch
            {
                Sprite sprite => AssetDatabase.GetAssetPath(sprite),
                Texture2D texture2D => AssetDatabase.GetAssetPath(texture2D),
                UnityEngine.Object unityObj => unityObj.name,
                _ => ConvertComplexType(value)
            };
        }

        private static object ConvertComplexType(object value)
        {
            // 处理集合
            if (value is System.Collections.IEnumerable enumerable && !(value is string))
            {
                var list = new List<object>();
                foreach (var item in enumerable)
                {
                    list.Add(ProcessUnityObject(item));
                }
                return list;
            }

            var type = value.GetType();
            if (type.IsPrimitive || type == typeof(string))
            {
                return value;
            }
            
            // 转化为可序列化字典
            var dict = new Dictionary<string, object>();
            foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                dict[field.Name] = ProcessUnityObject(field.GetValue(value));
            }
            return dict;
        }
    }
}