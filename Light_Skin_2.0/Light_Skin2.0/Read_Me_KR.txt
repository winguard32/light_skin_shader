// Light_Skin_Shador_2.0
// UTS의 일부 기능을 참고 하였습니다.
// 해당 쉐이더의 정보를 알고 싶으시다면, 아래에 기재된 관련 링크를 이용해주세요
// https://unity-chan.com/

Mesh 위에 Material을 추가하여 기존 표면에 패턴을 추가할 수 있습니다.

참고사항                      ------------------------------------
다운로드한 상품의 특성상, 구매 후 환불이 불가능합니다.
마크 위치는 기존 UV를 기준으로 나타나므로 UV 매핑 설정에 따라 다르게 나타날 수 있습니다.
Skined Mesh Renderer 설정에서 여러 Material가 분할된 경우 나타나지 않거나 다르게 나타날 수 있습니다.


서비스 약관            -------------------------------------------------------
    1. 개인적인 이용
        허용
    2. 법인의 이용
        부분적 허용 (상업적 이용시 문의)
    3. R-18 등급의 사용
        허용
    4. R-18G 등급의 사용
        허용
    5. 정치·종교 활동에 이용
        일절 금지
    6. 재배포
        해당 제품 데이터를 포함한 재배포를 금지합니다.
        데이터를 재추출하여 사용할 수 있는 형태의 재배포를 금지합니다

※ 주요 기능             ---------------------------

▶ size                        - 사이즈
▶ rotation                    - 회전
▶ position placement          - 위치 설정
▶ Emissive function of basic unity chan toon shader -UTS 기반 emissive 기능
▶ Bloom function            - Bloom 설정
▶Scrolling emission function - 스캐닝 emission 기능


적용방법
mesh(you want) -> Skinned Mesh Renderer component -> Materials -> size 1 up-> Element add

1. 원하는 메쉬를 Hierachy에서 선택
2. Inspecter 창의 Skinned Mesh Renderer component 항목에
3. Materials 의 수를 1 늘립니다 (Element add)
4. 준비되어져 있는 Prefab을 새로 생성된 Element 항목에 넣어줍니다


Material shader settings    -------------------------------------


texture
┕ texture는 sprite(2d 및 ui)로 설정해야 합니다.
┕ 텍스처 패턴은 원하는 모양이 흰색, 주변은 투명으로 처리되어 있어야합니다
    (예시는 준비되어 있는 텍스처를 참고해주세요)
┕ 텍스처의 사이즈는 가로와 세로가 동일해야 합니다 (ex) 512x512, 1024x1024, 2048x2048
┕ 텍스처 패턴은 텍스처 중앙에 위치해야 합니다
    (보다 쉬운 조정을 위해서 중앙에 문양을 배치하는 것을 권장합니다)

Bloom texture
┕ 패턴 텍스처를 Bloom 형태의 텍스처로 덮는 형식입니다. (선택 사항)

▶ size
┕ 크기 기준은 텍스처의 중심입니다.

▶ rotation
┕ 회전 기준은 텍스처의 중심입니다.
┕ 0 에서 1일 때 1회전합니다.

▶ offset (position placement)
┕ 배경 질감 uv를 기준으로 배치됩니다.
┕ x 및 y로 z 및 w는 조정할 필요가 없습니다.

-----

▶ Emissive function of basic unity chan toon shader
┕ unity chan toon 셰이더의 기능을 참조하십시오.

Base Speed(Time): 실행되는 애니메이션의 시간 간격입니다. 단위 : 초
┕ 1 speed - 1초, 2 speed - 0.5초. (반비례)

Scroll U/X direction: U/X방향의 움직임 방향과 강도

Scroll V/Y direction: V/Y방향의 움직임 방향과 강도

Rotate around UV center : Base Speed가 1일 때 시계방향으로 1회전
┕ 스크롤 설정 만족 후 회전.

PingPong Move for Base: 설정된 방향으로 반복이동

-----

▶ Bloom function
 블룸 텍스처는 선택 사항입니다.
┕ 이 기능은 UTS 기능에 포함되어 있지 않습니다.

-----

▶ Scrolling with Time : Emission을 스크롤기능을 추가

Strength : 스크롤 적용 강도 적용

Blinking Emission : Emission의 주기설정

Min : 최소주기
Max : 최대주기
Velocity : 속도

Direction : 스크롤 되는 방향좌표

Width : 스크롤되는 Emissive의 범위
Velocity : 스크롤 속도
Interval : 스크롤 주기

-----

▶ ColorShift with Time: Emissive 텍스처에 Destination Color색상을 향해 색 변화

Destination Color: 결과적으로 도달하는 색상 HDR 가능

ColorShift Speed (Time): 색상 변화의 간격.
┕ 1 speed - 6초 간격 변화 (비례관계)

-----

▶ ViewShift of Color: 정면에서 정상적인 생상, 측면에서는 변화된 색상 표현

ViewShift Color: 측면에서의 색상설정

-----