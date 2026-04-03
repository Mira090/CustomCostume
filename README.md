# CustomCostume

## 概要

Team Horay の <a href="https://store.steampowered.com/app/2436940/_/">Sephiria</a> にコスチュームを追加できるようにする Mod です。

## インストール
1. <a href="https://github.com/LavaGang/MelonLoader">MelonLoader v0.7.1</a> をSephiriaにインストールしてください。  
2. Releases から最新の `CustomCostume.zip` をダウンロードし、解凍してください。
3. `Program Files (x86)\Steam\steamapps\common\Sephiria\Mods` フォルダ内に `CustomCostume.dll` を配置してください。
4. サンプルとして `CustomCostume.zip` に `RainbowRabbit` というカスタムコスチュームがあります。これを `Program Files (x86)\Steam\steamapps\common\Sephiria\Sephiria_Data\StreamingAssets\Costume` フォルダ内にコピーしてください。
5. ゲームを起動すると自動的に反映されます。

## コスチューム作成
- `StreamingAssets` フォルダに置いたコスチュームが読み込まれます。
- コスチュームフォルダは `Metadata.json` と画像ファイルで構成されています。
- `Metadata.json` にはコスチュームの情報があります。 `animationData` で使用する画像ファイルの名前を指定する必要があります。
- `costumeName` と `costumeFlavorText` はコスチュームの名前と説明文を書くことができます。翻訳を考慮する場合、ここに翻訳キーを書き、翻訳後の文章を各言語の翻訳ファイルに書き加える必要があります。
- `stats` はコスチュームのステータス効果を指定できます。スラッシュ左側にステータスのID、右側に値を書きます。
- `startingItems` はコスチュームの初期アイテムを指定できます。アイテムのID（数値）または名前を書きます。

## 注意事項
- このリポジトリおよびその貢献者は、Sephiria、Team Horay、または関連団体とは一切関係がありません 
- <a href="https://github.com/Mira090/CustomCostumeAddOn">CustomCostume AddOn</a> とは同時に使用しないでください。