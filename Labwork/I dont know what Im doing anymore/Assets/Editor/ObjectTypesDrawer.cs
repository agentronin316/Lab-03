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
                Rect breakableRect = new Rect(position.x, position.y + 17, position.width, 15f);
                EditorGUI.PropertyField(breakableRect, breakablePoints);
                break;
            case ObjectType.DAMAGING:
                float offset = position.x;
                Rect damageTypeLableRect = new Rect(offset, position.y + 17, 35f, 15f);
                offset += 35;
                EditorGUI.LabelField(damageTypeLableRect, "Type");

                Rect damageTypeRect = new Rect(offset, position.y + 17, position.width / 3, 15f);
                offset += position.width / 3;
                EditorGUI.PropertyField(damageTypeRect, damageType, GUIContent.none);

                Rect damageAmountLableRect = new Rect(offset, position.y +17, 55f, 15f);
                offset += 55;
                EditorGUI.LabelField(damageAmountLableRect, "Amount");

                Rect damageAmountRect = new Rect(offset, position.y + 17, position.width / 3, 15f);
                EditorGUI.PropertyField(damageAmountRect, damageAmount, GUIContent.none);
                break;
            case ObjectType.HEALING:
                float offseth = 195;
                Rect lableRect = new Rect(position.x, position.y + 17, offseth, 15f);
                EditorGUI.LabelField(lableRect, "This item will heal the player's");

                Rect healthSelect = new Rect(position.x + offseth, position.y + 17, 90f, 15f);
                EditorGUI.PropertyField(healthSelect, healingType, GUIContent.none, true);
                offseth += 90f;
                
                lableRect = new Rect(position.x + offseth, position.y + 17, 35f, 15f);
                EditorGUI.LabelField(lableRect, "by");
                offseth += 35f;

                lableRect = new Rect(position.x + offseth, position.y + 17, 70f, 15f);
                EditorGUI.PropertyField(lableRect, healingAmount, GUIContent.none);
                offseth += 70f;

                lableRect = new Rect(position.x + offseth, position.y + 17, 90f, 15f);
                EditorGUI.LabelField(lableRect, "on");

                lableRect = new Rect(position.x, position.y + 34, 100f, 15f);
                EditorGUI.PropertyField(lableRect, healingPickupType, GUIContent.none, true);

                break;
            case ObjectType.PASSABLE:
                Rect feedback = new Rect(position.x, position.y + 17, position.width, 15f);
                EditorGUI.LabelField(feedback, "There are no settings for a passable object.");
                break;
            case ObjectType.SOLID:
                Rect shouldMove = new Rect(position.x, position.y + 17, position.width, 15f);
                int index = solidMoving.boolValue ? 0 : 1;
                string[] options = new string[] { "Yes", "No" };
                index = EditorGUI.Popup(shouldMove, "Should it move?", index, options);
                solidMoving.boolValue = (index == 0) ? true : false;

                if (solidMoving.boolValue)
                {
                    float offsets = position.x;
                    Rect startRect = new Rect(offsets, position.y + 34, position.width / 2, 15f);
                    offsets += position.width / 2;
                    EditorGUI.LabelField(startRect, "Start Point");

                    startRect = new Rect(offsets, position.y + 34, position.width / 2, 15f);
                    EditorGUI.LabelField(startRect, "End Point");

                    offsets = position.x;
                    startRect = new Rect(offsets, position.y + 51, position.width / 2, 15f);
                    offsets += position.width / 2;
                    EditorGUI.PropertyField(startRect, solidStart, GUIContent.none);

                    startRect = new Rect(offsets, position.y + 51, position.width / 2, 15f);
                    EditorGUI.PropertyField(startRect, solidEnd, GUIContent.none);
                }

                break;

        }

        EditorGUI.EndProperty();
    }
}
