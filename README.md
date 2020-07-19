# Unity Asset Preprocessor
A tool for your unity project to automate texture and model imports and related settings.

![Preview](https://i.imgur.com/A0noT3d.png)

## Features
Here's what the script can set up for the asset every time you import a model or a texture.

#### Models:
 * BlendShape normals
 * Tangent calculation/import algorithm
 * Camera imports
 * Quad retention

#### Textures:
 * MIP-maps generation
   * MIP-map streaming
 * AlphaTransparency flagging
 * Default texture size
 * Default texture compression
 * Crunch compression
 * Set texture to Normal Map type based on suffix input
 * Linearize colours based on suffix input (disables sRGB option)
 * Set texture to Single Channel type with selectable target channel based on suffix input

## Installation
Simply [grab the latest release](https://github.com/Rikketh/Unity-AssetPreImporter/releases/latest) or download the repo, then throw `AssetPreImporter` folder somewhere into your project's `Assets` folder. If everything's fine, you should see a new item under the "Tools" dropdown menu at the top of Unity editor called `Asset Preprocessor Settings`.

# Credits
This is a rework of [my soft fork](https://github.com/Rikketh/UnityVRAssetPreImporter) of [Hugo Zink](https://github.com/HugoZink)'s [UnityVRAssetImporter](https://github.com/HugoZink/UnityVRAssetPreImporter), thus obligatory links to precursors.