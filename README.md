# Unity Jump Controller

Unityでキャラクターにジャンプ動作を追加できるライブラリです。  
10種類のプリセットから選ぶだけで、リズムゲームやアクションゲームに適したジャンプを簡単に実装できます。

## 1. どのようなライブラリか

このライブラリは、Unityのゲームオブジェクトに**自然なジャンプ動作**を追加するためのコンポーネントです。

### 主な機能
- **10種類のプリセット**: 用途に合わせたジャンプパターンを選択可能
- **簡単設定**: インスペクターでプリセットを選ぶだけ
- **カスタマイズ可能**: ジャンプの高さ、速度、滞空時間を細かく調整可能
- 
## 2. ダウンロード手順

### GitHubからダウンロード

1. このリポジトリのページを開く
2. 緑色の「Code」ボタンをクリック
3. 「Download ZIP」を選択してダウンロード
4. ZIPファイルを解凍

### 必要なファイル

- `JumpController.cs`
- `JumpPresetData.cs`

この2つのファイルをUnityプロジェクトにコピーしてください。

## 3. 実際に利用する手順

### ステップ1: スクリプトをプロジェクトに追加

1. Unityプロジェクトを開く
2. `JumpController.cs` と `JumpPresetData.cs` を `Assets/Scripts` フォルダ（任意の場所）にドラッグ&ドロップ

### ステップ2: コンポーネントをアタッチ

1. ジャンプさせたいゲームオブジェクト（キャラクター等）を選択
2. Inspectorで「Add Component」をクリック
3. 「Jump Controller」を検索して追加

### ステップ3: プリセットを選択

1. Inspectorの「Jump Controller」コンポーネントを確認
2. 「Preset」ドロップダウンから好みのジャンプスタイルを選択
3. 再生して左クリックでジャンプを確認

### ステップ4: 地面を設定

1. 地面になるオブジェクトに `Ground` タグを設定
2. 地面に Collider2D コンポーネントを追加

---

## 最小構成のコード例

このライブラリを適用する最小のコードは以下です：

using UnityEngine;

public class Player : MonoBehaviour
{
    private JumpController jumpController;

    private void Awake()
    {
        jumpController = GetComponent<JumpController>();
        if (jumpController == null)
        {
            Debug.LogError("Player に JumpController がアタッチされていません！");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            jumpController.TryJump();
        }
    }
}
```

このスクリプトをキャラクターにアタッチすれば、左クリックでジャンプできます。

---

## 4. 注意点

### ⚠️ Rigidbody2Dの設定が必要

このライブラリは **Transform を直接操作** するため、物理演算と競合する可能性があります。

**必須設定:**

ジャンプするゲームオブジェクトに Rigidbody2D がある場合、以下の設定を行ってください：

1. Rigidbody2D の **Body Type** を `Kinematic` に設定
2. または、Rigidbody2D を使用しない場合は削除

```
Inspector > Rigidbody2D > Body Type > Kinematic
```

### その他の注意点

- **入力**: デフォルトは左クリック（マウスボタン0）でジャンプします
- **タグ設定**: 地面オブジェクトに `Ground` タグが必要です
- **Collider**: キャラクターと地面の両方に Collider2D が必要です
- **2D専用**: 現在は2D環境での使用を想定しています

---

## プリセット一覧

| プリセット名 | 特徴 |
|------------|------|
| Standard Balanced | 標準的でバランスの良いジャンプ |
| Light And Snappy | 軽くて素早い動き |
| Floaty Long | ふわっとした浮遊感 |
| Slow Rise Fast Fall | ゆっくり上昇、速く落下 |
| High And Fast | 高く素早いジャンプ |
| Rhythm Game Optimized | リズムゲーム向け |
| その他 | 太鼓風、ステップジャンプなど |

詳細なパラメータは `JumpPresetData.cs` を参照してください。
