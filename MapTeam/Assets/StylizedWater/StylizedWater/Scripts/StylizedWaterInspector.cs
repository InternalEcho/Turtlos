// Stylized Water Shader by Staggart Creations http://u3d.as/A2R
// Online documentation can be found at http://staggart.xyz

using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
[CustomEditor(typeof(StylizedWater))]
public class StylizedWaterInspector : Editor
{
    //Meta meta
    private const string version = "1.30";
    private const string documentationURL = "http://staggart.xyz/unity/stylized-water-shader/documentation/";

    //Non serialized, local
    StylizedWater stylizedWater;
    SerializedProperty material;
    SerializedProperty substance;

    new SerializedObject serializedObject;

    string[] shaderNames;
    SerializedProperty shaderIndex;

    #region Shader parameters
    private Shader shader;

    //Colors
    SerializedProperty waterColor;
    SerializedProperty fresnelColor;
    SerializedProperty rimColor;

    //Surface
    SerializedProperty normalStrength;
    SerializedProperty worldSpaceTiling;
    SerializedProperty tiling;
    SerializedProperty transparency;
    SerializedProperty fresnel;
    SerializedProperty glossiness;
    SerializedProperty refractionAmount;

    //Intersection
    SerializedProperty rimSize;
    SerializedProperty rimFalloff;
    SerializedProperty rimDistance;
    SerializedProperty rimTiling;

    //Surface highlights
    SerializedProperty useIntersectionHighlight;
    SerializedProperty surfaceHighlightPanning;
    SerializedProperty surfaceHighlight;
    SerializedProperty surfaceHighlightSize;
    SerializedProperty surfaceHighlightTiling;

    //Depth
    SerializedProperty depth;
    SerializedProperty depthDarkness;

    //Waves
    SerializedProperty waveSpeed;
    SerializedProperty waveStrength;
    SerializedProperty waveTint;
    SerializedProperty waveSize;

    //Other
    SerializedProperty reflection;
    SerializedProperty tessellation;
    #endregion

    #region  Substance parameters
    SerializedProperty seed;
    public string[] intersectionStyleNames;
    public string[] waveStyleList;
    public string[] waveHeightmapList;

    SerializedProperty useCustomIntersection;
    SerializedProperty intersectionStyle;
    SerializedProperty useCustomNormals;
    SerializedProperty waveStyle;
    SerializedProperty waveHeightmapStyle;
    #endregion

    #region Local variables
    //Input textures
    SerializedProperty customIntersection;
    SerializedProperty customNormal;
    SerializedProperty reflectionCubemap;

    GameObject selected;
    public bool isMobileAdvanced;
    public bool isMobileBasic;
    #endregion

    #region Meta
    string shaderName = null;
    SerializedProperty useCompression;

    //Section toggles
    private SerializedProperty showColors;
    private SerializedProperty showSurface;
    private SerializedProperty showIntersection;
    private SerializedProperty showHighlights;
    private SerializedProperty showDepth;
    private SerializedProperty showWaves;
    private SerializedProperty showAdvanced;

    //Help toggles
    private bool showHelp;
    private bool showHelpColors;
    private bool showHelpSurface;
    private bool showHelpIntersection;
    private bool showHelpHighlights;
    private bool showHelpDepth;
    private bool showHelpWaves;
    private bool showHelpAdvanced;

    private SerializedProperty isWaterLayer;
    private SerializedProperty hasShaderParams;
    private Shader currentShader;
#if !UNITY_5_5_OR_NEWER
    private SerializedProperty hideWireframe;
#endif

    private bool isReady = false;

    //Styling
    GUIStyle groupFoldout;
    GUIStyle helpButton;
    GUIStyle collapseButton;
    Texture helpIcon;
    GUIContent helpButtonContent;
    #endregion

    void OnEnable()
    {
        //Prevent OnInspectorGUI from running before these functions have been called
        isReady = false;

        SetStyling();

        selected = Selection.activeGameObject;

        if (!selected) return;

        if (!stylizedWater) stylizedWater = selected.GetComponent<StylizedWater>();

        serializedObject = new SerializedObject(stylizedWater);

        stylizedWater.Init();

        GetProperties();

        isWaterLayer.boolValue = (selected.gameObject.layer == 4) ? true : false;

        EditorUtility.SetDirty(target);

        isReady = true;
    }

