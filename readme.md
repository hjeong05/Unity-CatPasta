# 캣 파스타 
- 2D 형식의 모바일 요리 게임 프로젝트 입니다.

# Screenshots
![image](https://user-images.githubusercontent.com/59278116/93563033-16389500-f9c2-11ea-9bcf-24cae4161048.png)
![image](https://user-images.githubusercontent.com/59278116/93563149-454f0680-f9c2-11ea-8411-978082cb1ac6.png)
![image](https://user-images.githubusercontent.com/59278116/93563155-47b16080-f9c2-11ea-91a3-ec41ea7ab81e.png)
![image](https://user-images.githubusercontent.com/59278116/93563191-5c8df400-f9c2-11ea-9382-c647e2a52e2a.png)
![image](https://user-images.githubusercontent.com/59278116/93563269-82b39400-f9c2-11ea-80b6-5189bd6bc83b.png)

게임시작화면, 상점 화면, 상점 화면 ( MY 화면 : 내가 산 재료 개수 확인 ) , 게임 화면, 정산 화면

# Tech/Framework used
## languages
- C#
## Tech
- Unity
- Visual Studio

### main functions
1. 재료 구매, 판매 기능
2. 요리 기능
3. 게임 설정 기능 ( bgm, 효과음 조절, 게임 나가기 )
4. 이동 및 음식 서빙 기능
5. PlayerPrefs 사용한 게임 저장

### features
- 등장 손님마다 특징이 다릅니다.

![image](https://user-images.githubusercontent.com/59278116/93563994-eee2c780-f9c3-11ea-9370-262e25d87019.png)

1) 강아지 - 일반적인 강아지 손님.
2) 토끼 - 일반적인 토끼 손님.
3) 펭귄 - 일반적인 펭귄 손님.
4) 사자	 - 성격이 급해 음식을 주문하고 기다리는 시간이 다른 손님들에 비해 적습니다. 그러나 사자 손님을 만족시킬 경우 음식 값의 2배를 줍니다.
5) 거북이 – 성격이 느긋하여 음식을 주문하고 기다리는 시간이 다른 손님들에 비해 많습니다. 거북이 손님이 많을수록 가게 테이블 회전율이 낮아져 돈을 벌기 힘듬니다. 
6) 안경토끼 – 성격이 깐깐하여 음식을 받고 먹는 시간이 오래 걸립니다. 자신의 만족에 따라 음식 가격의 돈을 ±10% 안경토끼 마음대로 줍니다.
