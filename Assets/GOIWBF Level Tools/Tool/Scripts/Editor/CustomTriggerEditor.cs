using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditorInternal;
using GOILevelImporter.Core.Components;

[CustomEditor(typeof(CustomTrigger)), CanEditMultipleObjects]
public class CustomTriggerEditor : Editor {

    public SerializedProperty
        TriggerType_Prop,
        Detect_Prop,
        Mode_Prop,
        Destination_Prop,
        Sound_Prop,
        Animation_Prop,
        AnimationClip_Prop,
        Event_Prop,
        TargetProp_Prop;

    private void OnEnable()
    {
        TriggerType_Prop = serializedObject.FindProperty("TriggerType");
        Detect_Prop = serializedObject.FindProperty("Detect");
        Mode_Prop = serializedObject.FindProperty("Mode");
        Destination_Prop = serializedObject.FindProperty("Destination");
        Sound_Prop = serializedObject.FindProperty("Sound");
        Animation_Prop = serializedObject.FindProperty("animation");
        AnimationClip_Prop = serializedObject.FindProperty("anim");
        Event_Prop = serializedObject.FindProperty("TriggerEvent");
        TargetProp_Prop = serializedObject.FindProperty("TargetProp");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(TriggerType_Prop);
        EditorGUILayout.PropertyField(Detect_Prop);

        CustomTrigger.Trigger trigType = (CustomTrigger.Trigger)TriggerType_Prop.enumValueIndex;

        if ((CustomTrigger.DetectMode)Detect_Prop.enumValueIndex == CustomTrigger.DetectMode.SpecificProp)
            EditorGUILayout.PropertyField(TargetProp_Prop, new GUIContent("Target Props"), true);

        switch (trigType)
        {
            case CustomTrigger.Trigger.Teleport:
                EditorGUILayout.PropertyField(Mode_Prop, new GUIContent("Keep momentum"));
                EditorGUILayout.PropertyField(Destination_Prop, new GUIContent("Teleport destination"));
                break;
            case CustomTrigger.Trigger.Playsound:
                EditorGUILayout.PropertyField(Sound_Prop, new GUIContent("Sound"));
                EditorGUILayout.PropertyField(Mode_Prop, new GUIContent("Play once"));
                break;
            case CustomTrigger.Trigger.Animation:
                EditorGUILayout.PropertyField(Animation_Prop, new GUIContent("Animation"));
                EditorGUILayout.PropertyField(AnimationClip_Prop, new GUIContent("Animation Clip"));
                break;
            case CustomTrigger.Trigger.Event:
                EditorGUILayout.PropertyField(Event_Prop, new GUIContent("Event"));
                break;
            case CustomTrigger.Trigger.SwitchScene:
                EditorGUILayout.PropertyField(AnimationClip_Prop, new GUIContent("Scene name"));
                EditorGUILayout.PropertyField(Mode_Prop, new GUIContent("Skip intro animation"));
                break;
        }


        serializedObject.ApplyModifiedProperties();
    }
}