    public override void OnInspectorGUI()
    {
        if (!isReady) return;

        //Prevent null values when component is added
        serializedObject.Update();

        EditorGUI.BeginChangeCheck();

        if (stylizedWater.hasMaterial) Undo.RecordObject(material.objectReferenceValue, "Material");

        /*-----------------*/
        DrawAllFields();
        /*-----------------*/

        //Apply values
        if (EditorGUI.EndChangeCheck())
        {

            serializedObject.ApplyModifiedProperties();
            stylizedWater.SetShaderProperties();

            //Changes applied, grab new values
            GetProperties();

            EditorUtility.SetDirty(serializedObject.targetObject);

        }

    }

    //Get shader and Substance values
    void GetProperties()
    {
        //During runtime, nothing may be selected
        if (!selected) return;

        //Get all shader and Substance properties
        stylizedWater.GetProperties();
        hasShaderParams = serializedObject.FindProperty("hasShaderParams");
#if !UNITY_5_5_OR_NEWER
        hideWireframe = serializedObject.FindProperty("hideWireframe");
#endif

        material = serializedObject.FindProperty("material");
        substance = serializedObject.FindProperty("substance");
        shader = stylizedWater.shader;
        shaderIndex = serializedObject.FindProperty("shaderIndex");
        shaderNames = stylizedWater.shaderNames;

        useCompression = serializedObject.FindProperty("useCompression");
        isWaterLayer = serializedObject.FindProperty("isWaterLayer");

        shaderName = stylizedWater.shaderName;

        isMobileAdvanced = stylizedWater.isMobileAdvanced;
        isMobileBasic = stylizedWater.isMobileBasic;

        //Meta
        showColors = serializedObject.FindProperty("showColors");
        showSurface = serializedObject.FindProperty("showSurface");
        showIntersection = serializedObject.FindProperty("showIntersection");
        showHighlights = serializedObject.FindProperty("showHighlights");
        showDepth = serializedObject.FindProperty("showDepth");
        showWaves = serializedObject.FindProperty("showWaves");
        showAdvanced = serializedObject.FindProperty("showAdvanced");

        //If the shader is not an SWS shader, abort
        if (!shaderName.Contains("StylizedWater")) return;

        #region Shader parameters
        waterColor = serializedObject.FindProperty("waterColor");
        fresnelColor = serializedObject.FindProperty("fresnelColor");
        rimColor = serializedObject.FindProperty("rimColor");
        waveTint = serializedObject.FindProperty("waveTint");

        normalStrength = serializedObject.FindProperty("normalStrength");
        transparency = serializedObject.FindProperty("transparency");
        glossiness = serializedObject.FindProperty("glossiness");
        reflectionCubemap = serializedObject.FindProperty("reflectionCubemap");
        fresnel = serializedObject.FindProperty("fresnel");

        useIntersectionHighlight = serializedObject.FindProperty("useIntersectionHighlight");
        surfaceHighlightPanning = serializedObject.FindProperty("surfaceHighlightPanning");
        surfaceHighlight = serializedObject.FindProperty("surfaceHighlight");
        surfaceHighlightSize = serializedObject.FindProperty("surfaceHighlightSize");
        surfaceHighlightTiling = serializedObject.FindProperty("surfaceHighlightTiling");

        depth = serializedObject.FindProperty("depth");
        depthDarkness = serializedObject.FindProperty("depthDarkness");

        rimSize = serializedObject.FindProperty("rimSize");
        rimFalloff = serializedObject.FindProperty("rimFalloff");
        rimDistance = serializedObject.FindProperty("rimDistance");

        worldSpaceTiling = serializedObject.FindProperty("worldSpaceTiling");
        tiling = serializedObject.FindProperty("tiling");
        rimTiling = serializedObject.FindProperty("rimTiling");

        refractionAmount = serializedObject.FindProperty("refractionAmount");

        waveSpeed = serializedObject.FindProperty("waveSpeed");
        waveStrength = serializedObject.FindProperty("waveStrength");
        waveSize = serializedObject.FindProperty("waveSize");

        tessellation = serializedObject.FindProperty("tessellation");

        #endregion

        #region Substance parameters
        seed = serializedObject.FindProperty("seed");

        intersectionStyle = serializedObject.FindProperty("intersectionStyle");
        waveStyle = serializedObject.FindProperty("waveStyle");
        waveHeightmapStyle = serializedObject.FindProperty("waveHeightmapStyle");

        useCustomNormals = serializedObject.FindProperty("useCustomNormals");
        useCustomIntersection = serializedObject.FindProperty("useCustomIntersection");

        //Substance input textures
        customIntersection = serializedObject.FindProperty("customIntersection");
        customNormal = serializedObject.FindProperty("customNormal");

        //Arrays
        intersectionStyleNames = stylizedWater.intersectionStyleNames;
        waveStyleList = stylizedWater.waveStyleNames;
        waveHeightmapList = stylizedWater.waveHeightmapNames;

        #endregion

    }

