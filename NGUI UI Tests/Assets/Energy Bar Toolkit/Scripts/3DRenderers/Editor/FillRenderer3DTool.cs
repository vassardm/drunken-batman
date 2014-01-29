/*
* Energy Bar Toolkit by Mad Pixel Machine
* http://www.madpixelmachine.com
*/

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace EnergyBarToolkit {

public class FillRenderer3DTool : ScriptableWizard {

    // ===========================================================
    // Constants
    // ===========================================================

    // ===========================================================
    // Fields
    // ===========================================================
    
    public MadPanel panel;
    public string barName = "filled energy bar";

    // ===========================================================
    // Methods for/from SuperClass/Interfaces
    // ===========================================================

    // ===========================================================
    // Methods
    // ===========================================================
    
    void OnWizardCreate() {
        var bar = MadTransform.CreateChild<FillRenderer3D>(panel.transform, barName);
        TryApplyExampleTextures(bar);
        Selection.activeObject = bar.gameObject;
    }
    
    void TryApplyExampleTextures(FillRenderer3D bar) {
        var textureBar = AssetDatabase.LoadAssetAtPath(
            "Assets/Energy Bar Toolkit/Progress Bar Pack 1/Textures/bar1_bar.png", typeof(Texture2D)) as Texture2D;
        var textureFg = AssetDatabase.LoadAssetAtPath("Assets/Energy Bar Toolkit/Progress Bar Pack 1/Textures/bar1_fg.png", typeof(Texture2D)) as Texture2D;
        
        if (textureBar != null && textureFg != null) {
            bar.textureBar = textureBar;
            var tex = new EnergyBarBase.Tex();
            tex.texture = textureFg;
            tex.color = Color.white;
            
            bar.texturesBackground = new EnergyBarBase.Tex[1];
            bar.texturesBackground[0] = tex;
        }
    }
    
    void OnWizardUpdate() {
        CheckValid();
    }
    
    void CheckValid() {
        isValid = panel != null && !string.IsNullOrEmpty(barName);
    }

    // ===========================================================
    // Static Methods
    // ===========================================================
    
    public static void CreateWizard() {
        var panel = MadPanel.UniqueOrNull();
        
        if (panel == null) {
            if (EditorUtility.DisplayDialog(
                "Init Scene?",
                "Scene not initialized for 3D bars. You cannot place new bar without proper initialization. Do it now?",
                "Yes", "No")) {
                MadInitTool.ShowWindow();
                return;
            }
            
            panel = MadPanel.UniqueOrNull();
        }
    
        var wizard = ScriptableWizard.DisplayWizard<FillRenderer3DTool>("Create Fill Renderer 3D", "Create");
        wizard.panel = MadPanel.UniqueOrNull();
        wizard.CheckValid();
    }
    
    // ===========================================================
    // Inner and Anonymous Classes
    // ===========================================================

}

} // namespace