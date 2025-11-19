using System.Collections.Generic;

// ===================================================================
/// ジャンプのプリセット定義
// ==================================================================
public enum JumpPreset
{
    Custom,                 // カスタム（手動設定）
    LightAndSnappy,        // ①軽め・キビキビ
    StandardBalanced,      // ②標準・誰でも扱いやすい
    FloatyLong,           // ③ふわっと長め
    SlowRiseFastFall,     // ④タメ強め → ストン落ち
    HighAndFast,          // ⑤スパッと高く跳ぶ
    RhythmicPause,        // ⑥リズムに合わせて '間' を感じる
    LowStepJump,          // ⑦低く速いステップジャンプ
    TaikoStyle,           // ⑧太鼓の達人っぽいタメジャンプ
    LongAirtime,          // ⑨空中に長くいる見せるジャンプ
    RhythmGameOptimized   // ⑩音ゲー特化：拍合わせ用バランス型
}
// ==================================================================
/// ジャンプパラメータの構造体
// ==================================================================
[System.Serializable]
public struct JumpParameters
{
    public float jumpHeight;
    public float timeToApex;
    public float airTime;
    public float fallTime;

    public JumpParameters(float height, float toApex, float air, float fall)
    {
        jumpHeight = height;
        timeToApex = toApex;
        airTime = air;
        fallTime = fall;
    }
}
// ==================================================================
// プリセットデータを管理する静的クラス
// ==================================================================
public static class JumpPresetData
{
    public static readonly Dictionary<JumpPreset, JumpParameters> PresetParameters = new Dictionary<JumpPreset, JumpParameters>
    {
        { JumpPreset.LightAndSnappy, new JumpParameters(3.5f, 0.25f, 0.05f, 0.25f) },
        { JumpPreset.StandardBalanced, new JumpParameters(4f, 0.35f, 0.15f, 0.35f) },
        { JumpPreset.FloatyLong, new JumpParameters(4.5f, 0.45f, 0.25f, 0.45f) },
        { JumpPreset.SlowRiseFastFall, new JumpParameters(4f, 0.5f, 0.1f, 0.25f) },
        { JumpPreset.HighAndFast, new JumpParameters(5f, 0.2f, 0f, 0.25f) },
        { JumpPreset.RhythmicPause, new JumpParameters(4f, 0.3f, 0.3f, 0.3f) },
        { JumpPreset.LowStepJump, new JumpParameters(2.5f, 0.2f, 0f, 0.2f) },
        { JumpPreset.TaikoStyle, new JumpParameters(4.5f, 0.5f, 0.05f, 0.45f) },
        { JumpPreset.LongAirtime, new JumpParameters(4f, 0.3f, 0.5f, 0.3f) },
        { JumpPreset.RhythmGameOptimized, new JumpParameters(4f, 0.28f, 0.12f, 0.28f) }
    };
}
