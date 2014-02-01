/*
* Energy Bar Toolkit by Mad Pixel Machine
* http://www.madpixelmachine.com
*/

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace EnergyBarToolkit {

public class MenuItems : ScriptableObject {

    // ===========================================================
    // Constants
    // ===========================================================

    // ===========================================================
    // Fields
    // ===========================================================

    // ===========================================================
    // Methods for/from SuperClass/Interfaces
    // ===========================================================

    // ===========================================================
    // Methods
    // ===========================================================
    
    [MenuItem("Tools/Energy Bar Toolkit/Init Tool", false, 100)]
    static void InitTool() {
        MadInitTool.ShowWindow();
    }
    
    [MenuItem ("Tools/Energy Bar Toolkit/Create Font", false, 120)]
    static void CreateFont() {
        MadFontBuilder.CreateFont();
    }
    
    [MenuItem ("Tools/Energy Bar Toolkit/Create UI/Sprite", false, 140)]
    static void CreateSprite() {
        var sprite = MadTransform.CreateChild<MadSprite>(ActiveParentOrPanel(), "sprite");
        Selection.activeGameObject = sprite.gameObject;
    }
    
    [MenuItem ("Tools/Energy Bar Toolkit/Create UI/Text", false, 141)]
    static void CreateText() {
        var text = MadTransform.CreateChild<MadText>(ActiveParentOrPanel(), "text");
        Selection.activeGameObject = text.gameObject;
    }
    
    [MenuItem ("Tools/Energy Bar Toolkit/Create UI/Anchor", false, 142)]
    static void CreateAnchor() {
        var anchor = MadTransform.CreateChild<MadAnchor>(ActiveParentOrPanel(), "Anchor");
        Selection.activeGameObject = anchor.gameObject;
    }
    
    static Transform ActiveParentOrPanel() {
        Transform parentTransform = null;
        
        var transforms = Selection.transforms;
        if (transforms.Length > 0) {
            var firstTransform = transforms[0];
            if (MadTransform.FindParent<MadPanel>(firstTransform) != null) {
                parentTransform = firstTransform;
            }
        }
        
        if (parentTransform == null) {
            var panel = MadPanel.UniqueOrNull();
            if (panel != null) {
                parentTransform = panel.transform;
            }
        }
        
        return parentTransform;
    }
    
    [MenuItem("Tools/Energy Bar Toolkit/Create OnGUI Bar/Fill Renderer", false, 150)]
    static void CreateFillRendererOnGUI() {
        Create<EnergyBarRenderer>("fill renderer");
    }
    
    [MenuItem("Tools/Energy Bar Toolkit/Create OnGUI Bar/Repeat Renderer", false, 151)]
    static void CreateRepeatRendererOnGUI() {
        Create<EnergyBarRepeatRenderer>("repeat renderer");
    }
    
    [MenuItem("Tools/Energy Bar Toolkit/Create OnGUI Bar/Sequence Renderer", false, 152)]
    static void CreateSequenceRendererOnGUI() {
        Create<EnergyBarSequenceRenderer>("sequence renderer");
    }
    
    [MenuItem("Tools/Energy Bar Toolkit/Create OnGUI Bar/Transform Renderer", false, 153)]
    static void CreateTransformRendererOnGUI() {
        Create<EnergyBarTransformRenderer>("transform renderer");
    }
    
    static T Create<T>(string name) where T : Component {
        var parent = Selection.activeTransform;
        var component = MadTransform.CreateChild<T>(parent, name);
        Selection.activeObject = component.gameObject;
        return component;
    }
    
    [MenuItem("Tools/Energy Bar Toolkit/Create Mesh Bar/Fill Renderer", false, 160)]
    static void CreateFillRenderer() {
        FillRenderer3DTool.CreateWizard();
    }
 
    [MenuItem("Tools/Energy Bar Toolkit/Online Resources/MadPixelMachine", false, 1000)]
    static void MadPixelMachine() {
        Application.OpenURL(
            "http://madpixelmachine.com");
    }
    
    [MenuItem("Tools/Energy Bar Toolkit/Online Resources/Support", false, 1100)]
    static void Support() {
        Application.OpenURL(
            "http://docs.madpixelmachine.com/energybartoolkit/doc/latest/support.html");
    }
    
    [MenuItem("Tools/Energy Bar Toolkit/Online Resources/Online Manual", false, 1000)]
    static void OnlineManual() {
        Application.OpenURL(
            "http://redmine.madpixelmachine.com/projects/energy-bar-toolkit-public/wiki/Documentation2");
    }
    
    [MenuItem("Tools/Energy Bar Toolkit/Online Resources/Examples", false, 1000)]
    static void Examples() {
        Application.OpenURL(
            "http://redmine.madpixelmachine.com/projects/energy-bar-toolkit-public/wiki/Examples");
    }
    
    [MenuItem("Tools/Energy Bar Toolkit/Online Resources/Release Notes", false, 1000)]
    static void ReleaseNotes() {
        Application.OpenURL(
            "http://redmine.madpixelmachine.com/projects/energy-bar-toolkit-public/wiki/Release_Notes");
    }

    // ===========================================================
    // Static Methods
    // ===========================================================

    // ===========================================================
    // Inner and Anonymous Classes
    // ===========================================================

}

} // namespace