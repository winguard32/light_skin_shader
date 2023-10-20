//Light_Skin_Shador_2.0
//UTSの一部の機能を参考にしました。
//該当するシェーダの情報を知りたい場合は、是非関連リンクをご利用ください
//https://unity-chan.com/

メッシュの上にマテリアルを追加することで、既存のサーフェスにパターンを追加できます。

Please Read me.          ------------------------------------
ダウンロードした商品の特性上、ご購入後の払い戻しはできません。
マーク位置は既存のUVを基準に表示されるため、UVマッピング設定によって異なる場合があります。
SkinedMeshRenderer設定で複数のMaterialが分割された場合、表示されないか異なる場合があります。

サービス約款-------------------------------------------------------------------------------------------
1.個人的な利用
許容
2.法人の利用
部分的許容(商業的利用の際にはお問い合わせ)
3.R-18クラスの使用
許容
4.R-18Gランクの使用
許容
5.政治·宗教活動に利用
一切禁止
6。再配布
当該製品データを含む再配布を禁止します
データを再抽出して使用できる形態の再配布は禁止します


※ main function             ---------------------------

▶ size                      - サイズ
▶ rotation                  - 回転
▶ position placement        - 位置の配置
▶ Emissive function of basic unity chan toon shader -UTSベースのemissive機能
▶ Bloom function            - Bloomの設定
▶Scrolling emission function - Scaning emission 機能



mesh(you want) -> Skinned Mesh Renderer component -> Materials -> size 1 up-> Element add

適用方法
mesh(you want) -> Skinned Mesh Renderer component -> Materials -> size 1 up-> Element add

1.お好みのメッシュをHierachyから選択
2.InspecterウィンドウSkinnedMeshRenderercomponent項目に
3.Materialsの数を1増やします(Elementadd)
4.用意されているPrefabを新たに生成されたElement項目に入れます


Material shader settings    -------------------------------------


texture
┕  textureはsprite（2dおよびui）に設定する必要があります
┕ テクスチャーパターンは希望する形が白、周辺は透明に処理されていなければなりません
(例は用意されているテクスチャをご参照ください)
┕ テクスチャーのサイズは横と縦が同一でなければなりません。(ex)512x512,1024x1024,2048x2048
┕ テクスチャーパターンはテクスチャーの中央に位置する必要があります
（より容易な調整のため中央に文様を配置することを推奨します）

Bloom texture
┕ これはブルームの形のテクスチャで既存のテクスチャをカバーするフォーマットです。 (オプション)

▶ size
┕ サイズ基準はテクスチャの中心です

▶ rotation
┕ 回転基準はテクスチャの中心です
┕ 0～1の時は1回転します

▶ offset (position placement)
┕ バックグラウンド テクスチャ uv に基づいて配置されます
┕ x と y に関して、z と w は調整する必要はありません

-----

▶ Emissive function of basic unity chan toon shader
┕ ユニティちゃんトゥーンシェーダーの機能を参考に

BaseSpeed(Time):実行されるアニメーションの時間間隔です。 単位:秒
┕ 1speed-1秒、2speed-0.5秒。(反比例)

ScrollU/Xdirection:U/X方向の動き方向と強度

ScrollV/Ydirection:V/Y方向の動き方向と強度

RotatearoundUVcenter:BaseSpeedが1の時、時計回りに1回転
┕ スクロール設定満足後回転。

PingPongMoveforBase:設定された方向に繰り返し移動

-----

▶ Bloom function
┕ ブルーム テクスチャはオプションです
┕ この機能は、unity chan toon シェーダー機能には含まれていません

-----
▶ ScrollingwithTime : Emissionをスクロール機能を追加

Strength : スクロール適用強度適用

Blinking Emission : Emissionの周期設定

Min : 最小周期
Max : 最大周期
Velocity : 速度

Direction : スクロールされる方向座標

Width : スクロールされるEmissiveの範囲
Velocity : スクロール速度
Interval : スクロール周期

-----

▶ ColorShiftwithTime:EmissiveテクスチャにDestinationColor色に向かって色の変化

DestinationColor:結果的に到達するカラーHDRが可能

ColorShiftSpeed(Time):色の変化の間隔。
┕ 1speed-6秒間隔変化(比例関係)

-----

▶ ViewShiftofColor:正面で正常な生相、側面では変化した色を表現

ViewShiftColor:側面からの色設定

-----