using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;
using UnityEditor.SceneManagement;

public class YuME_customBrushFunctions : EditorWindow
{
    public static void createCustomBrush()
    {
        GameObject tileParentObject = new GameObject();

        if (YuME_mapEditor.selectedTiles.Count > 0)
        {
            // When creating a custom brush we need to find the lowest Z transform in the selection to become the pivot transform
            GameObject bottomLevelOfSelection = YuME_mapEditor.selectedTiles[0];

            foreach (GameObject checkObjects in YuME_mapEditor.selectedTiles)
            {
                if (checkObjects.transform.position.z < bottomLevelOfSelection.transform.position.z)
                {
                    bottomLevelOfSelection = checkObjects;
                }
            }

            // center the parent object around the lowest block to make sure all the selected brushes are centered around the parent
            tileParentObject.transform.position = bottomLevelOfSelection.transform.position;

            // Build the brush by finding the parent prefab, creating an instance and then setting it to the transform of the original scene prefab
            foreach (GameObject tile in YuME_mapEditor.selectedTiles)
            {
                GameObject newBrushObject = (GameObject)PrefabUtility.InstantiatePrefab(PrefabUtility.GetPrefabParent(tile) as GameObject);

                newBrushObject.transform.position = tile.transform.position;
                newBrushObject.transform.eulerAngles = tile.transform.eulerAngles;
                newBrushObject.transform.localScale = tile.transform.localScale;
                newBrushObject.transform.parent = tileParentObject.transform;
            }

            // reset the parents position so it is zero when dropped in the scene
            tileParentObject.transform.position = Vector3.zero;

            // Add the prefab to the project
            tileParentObject.name = "CustomBrush" + YuTools_Utils.numberOfFilesInFolder(YuME_mapEditor.availableTileSets[YuME_mapEditor.currentTileSetIndex].customBrushDestinationFolder, "*_YuME.prefab") + "_YuME.prefab";
            string destinationPath = YuTools_Utils.getAssetPath(YuME_mapEditor.availableTileSets[YuME_mapEditor.currentTileSetIndex]) + "CustomBrushes/";
            PrefabUtility.CreatePrefab(destinationPath + tileParentObject.name, tileParentObject);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh(); // refesh the asset database to tell unity changes have been made

            // remove our temporary builder object
            DestroyImmediate(tileParentObject);
            YuME_mapEditor.selectedTiles.Clear();

            // reload the custom brushes
            YuME_mapEditor.loadCustomBrushes();
        }
    }

    public static GameObject getPrefabFromCurrentTiles(GameObject source)
    {
        foreach(GameObject tile in YuME_mapEditor.currentTileSetObjects)
        {
            if(tile.name == source.name)
            {
                return tile;
            }
        }

        return null;
    }

    public static void pasteCustomBrush(Vector3 position)
    {
        if (YuME_mapEditor.brushTile != null)
        {
            if (YuME_mapEditor.findTileMapParent())
            {
                Undo.RegisterFullObjectHierarchyUndo(YuME_mapEditor.tileMapParent, "Paint Custom Brush");

                foreach (Transform child in YuME_mapEditor.brushTile.transform)
                {
                    GameObject pasteTile = PrefabUtility.InstantiatePrefab(getPrefabFromCurrentTiles(child.gameObject) as GameObject) as GameObject;
                    if (pasteTile != null)
                    {
                        child.position = normalizePosition(child.position);
                        YuME_tileFunctions.eraseTile(child.position);
                        pasteTile.transform.eulerAngles = child.eulerAngles;
                        pasteTile.transform.position = child.position;
                        pasteTile.transform.localScale = child.transform.lossyScale;
                        pasteTile.transform.parent = YuME_mapEditor.mapLayers[YuME_mapEditor.currentLayer - 1].transform;

                    }
                }

                EditorSceneManager.MarkAllScenesDirty();
            }
        }
    }

    public static void createCopyBrush(bool destroySourceTiles)
    {
        if (YuME_mapEditor.currentBrushType != YuME_mapEditor.brushTypes.copyBrush && YuME_mapEditor.selectedTiles.Count > 0)
        {
            YuME_mapEditor.currentBrushType = YuME_mapEditor.brushTypes.copyBrush;

            if (YuME_mapEditor.brushTile != null)
            {
                DestroyImmediate(YuME_mapEditor.brushTile);
            }

            if (YuME_mapEditor.findTileMapParent())
            {
                Undo.RegisterFullObjectHierarchyUndo(YuME_mapEditor.tileMapParent, "Create Brush");

                YuME_mapEditor.brushTile = new GameObject();
                YuME_mapEditor.brushTile.transform.eulerAngles = new Vector3(0f, YuME_mapEditor.tileRotation, 0f);
                YuME_mapEditor.brushTile.transform.parent = YuME_mapEditor.tileMapParent.transform;
                YuME_mapEditor.brushTile.name = "YuME_brushTile";

                YuME_mapEditor.brushTile.transform.position = YuME_mapEditor.selectedTiles[0].transform.position;

                YuME_mapEditor.tileChildObjects.Clear();

                foreach (GameObject tile in YuME_mapEditor.selectedTiles)
                {
                    GameObject tempTile = (GameObject)PrefabUtility.InstantiatePrefab(PrefabUtility.GetPrefabParent(tile) as GameObject);
                    tempTile.transform.parent = YuME_mapEditor.brushTile.transform;
                    tempTile.transform.position = tile.transform.position;
                    tempTile.transform.eulerAngles = tile.transform.eulerAngles;
                    tempTile.transform.localScale = tile.transform.localScale;

                    YuME_mapEditor.tileChildObjects.Add(tempTile);

                    if (destroySourceTiles)
                    {
                        DestroyImmediate(tile);
                    }
                }

                YuME_mapEditor.selectedTiles.Clear();

                YuME_mapEditor.showWireBrush = false;
            }
        }
    }

    public static void pasteCopyBrush(Vector3 position)
    {
        if (YuME_mapEditor.brushTile != null)
        {
            if (YuME_mapEditor.findTileMapParent())
            {
                Undo.RegisterFullObjectHierarchyUndo(YuME_mapEditor.tileMapParent, "Paint Brush");

                foreach (Transform child in YuME_mapEditor.brushTile.transform)
                {
                    GameObject pasteTile = (GameObject)PrefabUtility.InstantiatePrefab(PrefabUtility.GetPrefabParent(child.gameObject) as GameObject);
                    YuME_tileFunctions.eraseTile(child.position);
                    pasteTile.transform.eulerAngles = child.eulerAngles;
                    pasteTile.transform.position = normalizePosition(child.position);
                    pasteTile.transform.localScale = child.transform.lossyScale;
                    pasteTile.transform.parent = YuME_mapEditor.mapLayers[YuME_mapEditor.currentLayer - 1].transform;
                }

                EditorSceneManager.MarkAllScenesDirty(); 
            }
        }
    }

    static Vector3 normalizePosition(Vector3 position)
    {
        position.x = (float)Math.Round(position.x * 4, MidpointRounding.ToEven) / 4;
        position.y = (float)Math.Round(position.y * 4, MidpointRounding.ToEven) / 4;
        position.z = (float)Math.Round(position.z * 4, MidpointRounding.ToEven) / 4;

        return position;
    }
}
