/*
* Energy Bar Toolkit by Mad Pixel Machine
* http://www.madpixelmachine.com
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace EnergyBarToolkit {
 
[ExecuteInEditMode]
[RequireComponent(typeof(EnergyBar))]
public class FillRenderer3D : EnergyBarBase {

    // ===========================================================
    // Constants
    // ===========================================================
    
    // how much depth values will be reserved for single energy bar
    private const int DepthSpace = 32;

    // ===========================================================
    // Fields
    // ===========================================================
    
    
    //
    // textures
    //
    public Texture2D textureBar;
    
    //
    // appearance
    //
    public ColorType textureBarColorType;
    public Color textureBarColor = Color.white;
    public Gradient textureBarGradient;
    
    public GrowDirection growDirection = GrowDirection.LeftToRight;
    
    public float radialOffset;
    public float radialLength = 1;
    
    // label
    public MadFont labelFont;
    public float labelScale = 32;
    
    //
    // effect
    //
    
    // burn effect
    public bool effectBurn = false;                 // bar draining will display 'burn' effect
    public Texture2D effectBurnTextureBar;
    public Color effectBurnTextureBarColor = Color.red;
    private float burnDisplayValue;
    
    // blink effect
    public bool effectBlink = false;
    public float effectBlinkValue = 0.2f;
    public float effectBlinkRatePerSecond = 1f;
    public Color effectBlinkColor = new Color(1, 1, 1, 0);
    
    //
    // others
    //
    
#region Fields others
    [SerializeField]
    private int lastRebuildHash;
    
    private bool dirty = true;
    
    // sprite references
    
    [SerializeField]
    private MadSprite spriteBar;
    
    [SerializeField]
    private MadSprite spriteBurnBar;
    
    [SerializeField]
    private MadText labelSprite;
    
    [SerializeField]
    private List<MadSprite> spriteObjectsBg = new List<MadSprite>();
    
    [SerializeField]
    private List<MadSprite> spriteObjectsFg = new List<MadSprite>();
#endregion
    
    // ===========================================================
    // Properties
    // ===========================================================
    
    float _burnDisplayValue;
    float ValueFBurn {
        get {
            EnergyBarCommons.SmoothDisplayValue(
                    ref _burnDisplayValue, ValueF2, effectSmoothChangeSpeed);
            _burnDisplayValue = Mathf.Max(_burnDisplayValue, ValueF2);
            return _burnDisplayValue;
        }
    }
    
    float _actualDisplayValue;
    float ValueF2 {
    
        get {
        
            if (effectBurn) {
                if (effectSmoothChange) {
                    // in burn mode smooth primary bar only when it's increasing
                    if (ValueF > _actualDisplayValue) {
                        EnergyBarCommons.SmoothDisplayValue(ref _actualDisplayValue, ValueF, effectSmoothChangeSpeed);
                    } else {
                        _actualDisplayValue = energyBar.ValueF;
                    }
                } else {
                    _actualDisplayValue = energyBar.ValueF;
                }
                
            } else {
                if (effectSmoothChange) {
                    EnergyBarCommons.SmoothDisplayValue(ref _actualDisplayValue, ValueF, effectSmoothChangeSpeed);
                } else {
                    _actualDisplayValue = energyBar.ValueF;
                }
            }
            
            return _actualDisplayValue;
        }
    }
    
    bool Blink {
        get; set;
    }
    
    // return current bar color based on color settings and effect
    float _effectBlinkAccum;
    Color BarColor {
        get {
            Color outColor = Color.white;
            
            if (growDirection == EnergyBarBase.GrowDirection.ColorChange) {
                outColor = textureBarGradient.Evaluate(energyBar.ValueF);
            } else {
                switch (textureBarColorType) {
                    case ColorType.Solid:
                        outColor = textureBarColor;
                        break;
                    case ColorType.Gradient:
                        outColor = textureBarGradient.Evaluate(energyBar.ValueF);
                        break;
                    default:
                        MadDebug.Assert(false, "Unkwnown option: " + textureBarColorType);
                        break;
                }
            }
            
            if (Blink) {
                outColor = effectBlinkColor;
            }
            
            return ComputeColor(outColor);
        }
    }
    
    Color BurnColor {
        get {
            Color outColor = effectBurnTextureBarColor;
            if (Blink) {
                outColor = new Color(0, 0, 0, 0);
            }
            
            return ComputeColor(outColor);
        }
    }
                    
    // ===========================================================
    // Methods for/from SuperClass/Interfaces
    // ===========================================================
    
    public override Rect TexturesRect {
        get {
            if (spriteBar != null) {
                return spriteBar.GetBounds();
            } else {
                return new Rect();
            }
        }
    }

    // ===========================================================
    // Methods
    // ===========================================================
    
#if UNITY_EDITOR
    void OnDrawGizmos() {
    
        // Draw the gizmo
        Gizmos.matrix = transform.localToWorldMatrix;
        
        Gizmos.color = (UnityEditor.Selection.activeGameObject == gameObject)
            ? Color.green : new Color(1, 1, 1, 0.2f);
            
        var childSprites = MadTransform.FindChildren<MadSprite>(transform);
        Bounds totalBounds = new Bounds(Vector3.zero, Vector3.zero);
        bool totalBoundsSet = false;
        
        foreach (var sprite in childSprites) {
            Rect boundsRect = sprite.GetBounds();
            Bounds bounds = new Bounds(boundsRect.center, new Vector2(boundsRect.width, boundsRect.height));
            
            if (!totalBoundsSet) {
                totalBounds = bounds;
                totalBoundsSet = true;
            } else {
                totalBounds.Encapsulate(bounds);
            }
        }
        
            
        Gizmos.DrawWireCube(totalBounds.center, totalBounds.size);

        // Make the widget selectable
        Gizmos.color = Color.clear;
        Gizmos.DrawCube(totalBounds.center,
            new Vector3(totalBounds.size.x, totalBounds.size.y, 0.01f * (guiDepth + 1)));
    }
#endif

    void Update() {
        if (effectBlink) {
            Blink = EnergyBarCommons.Blink(
                ValueF, effectBlinkValue, effectBlinkRatePerSecond, ref _effectBlinkAccum);
        } else {
            Blink = false;
        }
    
        if (RebuildNeeded()) {
            Rebuild();
        }
        
        UpdateBar();
        UpdateLabel();
        UpdateColors();
    }
    
    void UpdateBar() {
        if (effectBurn && spriteBurnBar != null) {
            spriteBurnBar.tint = BurnColor;
            spriteBurnBar.fillValue = ValueFBurn;
        }
        
        if (spriteBar != null) {
            spriteBar.tint = BarColor;
            spriteBar.fillValue = ValueF2;
        }
    }
    
    void UpdateLabel() {
        if (labelSprite == null) {
            return;
        }
        
        labelSprite.scale = labelScale;
        labelSprite.text = LabelFormatResolve(labelFormat);
        
        labelSprite.transform.localPosition = LabelPositionPixels;
        
        labelSprite.tint = ComputeColor(labelColor);
    }
    
    void UpdateColors() {
        UpdateTextureColors(spriteObjectsBg, texturesBackground);
        UpdateTextureColors(spriteObjectsFg, texturesForeground);
    }
    
    void UpdateTextureColors(List<MadSprite> sprites, Tex[] textures) {
        if (sprites.Count != textures.Length) {
            Debug.LogWarning("Different number of sprites and registered textures. (" + sprites.Count + ", " + textures.Length + ")");
            return;
        }
        
        for (int i = 0; i < sprites.Count; i++) {
            var sprite = sprites[i];
            Tex texture = textures[i];
            
            sprite.tint = ComputeColor(texture.color);
        }
    }
    
    void LateUpdate() {
        if (anchorObject != null) {
            transform.position = anchorObject.transform.position;
        }
    }
    
    bool RebuildNeeded() {
        var hash = new MadHashCode();
        hash.AddEnumerable(texturesBackground);
        hash.Add(textureBar);
        hash.AddEnumerable(texturesForeground);
        hash.Add(guiDepth);
        hash.Add(growDirection);
        hash.Add(effectBurn);
        hash.Add(labelEnabled);
        hash.Add(labelFont);
        
        int hashNumber = hash.GetHashCode();
    
        if (hashNumber != lastRebuildHash || dirty) {
            lastRebuildHash = hashNumber;
            dirty = false;
            return true;
        } else {
            return false;
        }
    }
    
    void Rebuild() {
#if MAD_DEBUG
        Debug.Log("rebuilding " + this, this);
#endif
    
        if (spriteObjectsBg.Count == 0 && spriteObjectsFg.Count == 0) {
            // in previous version sprites were created without reference in spriteObjects
            // is spriteObjects is empty it's better to assume, that references are not created yet
            // and background objects may exist
            var children = MadTransform.FindChildren<MadSprite>(transform,
                (s) => s.name.StartsWith("bg_") || s.name.StartsWith("fg_") || s.name == "label",
                0);
            foreach (var child in children) {
                MadGameObject.SafeDestroy(child.gameObject);
            }
        } else {
            foreach (var sprite in spriteObjectsBg) {
                MadGameObject.SafeDestroy(sprite.gameObject);
            }
            
            foreach (var sprite in spriteObjectsFg) {
                MadGameObject.SafeDestroy(sprite.gameObject);
            }
            
            spriteObjectsBg.Clear();
            spriteObjectsFg.Clear();
        }
        
        if (spriteBar != null) {
            MadGameObject.SafeDestroy(spriteBar.gameObject);
        }
        
        if (spriteBurnBar != null) {
            MadGameObject.SafeDestroy(spriteBurnBar.gameObject);
        }
        
        if (labelSprite != null) {
            MadGameObject.SafeDestroy(labelSprite.gameObject);
        }
        
        int nextDepth = BuildTextures(texturesBackground, "bg_", guiDepth * DepthSpace, ref spriteObjectsBg);
        
        if (textureBar != null) {
        
            if (effectBurn) {
                spriteBurnBar = MadTransform.CreateChild<MadSprite>(transform, "bar_effect_burn");
#if !MAD_DEBUG
                spriteBurnBar.gameObject.hideFlags = HideFlags.HideInHierarchy;
#endif
                spriteBurnBar.guiDepth = nextDepth++;
                spriteBurnBar.texture = textureBar;
                
                spriteBurnBar.fillType = ToFillType(growDirection);
            }
        
            spriteBar = MadTransform.CreateChild<MadSprite>(transform, "bar");
#if !MAD_DEBUG
            spriteBar.gameObject.hideFlags = HideFlags.HideInHierarchy;
#endif
            spriteBar.guiDepth = nextDepth++;
            spriteBar.texture = textureBar;
            
            spriteBar.fillType = ToFillType(growDirection);
        }
        
        nextDepth = BuildTextures(texturesForeground, "fg_", nextDepth, ref spriteObjectsFg);
        
        // label
        if (labelEnabled && labelFont != null) {
            labelSprite = MadTransform.CreateChild<MadText>(transform, "label");
            labelSprite.font = labelFont;
            labelSprite.guiDepth = nextDepth++;
            
#if !MAD_DEBUG
                labelSprite.gameObject.hideFlags = HideFlags.HideInHierarchy;
#endif
        }
    }
    
    MadSprite.FillType ToFillType(GrowDirection growDirection) {
        switch (growDirection) {
            case GrowDirection.LeftToRight:
                return MadSprite.FillType.LeftToRight;
            case GrowDirection.RightToLeft:
                return MadSprite.FillType.RightToLeft;
            case GrowDirection.TopToBottom:
                return MadSprite.FillType.TopToBottom;
            case GrowDirection.BottomToTop:
                return MadSprite.FillType.BottomToTop;
            case GrowDirection.ExpandHorizontal:
                return MadSprite.FillType.ExpandHorizontal;
            case GrowDirection.ExpandVertical:
                return MadSprite.FillType.ExpandVertical;
            case GrowDirection.RadialCW:
                return MadSprite.FillType.RadialCW;
            case GrowDirection.RadialCCW:
                return MadSprite.FillType.RadialCCW;
            case GrowDirection.ColorChange:
                return MadSprite.FillType.None;
            default:
                MadDebug.Assert(false, "Unkwnown grow direction: " + growDirection);
                return MadSprite.FillType.None;
        }
    }
    
    int BuildTextures(Tex[] textures, string prefix, int startDepth, ref List<MadSprite> sprites) {
        
        int counter = 0;
        foreach (var texture in textures) {
            if (texture.texture == null) {
                continue;
            }
        
            string name = string.Format("{0}{1:D2}", prefix, counter + 1);
            var sprite = MadTransform.CreateChild<MadSprite>(transform, name);
#if !MAD_DEBUG
            sprite.gameObject.hideFlags = HideFlags.HideInHierarchy;
#endif
            
            sprite.guiDepth = startDepth + counter;
            sprite.texture = texture.texture;
            sprite.tint = texture.color;
            
            sprites.Add(sprite);
            
            counter++;
        }
        
        return startDepth + counter;
    }
    
    // ===========================================================
    // Static Methods
    // ===========================================================

    // ===========================================================
    // Inner and Anonymous Classes
    // ===========================================================

}

} // namespace