    private void BakeSubstance()
    {
        stylizedWater.BakeSubstance(useCompression.boolValue);
    }

    //Draw inspector fields
    void DrawAllFields()
    {
        DoHeader();

        if (!stylizedWater.hasMaterial || !shaderName.Contains("StylizedWater"))
        {
            EditorGUILayout.HelpBox("Please assign a material with a \"StylizedWater\" shader to this object.", MessageType.Error);
            return;
        }
        else
        {
            shaderIndex.intValue = EditorGUILayout.Popup("Current shader:", (int)shaderIndex.intValue, shaderNames, new GUILayoutOption[0]);
            if (shader != currentShader)
            {
                //Shader changed, current values of material are unknown
                //Also executed OnEnable
                hasShaderParams.boolValue = false;
                currentShader = shader;
                GetProperties();
            }

            EditorGUILayout.Space();
        }

        if (stylizedWater.isMobilePlatform && shaderName.Contains("Desktop"))
        {
            EditorGUILayout.HelpBox("You are using a desktop shader on a mobile platform, which is not supported.\n\nThis will be automatically corrected.", MessageType.Error);
        }

        DoColors();

        DoSurface();

        DoInterSection();

        DoSurfaceHighlights();

        DoDepth();

        DoWaves();

        DoAdvanced();

        if (substance.objectReferenceValue)
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Apply all settings", GUILayout.MaxHeight(35)))
            {
                BakeSubstance();
            }
            EditorGUILayout.EndHorizontal();
        }


