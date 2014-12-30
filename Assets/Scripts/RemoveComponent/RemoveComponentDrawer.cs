using UnityEngine;
using UnityEditor;
using System.Collections;

/*===============================================================*/
/**
* コンポーネントの削除プロパティの表示クラス
* 2014年12月30日 Buravo
*/ 
[CustomPropertyDrawer( typeof ( RemoveComponentAttribute ) )]
public class RemoveComponentDrawer : PropertyDrawer
{
    /*===============================================================*/
    /**
    * @brief GUI表示処理
    */
    public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType == SerializedPropertyType.Boolean)
        {
            property.boolValue = EditorGUI.Toggle(position, label, property.boolValue);
            if (property.boolValue)
            {
                // コンポーネントの削除.
                Object.DestroyImmediate(property.serializedObject.targetObject);
                // Unity4.6以降だと存在しないGUI閉じるメソッド.4.6で代わりのものが必要か要検証.
                EditorGUIUtility.ExitGUI();
            }
        }
    }
    /*===============================================================*/
}
/*===============================================================*/