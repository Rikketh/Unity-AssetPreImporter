using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.IO;
using System.Linq;

namespace Rickter.Lavender.Tools.Assets {

    public class ImportPreProcessor : AssetPostprocessor
    {
        void OnPreprocessModel()
        {
            // Check if this is the first import. If not, skip.
            if(!assetImporter.importSettingsMissing)
            {
                return;
            }

            if (ImporterSettings.BlendShapeNormals == ImporterSettingsEnums.BlendShapeNormalsMode.Default)
            {
                // Default settings selected, don't do anything
                return;
            }

            LogAction("First import of a model, changing import settings.");

            ModelImporter modelImporter = assetImporter as ModelImporter;

            if (ImporterSettings.BlendShapeNormals == ImporterSettingsEnums.BlendShapeNormalsMode.Import)
            {
                // Enable import blendshape normals automatically
                modelImporter.importBlendShapeNormals = ModelImporterNormals.Import;
            }
            else if (ImporterSettings.BlendShapeNormals == ImporterSettingsEnums.BlendShapeNormalsMode.None)
            {
                // Disable blendshape normals automatically
                modelImporter.importBlendShapeNormals = ModelImporterNormals.None;
            }
            else
            {
                // Set "legacy blend shapes" enabled automatically
                PropertyInfo legacyBlendShapeNormalsEnabled = modelImporter.GetType().GetProperty("legacyComputeAllNormalsFromSmoothingGroupsWhenMeshHasBlendShapes", BindingFlags.NonPublic | BindingFlags.Instance);
                legacyBlendShapeNormalsEnabled.SetValue(modelImporter, true);
            }
        }

        void OnPreprocessTexture()
        {
            // Check if this is the first import. If not, skip.
            if(!assetImporter.importSettingsMissing)
            {
                return;
            }

            LogAction("First import of a texture, changing import settings.");

            TextureImporter textureImporter = assetImporter as TextureImporter;

            // unity is fucking retarded:
            // https://forum.unity.com/threads/case-1240367-changing-textureimporter-texturetype-resets-textureimporter-mipmapenabled-silently.873478/

            if (ImporterSettings.NormalizeMaps) {
                string[] tokens = ImporterSettings.NormalizationTargetSuffixes.Split(',');
                if (tokens.Any(x => Path.GetFileNameWithoutExtension(textureImporter.assetPath).EndsWith(x))) {
                    LogAction("Texture " + Path.GetFileName(textureImporter.assetPath) + " matches normal map filters, applying...");
                    textureImporter.textureType = TextureImporterType.NormalMap;
                }
            }

            if (ImporterSettings.SingleColorizeMaps) {
                string[] tokens = ImporterSettings.SingleColorTargetSuffixes.Split(',');
                if (tokens.Any(x => Path.GetFileNameWithoutExtension(textureImporter.assetPath).EndsWith(x))) {
                    LogAction("Texture " + Path.GetFileName(textureImporter.assetPath) + " matches color filters, applying...");

                    textureImporter.textureType = TextureImporterType.SingleChannel;

                    TextureImporterSettings tis = new TextureImporterSettings();
                    textureImporter.ReadTextureSettings(tis);
                    tis.singleChannelComponent = (TextureImporterSingleChannelComponent) ImporterSettings.SingleColorChannel;
                    textureImporter.SetTextureSettings(tis);
                }
            }

            textureImporter.mipmapEnabled = ImporterSettings.MIPMapsEnabled;
            if (ImporterSettings.MIPMapsEnabled) {
                textureImporter.streamingMipmaps = ImporterSettings.StreamingMipmaps;
            }

            // Set max size
            textureImporter.maxTextureSize = ImporterSettings.MaxTextureSize;

            // Set alpha is transparency setting
            textureImporter.alphaIsTransparency = ImporterSettings.AlphaIsTransparency;

            // Set compression quality
            textureImporter.textureCompression = (TextureImporterCompression) ImporterSettings.TextureCompressionLevel;

            textureImporter.crunchedCompression = ImporterSettings.UseCrunch;

            if (ImporterSettings.LinearizeMaps) {
                string[] tokens = ImporterSettings.LinearizationTargetSuffixes.Split(',');
                if (tokens.Any(x => Path.GetFileNameWithoutExtension(textureImporter.assetPath).EndsWith(x))) {
                    LogAction("Texture " + Path.GetFileName(textureImporter.assetPath) + " matches linearization filters, applying...");
                textureImporter.sRGBTexture = false;
                }
            }
        }

        private void LogAction(string msg)
        {
            if(ImporterSettings.LoggingEnabled)
            {
                Debug.Log("[ImportPreProcessor] " + msg, assetImporter);
            }
        }
    }
}
