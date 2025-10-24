### 複数カメラ

- <https://tech.pjin.jp/blog/2021/07/31/unity-multi_camera/>
- カメラのviewportで複数カメラを表示できる

### URP PostEffect

- <https://tat1kun.hatenablog.com/entry/urp-postprocess>
- VolumeにAdd OverrideでPostEffectを追加できる

### カメラをキャラクタに追従

- <https://nekojara.city/unity-input-system-intro>
- Unityが新しいからInputSystemがデフォルトだった。Input.GetKeyは自分で有効にしないとエラー

### シーンの追加

- 新しく追加したシーンを開く
- File>Build Profilesを開く
- Activeになっているプラットフォームを選択
- OpenSceneList>AddOpenSceneを押す
  - シーンリストを開く、開いているシーンをリストに追加なので紛らわしい

### URPのMaterial

- Emissionをオンにすると光る
- 色とIntensityは別なので注意
- Intensityを増やすとめっちゃ光る

### Unityでgltf/glbの読み込み

- 公式パッケージの追加で読み込みできる
- "com.unity.cloud.gltfast"