        DoFooter();
    }

    //Fields
    void DoHeader()
    {
        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Stylized Water Shader " + version, new GUIStyle(EditorStyles.centeredGreyMiniLabel)
        {
            alignment = TextAnchor.MiddleLeft,
            wordWrap = true,
            fontSize = 12,
        });
        showHelp = GUILayout.Toggle(showHelp, "Toggle help", "Button");
        EditorGUILayout.EndHorizontal();


        if (showHelp)
        {
            EditorGUILayout.Space();

            if (GUILayout.Button("Open online documentation"))
            {
                Application.OpenURL(documentationURL);
            }
        }

        if (!Application.isMobilePlatform && showHelp)
        {
            EditorGUILayout.HelpBox("The current Shader Forge-based shaders will be deprecated at some point\n\nPlease use the included Desktop Beta shader package, which is updated with new features.", MessageType.Warning);
        }

        if (showHelp) EditorGUILayout.HelpBox("This GUI allows you to customize the water material and bake textures containing an intersection, wave and heightmap style per material\n\nBaked textures are saved in a \"/Textures/\" folder next to the Material file.", MessageType.Info);

        if (showHelp) EditorGUILayout.HelpBox("If the baked textures are black, you must set the \"Format\" to \"RAW\" on the StylizedWater Substance\n\nWith the material selected, you can find this option at the far bottom of the inspector, this should be set by default.", MessageType.Warning);

        EditorGUILayout.Space();

    }

    void DoColors()
    {
        //Head
        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button((showColors.boolValue) ? "-" : "+", collapseButton))
        {
            showColors.boolValue = !showColors.boolValue;
        }
        if (GUILayout.Button("Colors", groupFoldout))
        {
            showColors.boolValue = !showColors.boolValue;
        }
        showHelpColors = GUILayout.Toggle((showColors.boolValue) ? showHelpColors : false, helpIcon, helpButton);
        EditorGUILayout.EndHorizontal();


        //Body
        if (showColors.boolValue)
        {
            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(waterColor, new GUIContent("Water"));
            if (!isMobileBasic)
            {
                EditorGUILayout.PropertyField(fresnelColor, new GUIContent("Fresnel"));
                if (showHelpColors) EditorGUILayout.HelpBox("The color's alpha channel controls the intensity", MessageType.Info);
            }
            EditorGUILayout.PropertyField(rimColor, new GUIContent("Intersection"));
            if (showHelpColors) EditorGUILayout.HelpBox("The color's alpha channel controls the intensity", MessageType.Info);

            if (!isMobileAdvanced && !isMobileBasic)
            {
                EditorGUILayout.PropertyField(waveTint, new GUIContent("Wave tint"));
                if (showHelpColors) EditorGUILayout.HelpBox("Brightens or darkerns the water, based on the chosen heightmap in the Waves options section.", MessageType.Info);

            }

        }

        EditorGUILayout.Space();
    }

    void DoSurface()
    {
        //Head
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button((showSurface.boolValue) ? "-" : "+", collapseButton))
        {
            showSurface.boolValue = !showSurface.boolValue;
        }
        if (GUILayout.Button("Surface", groupFoldout))
        {
            showSurface.boolValue = !showSurface.boolValue;
        }
        showHelpSurface = GUILayout.Toggle((showSurface.boolValue) ? showHelpSurface : false, helpIcon, helpButton);
        EditorGUILayout.EndHorizontal();

        //Body
        if (showSurface.boolValue)
        {
            EditorGUILayout.Space();

            if (!useCustomNormals.boolValue)
            {
                EditorGUILayout.PropertyField(normalStrength, new GUIContent("Normal strength"));
            }
            if (showHelpSurface) EditorGUILayout.HelpBox("The normal are also used for the reflection highlight, so the normal strength also has an effect on it.", MessageType.Info);
            EditorGUILayout.PropertyField(worldSpaceTiling, new GUIContent("World-space tiling"));
            if (showHelpSurface) EditorGUILayout.HelpBox("Rather than using the mesh's UV, you can opt to use world-space coordinates. Which are independent from the object's scale and position.", MessageType.Info);
            EditorGUILayout.PropertyField(tiling, new GUIContent("Tiling"));
            if (showHelpSurface) EditorGUILayout.HelpBox("Sets the size of the entire material at which it repeats.", MessageType.Info);


            EditorGUILayout.PropertyField(transparency, new GUIContent("Transparency"));

            if (!isMobileBasic)
            {
                EditorGUILayout.PropertyField(fresnel, new GUIContent("Fresnel"));
                if (showHelpSurface) EditorGUILayout.HelpBox("Controls the distance of the fresnel effect. Higher values push it further towards the horizon.", MessageType.Info);

            }

            EditorGUILayout.PropertyField(glossiness, new GUIContent("Glossiness"));
            if (showHelpSurface) EditorGUILayout.HelpBox("Determine how glossy the material is. Higher values show more light reflection.", MessageType.Info);

            if (!isMobileAdvanced && !isMobileBasic)
            {
                EditorGUILayout.PropertyField(refractionAmount, new GUIContent("Refraction"));
                if (showHelpSurface) EditorGUILayout.HelpBox("Bends the light passing through the water surface, creating a visual distortion.", MessageType.Info);

                EditorGUILayout.PropertyField(reflectionCubemap, new GUIContent("Reflection cubemap"));
                if (showHelpSurface) EditorGUILayout.HelpBox("The glossiness value has a direct effect on the intensity of this cubemap.", MessageType.Info);

            }

        }
        EditorGUILayout.Space();
    }

    void DoInterSection()
    {
        //Head
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button((showIntersection.boolValue) ? "-" : "+", collapseButton))
        {
            showIntersection.boolValue = !showIntersection.boolValue;
        }
        if (GUILayout.Button("Intersection", groupFoldout))
        {
            showIntersection.boolValue = !showIntersection.boolValue;
        }
        showHelpIntersection = GUILayout.Toggle((showIntersection.boolValue) ? showHelpIntersection : false, helpIcon, helpButton);
        EditorGUILayout.EndHorizontal();

        //Body
        if (showIntersection.boolValue)
        {
            EditorGUILayout.Space();

            if (showHelpIntersection) EditorGUILayout.HelpBox("If the intersection effect doesn't appear, be sure to add the \"EnableDepthBuffer\" script to your camera.", MessageType.Warning);


            EditorGUILayout.PropertyField(useCustomIntersection, new GUIContent("Use custom texture"));
            if (showHelpIntersection) EditorGUILayout.HelpBox("Choose a black/white texture, it will automatically be packed into the the \"shadermap\" texture channel.", MessageType.Info);

            if (useCustomIntersection.boolValue)
            {
                EditorGUILayout.PropertyField(customIntersection, new GUIContent("Grayscale texture"));
                if (customIntersection.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Texture field may not be empty", MessageType.Warning);
                }

            }
            EditorGUILayout.BeginHorizontal();
            if (!useCustomIntersection.boolValue)
            {
                intersectionStyle.intValue = EditorGUILayout.Popup("Style", (int)intersectionStyle.intValue, intersectionStyleNames, new GUILayoutOption[0]);
            }

            if (GUILayout.Button("Apply", EditorStyles.miniButton))
            {
                BakeSubstance();
            }
            EditorGUILayout.EndHorizontal();
            if (showHelpIntersection) EditorGUILayout.HelpBox("Pick one of the built-in intersection texture styles.", MessageType.Info);

            EditorGUILayout.PropertyField(rimSize, new GUIContent("Size"));
            if (showHelpIntersection) EditorGUILayout.HelpBox("Increase the size of the intersection effect.", MessageType.Info);

            EditorGUILayout.PropertyField(rimFalloff, new GUIContent("Falloff"));
            if (showHelpIntersection) EditorGUILayout.HelpBox("Controls how strongly the effect should taper off.", MessageType.Info);


            if (!isMobileBasic)
            {
                EditorGUILayout.PropertyField(rimDistance, new GUIContent("Distance"));
                if (showHelpIntersection) EditorGUILayout.HelpBox("Adds an offset to the effect from the intersecting object.", MessageType.Info);

            }

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Tiling");
            if (GUILayout.Button("<<", EditorStyles.miniButtonLeft))
            {
                rimTiling.floatValue -= .5f;
            }
            if (GUILayout.Button("<", EditorStyles.miniButtonMid))
            {
                rimTiling.floatValue -= .1f;
            }
            EditorGUILayout.PropertyField(rimTiling, new GUIContent(""), GUILayout.MaxWidth(45));
            if (GUILayout.Button(">", EditorStyles.miniButtonMid))
            {
                rimTiling.floatValue += .1f;
            }
            if (GUILayout.Button(">>", EditorStyles.miniButtonRight))
            {
                rimTiling.floatValue += .5f;
            }
            EditorGUILayout.EndHorizontal();
            if (rimTiling.floatValue == 0)
            {
                EditorGUILayout.HelpBox("Tiling value should not be 0", MessageType.Warning);
            }
            if (showHelpIntersection) EditorGUILayout.HelpBox("Controls the tiling size of the intersection texture.\n\nThis is also affected by the \"Tiling\" value in the Surface options section.", MessageType.Info);

        }

        EditorGUILayout.Space();
    }

    void DoSurfaceHighlights()
    {
        if (!isMobileBasic)
        {
            //Head
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button((showHighlights.boolValue) ? "-" : "+", collapseButton))
            {
                showHighlights.boolValue = !showHighlights.boolValue;
            }
            if (GUILayout.Button("Surface highlights", groupFoldout))
            {
                showHighlights.boolValue = !showHighlights.boolValue;
            }
            showHelpHighlights = GUILayout.Toggle((showHighlights.boolValue) ? showHelpHighlights : false, helpIcon, helpButton);
            EditorGUILayout.EndHorizontal();

            if (showHighlights.boolValue)
            {

                EditorGUILayout.Space();

                if (!isMobileAdvanced)
                {

                    EditorGUI.BeginDisabledGroup(intersectionStyle.intValue == 0);
                    EditorGUILayout.PropertyField(useIntersectionHighlight, new GUIContent("Use intersection texture"));
                    if (showHelpHighlights) EditorGUILayout.HelpBox("Instead of sampling the highlight from the wave normal map, use the intersection texture.", MessageType.Info);
                    EditorGUI.EndDisabledGroup();
                    if (intersectionStyle.intValue == 0)
                    {
                        EditorGUILayout.HelpBox("Intersection style is set to \"None\", therefore this option is disabled.", MessageType.Info);
                        useIntersectionHighlight.boolValue = false;
                    }

                    if (useIntersectionHighlight.boolValue)
                    {
                        EditorGUILayout.PropertyField(surfaceHighlightPanning, new GUIContent("Cross-panning textures"));
                        if (showHelpHighlights) EditorGUILayout.HelpBox("Enable an additional cross-panning texture.", MessageType.Info);

                    }
                }
                else
                {
                    useIntersectionHighlight.boolValue = false;
                    surfaceHighlightPanning.boolValue = false;
                }

                EditorGUILayout.PropertyField(surfaceHighlight, new GUIContent("Opacity"));
                if (showHelpHighlights) EditorGUILayout.HelpBox("Controls the intensity of the effect.", MessageType.Info);


                if (!useIntersectionHighlight.boolValue)
                {
                    EditorGUILayout.PropertyField(surfaceHighlightSize, new GUIContent("Size"));

                }

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Tiling");
                if (GUILayout.Button("<<", EditorStyles.miniButtonLeft))
                {
                    surfaceHighlightTiling.floatValue -= .5f;
                }
                if (GUILayout.Button("<", EditorStyles.miniButtonMid))
                {
                    surfaceHighlightTiling.floatValue -= .1f;
                }
                EditorGUILayout.PropertyField(surfaceHighlightTiling, new GUIContent(""), GUILayout.MaxWidth(45));
                if (GUILayout.Button(">", EditorStyles.miniButtonMid))
                {
                    surfaceHighlightTiling.floatValue += .1f;
                }
                if (GUILayout.Button(">>", EditorStyles.miniButtonRight))
                {
                    surfaceHighlightTiling.floatValue += .5f;
                }
                EditorGUILayout.EndHorizontal();
                if (surfaceHighlightTiling.floatValue == 0)
                {
                    EditorGUILayout.HelpBox("Tiling value should not be 0", MessageType.Warning);
                }
                if (showHelpHighlights) EditorGUILayout.HelpBox("Controls the tiling size of the surface highlight texture.\n\nThis is also affected by the \"Tiling\" value in the Surface options section.", MessageType.Info);
            }

            EditorGUILayout.Space();
        }//not mobile basic
    }

    void DoDepth()
    {
        if (!isMobileBasic)
        {
            //Head
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button((showDepth.boolValue) ? "-" : "+", collapseButton))
            {
                showDepth.boolValue = !showDepth.boolValue;
            }
            if (GUILayout.Button("Depth", groupFoldout))
            {
                showDepth.boolValue = !showDepth.boolValue;
            }
            showHelpDepth = GUILayout.Toggle((showDepth.boolValue) ? showHelpDepth : false, helpIcon, helpButton);
            EditorGUILayout.EndHorizontal();


            if (showDepth.boolValue)
            {
                EditorGUILayout.Space();

                if (showHelpDepth) EditorGUILayout.HelpBox("If the depth effect doesn't appear, be sure to add the \"EnableDepthBuffer\" script to your camera.", MessageType.Warning);

                EditorGUILayout.PropertyField(depth, new GUIContent("Depth"));
                if (showHelpDepth) EditorGUILayout.HelpBox("Sets the depth of the water.", MessageType.Info);

                EditorGUILayout.PropertyField(depthDarkness, new GUIContent("Darkness"));
                if (showHelpDepth) EditorGUILayout.HelpBox("Controls the darkness of the deep water.", MessageType.Info);

            }

            EditorGUILayout.Space();
        }
    }

    void DoWaves()
    {
        //Head
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button((showWaves.boolValue) ? "-" : "+", collapseButton))
        {
            showWaves.boolValue = !showWaves.boolValue;
        }
        if (GUILayout.Button("Waves", groupFoldout))
        {
            showWaves.boolValue = !showWaves.boolValue;
        }
        showHelpWaves = GUILayout.Toggle((showWaves.boolValue) ? showHelpWaves : false, helpIcon, helpButton);
        EditorGUILayout.EndHorizontal();

        //Body
        if (showWaves.boolValue)
        {

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(useCustomNormals, new GUIContent("Use custom normal map"));
            if (showHelpWaves) EditorGUILayout.HelpBox("Opt to use a custom normal map for the waves", MessageType.Info);

            if (useCustomNormals.boolValue)
            {
                EditorGUILayout.PropertyField(customNormal, new GUIContent("Normal map"));

                if (customNormal.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Field cannot be empty", MessageType.Warning);
                }
            }

            EditorGUILayout.BeginHorizontal();
            if (!useCustomNormals.boolValue)
            {
                waveStyle.intValue = EditorGUILayout.Popup("Small waves style", (int)waveStyle.intValue, waveStyleList, new GUILayoutOption[0]);

            }

            if (GUILayout.Button("Apply", EditorStyles.miniButton))
            {
                BakeSubstance();

            }
            EditorGUILayout.EndHorizontal();
            if (showHelpWaves) EditorGUILayout.HelpBox("Choose from one of the built-in normal maps", MessageType.Info);


            EditorGUILayout.Space();

            if (!isMobileAdvanced && !isMobileBasic)
            {
                EditorGUILayout.BeginHorizontal();
                waveHeightmapStyle.intValue = EditorGUILayout.Popup("Big waves animation", (int)waveHeightmapStyle.intValue, waveHeightmapList, new GUILayoutOption[0]);

                if (GUILayout.Button("Apply", EditorStyles.miniButton))
                {
                    BakeSubstance();

                }
                EditorGUILayout.EndHorizontal();
                if (showHelpWaves) EditorGUILayout.HelpBox("Choose from one of the built-in height maps.", MessageType.Info);

                EditorGUILayout.Space();
            }

            EditorGUILayout.PropertyField(waveSpeed, new GUIContent("Speed"));
            if (showHelpWaves) EditorGUILayout.HelpBox("Overal speed of the wave animations.", MessageType.Info);

            if (!isMobileBasic)
            {
                EditorGUILayout.PropertyField(waveStrength, new GUIContent("Height"));
                if (showHelpWaves) EditorGUILayout.HelpBox("height of the waves, this can also be controlled through the Y-axis scale of the object, at least for planes.", MessageType.Info);
            }

            if (!isMobileAdvanced && !isMobileBasic)
            {

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Tiling");
                if (GUILayout.Button("<<", EditorStyles.miniButtonLeft))
                {
                    waveSize.floatValue -= .1f;
                }
                if (GUILayout.Button("<", EditorStyles.miniButtonMid))
                {
                    waveSize.floatValue -= .01f;
                }
                EditorGUILayout.PropertyField(waveSize, new GUIContent(""), GUILayout.MaxWidth(45));
                if (GUILayout.Button(">", EditorStyles.miniButtonMid))
                {
                    waveSize.floatValue += .01f;
                }
                if (GUILayout.Button(">>", EditorStyles.miniButtonRight))
                {
                    waveSize.floatValue += .1f;
                }
                EditorGUILayout.EndHorizontal();
                if (waveSize.floatValue == 0)
                {
                    EditorGUILayout.HelpBox("Tiling value should not be 0", MessageType.Warning);
                }
                if (showHelpWaves) EditorGUILayout.HelpBox("Controls the tiling size of the wave animation.\n\nThis is also affected by the \"Tiling\" value in the Surface options section.", MessageType.Info);
            }
        }


        EditorGUILayout.Space();
    }

    void DoAdvanced()
    {

        //Head
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button((showAdvanced.boolValue) ? "-" : "+", collapseButton))
        {
            showAdvanced.boolValue = !showAdvanced.boolValue;
        }
        if (GUILayout.Button("Advanced", groupFoldout))
        {
            showAdvanced.boolValue = !showAdvanced.boolValue;
        }
        showHelpAdvanced = GUILayout.Toggle((showAdvanced.boolValue) ? showHelpAdvanced : false, helpIcon, helpButton);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        //Body
        if (showAdvanced.boolValue)
        {
#if !UNITY_5_5_OR_NEWER
            EditorGUILayout.PropertyField(hideWireframe, new GUIContent("Hide wireframe"));
            if (showHelpAdvanced) EditorGUILayout.HelpBox("Hides the wireframe of the selected object, for easier visual tuning.", MessageType.Info);
#endif

            if (shaderName.Contains("Tessellation"))
            {
                EditorGUILayout.PropertyField(tessellation, new GUIContent("Tessellation"));
                if (showHelpAdvanced) EditorGUILayout.HelpBox("Tessellation creates additional mesh vertices, resulting in higher detail wave animations.", MessageType.Info);
            }

            EditorGUILayout.PropertyField(useCompression, new GUIContent("Compressed textures"));
            if (showHelpAdvanced) EditorGUILayout.HelpBox("Bake the textures using compression, trading in quality for a smaller file size.\n\nPVRTC compression is used for mobile, DXT5 is used on other platforms.", MessageType.Info);

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PropertyField(seed);
            if (GUILayout.Button("Randomize", EditorStyles.miniButton))
            {
                seed.floatValue = Random.Range(1, 9999);
            }
            EditorGUILayout.EndHorizontal();
            if (showHelpAdvanced) EditorGUILayout.HelpBox("A different seed number will make a different procedural variation of the textures.", MessageType.Info);
        }

        EditorGUILayout.Space();

    }

    void DoFooter()
    {
        EditorGUILayout.Space();

        GUILayout.Label("- Staggart Creations -", new GUIStyle(EditorStyles.centeredGreyMiniLabel)
        {
            alignment = TextAnchor.MiddleCenter,
            wordWrap = true,
            fontSize = 12
        });
    }

    //Set up GUIStyle for headers
    void SetStyling()
    {

        if (groupFoldout != null || helpButton != null || collapseButton != null || helpButtonContent != null) return;

        helpButtonContent = new GUIContent()
        {
            image = helpIcon,
            //text = "Toggle Help"
        };

        collapseButton = new GUIStyle(EditorStyles.miniButtonLeft)
        {
            fontSize = 12,
            fontStyle = FontStyle.Normal,
            fixedWidth = 30,
            fixedHeight = 21.5f,
        };

        helpButton = new GUIStyle(EditorStyles.miniButtonRight)
        {
            fontSize = 12,
            fontStyle = FontStyle.Normal,
            fixedWidth = 50,
            fixedHeight = 21.5f
        };

        helpIcon = EditorGUIUtility.ObjectContent(null, typeof(Light)).image;
        helpIcon = EditorGUIUtility.FindTexture("d_UnityEditor.InspectorWindow");

        RectOffset groupFoldoutPadding = new RectOffset()
        {
            left = 10,
            top = 4,
            bottom = 5
        };

        groupFoldout = new GUIStyle(EditorStyles.miniButtonMid)
        {
            fontSize = 11,
            alignment = TextAnchor.MiddleLeft,
            stretchWidth = true,
            padding = groupFoldoutPadding
        };

    }

}
#endif
