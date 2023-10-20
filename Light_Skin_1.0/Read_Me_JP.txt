//Light_Skin_Shador
//UTSの一部の機能を参考にしました。
//該当するシェーダの情報を知りたい場合は、是非関連リンクをご利用ください
//https://unity-chan.com/

メッシュの上にマテリアルを追加することで、既存のサーフェスにパターンを追加できます。

Please understand.          ------------------------------------
ダウンロード商品の性質上、ブースの仕様上、購入後の返品はできません。
マークの位置は既存のUVを基準に表示されるため、UVマッピングの設定によっては異なって表示される場合があります。
Skined Mesh Renderer の設定で複数のマテリアルが分割されている場合、表示されない場合があります。


※ main function             ---------------------------

▶ size                      - サイズ
▶ rotation                  - 回転
▶ position placement        - 位置の配置
▶ Emissive function of basic unity chan toon shader -UTSベースのemissive機能
▶ Bloom function            - Bloomの設定
▷poiyomi's emission function(not implemented) - poiyomi emission 機能（未実装）



mesh(you want) -> Skinned Mesh Renderer component -> Materials -> size 1 up-> Element add



Material shader settings    -------------------------------------


texture
┕ テクスチャはスプライト (2d および ui) に設定する必要があります。
┕ テクスチャのパターンには、空の周囲が必要です
┕ それらは同じ長さと幅でなければなりません
┕ テクスチャ パターンは、テクスチャの中心に配置する必要があります。

Bloom texture
┕ これはブルームの形のテクスチャで既存のテクスチャをカバーするフォーマットです。 (オプション)

▶ size
┕ サイズ基準はテクスチャの中心です

▶ rotation
┕ 回転基準はテクスチャの中心です。
┕ 0～1の時は1回転します

▶ position placement
┕ バックグラウンド テクスチャ uv に基づいて配置されます
┕ x と y に関して、z と w は調整する必要はありません

▶ Emissive function of basic unity chan toon shader
┕ ユニティちゃんトゥーンシェーダーの機能を参考に。

▶ Bloom function
┕ ブルーム テクスチャはオプションです。
┕ この機能は、unity chan toon シェーダー機能には含まれていません。

利用規約            -------------------------------------------------------
    1. 個人による商用利用
        許可します
    2. 法人による商用利用
        許可します
    3. 性的表現への利用
        許可します
    4. 暴力的表現への利用
        許可します
    5. 政治活動への利用および、宗教活動への利用
        個別に問い合わせてください
    6. 再配布
        等商品のデータを含むものの再配布は許可しません
        等商品を利用する想定のテクスチャやMaterialの設定値等、当商品のデータを含まない形式での配布は許可します