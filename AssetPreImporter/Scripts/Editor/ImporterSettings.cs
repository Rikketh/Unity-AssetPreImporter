using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Rickter.Lavender.Tools.Assets {

    public static class ImporterSettings
    {
        public static ImporterSettingsEnums.BlendShapeNormalsMode BlendShapeNormals
        {
            get
            {
                string normalMode = EditorPrefs.GetString("PreProcessor_BlendShapeNormalsMode", "legacy");
                switch (normalMode)
                {
                    case "default":
                        return ImporterSettingsEnums.BlendShapeNormalsMode.Default;
                    case "legacy":
                        return ImporterSettingsEnums.BlendShapeNormalsMode.Legacy;
                    case "import":
                        return ImporterSettingsEnums.BlendShapeNormalsMode.Import;
                    case "none":
                        return ImporterSettingsEnums.BlendShapeNormalsMode.None;
                    default:
                        return ImporterSettingsEnums.BlendShapeNormalsMode.Legacy;
                }
            }
            set
            {
                switch (value)
                {
                    case ImporterSettingsEnums.BlendShapeNormalsMode.Default:
                        EditorPrefs.SetString("PreProcessor_BlendShapeNormalsMode", "default");
                        break;
                    case ImporterSettingsEnums.BlendShapeNormalsMode.Legacy:
                        EditorPrefs.SetString("PreProcessor_BlendShapeNormalsMode", "legacy");
                        break;
                    case ImporterSettingsEnums.BlendShapeNormalsMode.Import:
                        EditorPrefs.SetString("PreProcessor_BlendShapeNormalsMode", "import");
                        break;
                    case ImporterSettingsEnums.BlendShapeNormalsMode.None:
                        EditorPrefs.SetString("PreProcessor_BlendShapeNormalsMode", "none");
                        break;
                    default:
                        throw new ArgumentException("Value must be one of default, legacy, import or none");
                }
            }
        }

        public static bool MIPMapsEnabled
        {
            get
            {
                return EditorPrefs.GetBool("PreProcessor_MIPMapsEnabled", true);
            }
            set
            {
                EditorPrefs.SetBool("PreProcessor_MIPMapsEnabled", value);
            }
        }

        public static bool StreamingMipmaps
        {
            get
            {
                return EditorPrefs.GetBool("PreProcessor_StreamingMipmaps", false);
            }
            set
            {
                EditorPrefs.SetBool("PreProcessor_StreamingMipmaps", value);
            }
        }

        public static bool AlphaIsTransparency
        {
            get
            {
                return EditorPrefs.GetBool("PreProcessor_AlphaIsTransparency", false);
            }
            set
            {
                EditorPrefs.SetBool("PreProcessor_AlphaIsTransparency", value);
            }
        }

        public static int MaxTextureSize
        {
            get
            {
                return EditorPrefs.GetInt("PreProcessor_MaxTextureSize", 4096);
            }
            set
            {
                EditorPrefs.SetInt("PreProcessor_MaxTextureSize", value);
            }
        }

        public static ImporterSettingsEnums.TextureCompressionQuality TextureCompressionLevel
        {
            get
            {
                string textureCompression = EditorPrefs.GetString("PreProcessor_TextureCompressionLevel", "normal");
                switch (textureCompression)
                {
                    case "low":
                        return ImporterSettingsEnums.TextureCompressionQuality.Low;
                    case "normal":
                        return ImporterSettingsEnums.TextureCompressionQuality.Normal;
                    case "high":
                        return ImporterSettingsEnums.TextureCompressionQuality.High;
                    case "none":
                        return ImporterSettingsEnums.TextureCompressionQuality.None;
                    default:
                        return ImporterSettingsEnums.TextureCompressionQuality.Normal;
                }
            }
            set
            {
                switch (value)
                {
                    case ImporterSettingsEnums.TextureCompressionQuality.Low:
                        EditorPrefs.SetString("PreProcessor_TextureCompressionLevel", "low");
                        break;
                    case ImporterSettingsEnums.TextureCompressionQuality.Normal:
                        EditorPrefs.SetString("PreProcessor_TextureCompressionLevel", "normal");
                        break;
                    case ImporterSettingsEnums.TextureCompressionQuality.High:
                        EditorPrefs.SetString("PreProcessor_TextureCompressionLevel", "high");
                        break;
                    case ImporterSettingsEnums.TextureCompressionQuality.None:
                        EditorPrefs.SetString("PreProcessor_TextureCompressionLevel", "none");
                        break;
                    default:
                        throw new ArgumentException("Value must be one of low, normal, high or none");
                }
            }
        }

        public static bool UseCrunch
        {
            get
            {
                return EditorPrefs.GetBool("PreProcessor_UseCrunch", false);
            }
            set
            {
                EditorPrefs.SetBool("PreProcessor_UseCrunch", value);
            }
        }

        public static bool NormalizeMaps
        {
            get
            {
                return EditorPrefs.GetBool("PreProcessor_NormalizeMaps", false);
            }
            set
            {
                EditorPrefs.SetBool("PreProcessor_NormalizeMaps", value);
            }
        }

        public static string NormalizationTargetSuffixes
        {
            get
            {
                return EditorPrefs.GetString("PreProcessor_NormalizationTargetSuffixes", "_nm,_norm,_bm,_bump,_normal");
            }
            set
            {
                EditorPrefs.SetString("PreProcessor_NormalizationTargetSuffixes", value);
            }
        }

        public static bool LinearizeMaps
        {
            get
            {
                return EditorPrefs.GetBool("PreProcessor_LinearizeMaps", false);
            }
            set
            {
                EditorPrefs.SetBool("PreProcessor_LinearizeMaps", value);
            }
        }

        public static string LinearizationTargetSuffixes
        {
            get
            {
                return EditorPrefs.GetString("PreProcessor_LinearizationTargetSuffixes", "_rma,_ppc,_mro,_nma,_ao,_sss,_trans,_si,_emis");
            }
            set
            {
                EditorPrefs.SetString("PreProcessor_LinearizationTargetSuffixes", value);
            }
        }

        public static bool SingleColorizeMaps
        {
            get
            {
                return EditorPrefs.GetBool("PreProcessor_SingleColorizeMaps", false);
            }
            set
            {
                EditorPrefs.SetBool("PreProcessor_SingleColorizeMaps", value);
            }
        }

        public static ImporterSettingsEnums.SingleColorChannel SingleColorChannel
        {
            get
            {
                string singleColorChannel = EditorPrefs.GetString("PreProcessor_SingleColorChannel", "red");
                switch (singleColorChannel) {
                    case "red":
                        return ImporterSettingsEnums.SingleColorChannel.Red;
                    case "alpha":
                        return ImporterSettingsEnums.SingleColorChannel.Alpha;
                    default:
                        return ImporterSettingsEnums.SingleColorChannel.Red;
                }
            }
            set
            {
                switch (value) {
                    case ImporterSettingsEnums.SingleColorChannel.Red:
                        EditorPrefs.SetString("PreProcessor_SingleColorChannel", "red");
                    break;
                    case ImporterSettingsEnums.SingleColorChannel.Alpha:
                        EditorPrefs.SetString("PreProcessor_SingleColorChannel", "alpha");
                    break;
                    default:
                        throw new ArgumentException("Value must be one of: alpha or red");
                }
            }
        }

        public static string SingleColorTargetSuffixes
        {
            get
            {
                return EditorPrefs.GetString("PreProcessor_SingleColorTargetSuffixes", "_ao,_trans,_op,_metal,_rough");
            }
            set
            {
                EditorPrefs.SetString("PreProcessor_SingleColorTargetSuffixes", value);
            }
        }

        public static bool LoggingEnabled
        {
            get
            {
                return EditorPrefs.GetBool("PreProcessor_EnableLogging", true);
            }
            set
            {
                EditorPrefs.SetBool("PreProcessor_EnableLogging", value);
            }
        }
    }
}
