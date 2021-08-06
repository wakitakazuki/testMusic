SampleSceneの説明

|オブジェクト名|役割|使用中|
|:--|:--:|:--:|
|MainCamera|タッチ判定のためPhysics　Raycasterをアタッチ|〇|
|MainLane|EventTriggerがアタッチされており現状触れたら光る処理のみ<br>※pointerDown()→JColorのTap L＞Tap();|〇|
|MainJColor|判定ライン上のエフェクト的な処理<br>Tap（）関数でアルファ値を１に設定して徐々に減らす|〇|
|MainJLine|判定ライン（青い線引いてるだけ）|〇|
|GameManager|GameSystem:リザルトで使うパラメータを保持する<br>InputJson：Json読み込み→ノーツ生成|〇|
|MainDestroyPoint|通過したノーツを削除する|✕|
|MainJPoint|判定範囲：（中心からの距離で判定する予定）|✕|
|MainStartPoint|ノーツ発生地点|✕|
