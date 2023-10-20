//Light_Skin_Shador
//UTS의 일부 기능을 참고 하였습니다.
//해당 쉐이더의 정보를 알고 싶으시다면, 부디 관련 링크를 이용해주세요
//https://unity-chan.com/

mesh 위에 Material을 추가하여 기존 표면에 패턴을 추가할 수 있습니다.

참고사항                      ------------------------------------
다운로드한 상품의 특성상, 부스 사양으로 인해 구매 후 환불이 불가능합니다.
마크 위치는 기존 UV를 기준으로 나타나므로 UV 매핑 설정에 따라 다르게 나타날 수 있습니다.
Skined Mesh Renderer 설정에서 여러 Material가 분할된 경우 나타나지 않거나 다르게 나타날 수 있습니다.


※ 주요 기능             ---------------------------

▶ size                      - 사이즈
▶ rotation                  - 회전
▶ position placement        - 위치 설정
▶ Emissive function of basic unity chan toon shader -UTS 기반 emissive 기능
▶ Bloom function            - Bloom 설정
▷poiyomi's emission function(not implemented) - poiyomi emission 기능(미구현)


적용방법
mesh(you want) -> Skinned Mesh Renderer component -> Materials -> size 1 up-> Element add



Material shader settings    -------------------------------------


texture
┕ texture는 sprite(2d 및 ui)로 설정해야 합니다.
┕ 텍스처 패턴은 주변이 비어 있어야 합니다.
┕ 길이와 너비가 같아야 합니다.
┕ 텍스처 패턴은 텍스처 중앙에 위치해야 합니다.

Bloom texture
┕ 패턴 텍스처를 Bloom 형태의 텍스처로 덮는 형식입니다. (선택 사항)

▶ size
┕ 크기 기준은 텍스처의 중심입니다.

▶ rotation
┕ 회전 기준은 텍스처의 중심입니다.
┕ 0 에서 1일 때 1회전합니다.

▶ position placement
┕ 배경 질감 uv를 기준으로 배치됩니다.
┕ x 및 y로 z 및 w는 조정할 필요가 없습니다.

▶ Emissive function of basic unity chan toon shader
┕ unity chan toon 셰이더의 기능을 참조하십시오.

▶ Bloom function
┕ 블룸 텍스처는 선택 사항입니다.
┕ 이 기능은 UTS 기능에 포함되어 있지 않습니다.

서비스 약관            -------------------------------------------------------
    1. 개인적인 상업적 이용
        허용
    2. 법인의 상업적 이용
        허용
    3. 성적인 표현의 사용
        허용
    4. 폭력적인 언어 사용
        허용
    5. 정치·종교 활동에 이용
        개별적으로 문의하시기 바랍니다.
    6. 재배포
        해당 제품 데이터를 포함한 재배포를 금지합니다.
        제품 데이터가 포함되지 않은 형태로 배포, 제품에 사용된 것으로 추정되는 질감 및 소재 설정 등은 허용됩니다.