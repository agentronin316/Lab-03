using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomPropertyDrawer(typeof(ObjectTypes))]
public class ObjectTypesDrawer : PropertyDrawer
{
    ObjectTypes thisObject;

    float extraHeight = 55f;

    int shouldSolidMove = 0;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + extraHeight;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty objectType = property.FindPropertyRelative("type");

        SerializedProperty breakablePoints = property.FindPropertyRelative("breakablePoints");

        SerializedProperty solidMoving = property.FindPropertyRelative("solidMoving");
        SerializedProperty solidStart = property.FindPropertyRelative("solidStart");
        SerializedProperty solidEnd = property.FindPropertyRelative("solidEnd");

        SerializedProperty damageType = property.FindPropertyRelative("damageType");
        SerializedProperty damageAmount = property.FindPropertyRelative("damageAmount");

        SerializedProperty healingType = property.FindPropertyRelative("healingType");
        SerializedProperty healingPickupType = property.FindPropertyRelative("healingPickupType");
        SerializedProperty healingAmount = property.FindPropertyRelative("healingAmount");

        Rect objectTypeDisplay = new Rect(position.x, position.y, position.width, 15f);
        EditorGUI.PropertyField(objectTypeDisplay, objectType, GUIContent.none);
        switch ((ObjectType)objectType.enumValueIndex)
        {
            case ObjectType.BREAKABLE:
                Rect breakableRect = new Rect(position.x, position.y, position.width, 15f);
                EditorGUI.PropertyField(breakableRect, breakablePoints);
                break;
            case ObjectType.DAMAGING:
                float offset = position.x;
                Rect damageTypeLableRect = new Rect(offset, position.y + 17, 35f, 17f);
                offset += 35;
                EditorGUI.LabelField(damageTypeLableRect, "Type");

                Rect damageTypeRect = new Rect(offset, position.y + 17, position.width / 3, 17f);
                offset += position.width / 3;
                EditorGUI.PropertyField(damageTypeRect, damageType, GUIContent.none);

                Rect damageAmountLableRect = new Rect(offset, position.y +17, 55f, 17f);
                offset += 55;
                EditorGUI.LabelField(damageAmountLableRect, "Amount");

                Rect damageAmountRect = new Rect(offset, position.y + 17, position.width / 3, 17f);
                EditorGUI.PropertyField(damageAmountRect, damageAmount, GUIContent.none);
                break;
            case ObjectType.HEALING:
                break;
            case ObjectType.PASSABLE:
                break;
            case ObjectType.SOLID:
                Rect shouldMove = new Rect(position.x, position.y + 17, position.width, 17f);
                int index = solidMoving.boolValue ? 0 : 1;
                string[] options = new string[] { "Yes", "No" };
                index = EditorGUI.Popup(shouldMove, "Should it move?", index, options);
                solidMoving.boolValue = (index == 0) ? true : false;
                break;

        }

        EditorGUI.EndProperty();
    }
}
