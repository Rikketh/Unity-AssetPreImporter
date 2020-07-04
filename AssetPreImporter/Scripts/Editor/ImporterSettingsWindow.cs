using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Rickter.Lavender.Tools.Assets {

    [ExecuteInEditMode]
    public class ImporterSettingsWindow : EditorWindow
    {
        private static readonly int[] MaxTextureSizes =
        {
            32,
            64,
            128,
            256,
            512,
            1024,
            2048,
            4096,
            8192
        };

        private static readonly string[] MaxTextureSizeNames =
        {
            "32",
            "64",
            "128",
            "256",
            "512",
            "1024",
            "2048",
            "4096",
            "8192"
        };

        [MenuItem("Tools/Asset Preprocessor Settings")]
        static void Init()
        {
            ImporterSettingsWindow window = (ImporterSettingsWindow)EditorWindow.GetWindow(typeof(ImporterSettingsWindow), true, "Asset Preprocessor Settings");
            window.Show();
        }

        private void OnGUI()
        {
            GUILayout.Label("Model import settings", EditorStyles.boldLabel);

            ImporterSettings.BlendShapeNormals = (ImporterSettingsEnums.BlendShapeNormalsMode) EditorGUILayout.EnumPopup("BlendShape Normals", ImporterSettings.BlendShapeNormals);


            EditorGUILayout.Space();


            GUILayout.Label("Texture import settings", EditorStyles.boldLabel);

            ImporterSettings.MIPMapsEnabled = EditorGUILayout.Toggle("Generate MIP-maps", ImporterSettings.MIPMapsEnabled);
            if (ImporterSettings.MIPMapsEnabled) {
                EditorGUI.indentLevel++;
                ImporterSettings.StreamingMipmaps = EditorGUILayout.Toggle("Streaming MIP-maps", ImporterSettings.StreamingMipmaps);
                EditorGUI.indentLevel--;
            }

            ImporterSettings.AlphaIsTransparency = EditorGUILayout.Toggle("Alpha is Transparency", ImporterSettings.AlphaIsTransparency);

            ImporterSettings.MaxTextureSize = EditorGUILayout.IntPopup("Texture Size", ImporterSettings.MaxTextureSize, MaxTextureSizeNames, MaxTextureSizes);

            ImporterSettings.TextureCompressionLevel = (ImporterSettingsEnums.TextureCompressionQuality) EditorGUILayout.EnumPopup("Texture Compression", ImporterSettings.TextureCompressionLevel);

            ImporterSettings.UseCrunch = EditorGUILayout.Toggle("Crunch", ImporterSettings.UseCrunch);

            ImporterSettings.NormalizeMaps = EditorGUILayout.Toggle("Switch to Normal Map", ImporterSettings.NormalizeMaps);
            
            if (ImporterSettings.NormalizeMaps) {
                EditorGUILayout.LabelField("Name suffixes (csv, no space)");
                ImporterSettings.NormalizationTargetSuffixes = EditorGUILayout.TextField(ImporterSettings.NormalizationTargetSuffixes, GUILayout.ExpandHeight(true));
            }

            ImporterSettings.LinearizeMaps = EditorGUILayout.Toggle("Linearize maps", ImporterSettings.LinearizeMaps);
            
            if (ImporterSettings.LinearizeMaps) {
                EditorGUILayout.LabelField("Name suffixes (csv, no space)");
                ImporterSettings.LinearizationTargetSuffixes = EditorGUILayout.TextField(ImporterSettings.LinearizationTargetSuffixes, GUILayout.ExpandHeight(true));
            }

            ImporterSettings.SingleColorizeMaps = EditorGUILayout.Toggle("Single Color Maps", ImporterSettings.SingleColorizeMaps);

            if (ImporterSettings.SingleColorizeMaps) {
                ImporterSettings.SingleColorChannel = (ImporterSettingsEnums.SingleColorChannel) EditorGUILayout.EnumPopup("Target Channel", ImporterSettings.SingleColorChannel);

                EditorGUILayout.LabelField("Name suffixes (csv, no space)");
                ImporterSettings.SingleColorTargetSuffixes = EditorGUILayout.TextField(ImporterSettings.SingleColorTargetSuffixes, GUILayout.ExpandHeight(true));
            }

            EditorGUILayout.Space();

            GUILayout.Label("Misc settings", EditorStyles.boldLabel);
            
            // Logging setting
            ImporterSettings.LoggingEnabled = EditorGUILayout.Toggle("Log Actions", ImporterSettings.LoggingEnabled);
        }
    }

}