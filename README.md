Unityの2Dランゲームで使えるジャンプのライブラリを実装しました。
気持ちいジャンプの挙動を探すのに使ってもらえたらと思います。
- ジャンプの高さ
- 頂点に到達するまでの時間
- 滞空時間
- 落下までの時間
の四つの項目でジャンプの挙動を調整できます。




# 使い方
### ①以下のGitHub リンクを開く
https://github.com/noutetu/UnityJumpController


### ②赤丸をクリックしてzipをダウンロード
![スクリーンショット 2025-11-20 0.31.49.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/3826467/b58484bb-3f99-42bb-86b8-c9f7588bd363.png)
![スクリーンショット 2025-11-20 0.31.04.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/3826467/1828b5b6-3ecc-416f-9a1a-5e69c18befd5.png)

### ③zipを解凍しフォルダ内のJumpController.csとJumpPresetData.csをUnityプロジェクトにドラッグ&ドロップ

![スクリーンショット 2025-11-20 0.37.23.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/3826467/8cde5b4d-2e5f-4257-bd09-894a851ae528.png)

### ④ジャンプさせたいオブジェクトにJumpControllerをアタッチ
### ⑤ジャンプさせたいオブジェクトに、以下のコードを含ませる。

````md
### Player.cs

```csharp
using UnityEngine;

public class Player : MonoBehaviour
{
    private JumpController jumpController;

    private void Awake()
    {
        // 同じGameObjectについているJumpControllerを取得
        jumpController = GetComponent<JumpController>();
        if (jumpController == null)
        {
            Debug.LogError("Player に JumpController がアタッチされていません！");
        }
    }

    private void Update()
    {
        // 入力に応じてJumpControllerにジャンプを委譲
        if (Input.GetMouseButtonDown(0))
        {
            jumpController.TryJump();
        }
    }
}
```
````

### ⑥ジャンプさせたいオブジェクトと地面オブジェクトにRigidbody2Dと各種Collider2Dをつける。
![スクリーンショット 2025-11-20 0.47.25.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/3826467/039ce9b1-7328-41b2-b23e-3315e56ed08f.png)
### ⑦地面オブジェクトにはGroundタグを設定する。
![スクリーンショット 2025-11-20 0.48.15.png](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/3826467/b79e9f21-5ef3-4c2f-9996-23cbfc72e13a.png)

### ⑧Playmodeを開始して右クリック

![画面収録 2025-11-20 0.04.09.gif](https://qiita-image-store.s3.ap-northeast-1.amazonaws.com/0/3826467/151a322c-bb0a-4f03-b5dd-be6d1b09e8bf.gif)

### ⑨インスペクターでジャンプの挙動を調整
<img width="883" height="414" alt="スクリーンショット 2025-11-20 1 03 02" src="https://github.com/user-attachments/assets/331dbaf0-28ac-4bfb-b674-a1c6a1291ad2" />
