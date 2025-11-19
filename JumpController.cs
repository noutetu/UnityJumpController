using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [Header("プリセット選択")]
    [SerializeField] private JumpPreset preset = JumpPreset.StandardBalanced;

    [Header("ジャンプパラメータ")]
    [SerializeField] private float jumpHeight = 4f;
    [SerializeField] private float timeToApex = 0.35f;
    [SerializeField] private float airTime = 0.15f;
    [SerializeField] private float fallTime = 0.35f;

    [Space(10)]
    private bool isGrounded = true;   // 地面に接地しているかどうか
    private bool isJumping = false;   // ジャンプ中かどうか
    private JumpPreset lastPreset;    // 前回のプリセット

    private void Start()
    {
        // 初回プリセット適用
        ApplyPreset();
        lastPreset = preset;
    }

    private void OnValidate()
    {
        // インスペクターで値が変更されたときにプリセットを適用
        if (preset != lastPreset && preset != JumpPreset.Custom)
        {
            ApplyPreset();
            lastPreset = preset;
        }
        else if (preset != JumpPreset.Custom)
        {
            // パラメータが手動で変更された場合、Customに切り替え
            preset = JumpPreset.Custom;
            lastPreset = preset;
        }
    }

    private void ApplyPreset()
    {
        if (preset == JumpPreset.Custom || !JumpPresetData.PresetParameters.ContainsKey(preset))
            return;

        JumpParameters parameters = JumpPresetData.PresetParameters[preset];
        jumpHeight = parameters.jumpHeight;
        timeToApex = parameters.timeToApex;
        airTime = parameters.airTime;
        fallTime = parameters.fallTime;
    }

    private void Update()
    {
        if (isGrounded && Input.GetMouseButtonDown(0))
        {
            TryJump();
        }
    }

    public void TryJump()
    {
        if (isGrounded && !isJumping)
        {
            StartCoroutine(JumpSequence());
        }
    }

    private IEnumerator JumpSequence()
    {
        isGrounded = false;
        isJumping = true;

        // 1. 上昇処理
        yield return StartCoroutine(RisePhase());

        // 2. 滞空処理
        yield return StartCoroutine(AirPhase());

        // 3. 落下処理
        yield return StartCoroutine(FallPhase());

        isJumping = false;
    }

    // 上昇処理：timeToApex秒かけてjumpHeight分上昇
    private IEnumerator RisePhase()
    {
        float elapsedTime = 0f;
        Vector3 riseStartPos = transform.position;

        while (elapsedTime < timeToApex)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / timeToApex;
            
            // イージング（減速上昇）を適用
            float height = jumpHeight * (1f - Mathf.Pow(1f - t, 2));
            
            Vector3 newPos = riseStartPos;
            newPos.y = riseStartPos.y + height;
            transform.position = newPos;

            yield return null;
        }

        // 最終位置を確定
        Vector3 finalPos = riseStartPos;
        finalPos.y = riseStartPos.y + jumpHeight;
        transform.position = finalPos;
    }

    // 滞空処理：airTime秒待機
    private IEnumerator AirPhase()
    {
        float elapsedTime = 0f;
        Vector3 airPosition = transform.position;

        while (elapsedTime < airTime)
        {
            elapsedTime += Time.deltaTime;
            transform.position = airPosition; // 高さを維持
            yield return null;
        }
    }

    // 落下処理：fallTime秒かけてjumpHeight分落下
    private IEnumerator FallPhase()
    {
        float elapsedTime = 0f;
        Vector3 fallStartPos = transform.position;

        while (elapsedTime < fallTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fallTime;
            
            // イージング（加速落下）を適用
            float height = jumpHeight * Mathf.Pow(t, 2);
            
            Vector3 newPos = fallStartPos;
            newPos.y = fallStartPos.y - height;
            transform.position = newPos;

            yield return null;
        }

        // 最終位置を確定（開始位置に戻る）
        Vector3 finalPos = fallStartPos;
        finalPos.y = fallStartPos.y - jumpHeight;
        transform.position = finalPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}