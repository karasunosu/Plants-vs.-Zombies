# Cấu trúc thư mục dự án (Project Structure)

```text
Assets/
├── Scripts/
│   ├── Core/
│   │   ├── GameManager.cs
│   │   ├── EventBus.cs           # hệ thống event (Observer)        
│   │   └── ...
│   │
│   ├── Data/
│   │   ├── PlantData.cs          
│   │   ├── ZombieData.cs         
│   │   └── ...         
│   │
│   ├── Managers/
│   │   ├── GridManager.cs        # xử lý grid + placement
│   │   ├── ResourceManager.cs    # quản lý sun
│   │   ├── WaveManager.cs        # spawn zombie theo wave
│   │   ├── PoolManager.cs        # object pooling
│   │   └── ...
│   │
│   ├── Gameplay/
│   │   ├── Plants/
│   │   │   ├── Plant.cs          # base plant
│   │   │   └── PeaShooter.cs     # plant cụ thể
│   │   ├── Zombies/
│   │   │   └── Zombie.cs         # base zombie
│   │   └── Bullets/
│   │       └── Bullet.cs         # đạn
│   │
│   ├── States/
│   │   ├── IState.cs             # interface state
│   │   ├── Plant/
│   │   │   ├── PlantIdleState.cs
│   │   │   └── PlantAttackState.cs
│   │   └── Zombie/
│   │       ├── ZombieWalkState.cs
│   │       └── ZombieAttackState.cs
│   │
│   └── UI/
│       ├── Controllers/
│       │   └── UIController.cs   # xử lý input UI
│       └── Views/
│           └── GameUIView.cs     # hiển thị UI
│
├── Prefabs/
├── ScriptableObjects/
└── Scenes/
```

## Vai trò từng phần

### Core
- GameManager: quản lý trạng thái tổng thể game
- EventBus: giao tiếp giữa các hệ thống bằng event

### Data
- Chứa ScriptableObject
- Lưu:
  - damage
  - cost
  - speed
- Không chứa logic

### Managers
- Điều phối logic game
- Mỗi manager một nhiệm vụ:
  - GridManager: đặt plant
  - ResourceManager: quản lý sun
  - WaveManager: spawn zombie
  - PoolManager: tái sử dụng object


### Gameplay
- Object trong game:
  - Plant
  - Zombie
  - Bullet
- Chứa logic hành vi (attack, move…)

### States
- Quản lý trạng thái:
  - Idle
  - Attack
  - Walk
- Giúp tránh if-else phức tạp

### UI
- Controller: xử lý click
- View: hiển thị
- Không chứa logic gameplay

---

## Flow hoạt động chính

UI click
→ UIController

→ GameManager lưu lựa chọn

→ GridManager xử lý click
→ ResourceManager kiểm tra tài nguyên

→ spawn Plant (Gameplay)

→ EventBus emit

→ UI update

## Nguyên tắc thiết kế

- Mỗi class một nhiệm vụ
- Không gọi trực tiếp UI từ gameplay
- Không hardcode data
- Giao tiếp qua EventBus
- Manager chỉ điều phối, không làm gameplay

## Ghi nhớ nhanh

Core     = dùng chung  
Data     = dữ liệu  
Managers = điều phối  
Gameplay = đối tượng  
States   = hành vi  
UI       = giao diện  
