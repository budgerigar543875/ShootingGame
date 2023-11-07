![タイトル画面](docs/images/title.png)

[7大ゲームの作り方を完全マスター！　ゲームアルゴリズムまるごと図鑑](https://direct.gihyo.jp/view/item/000000002620?category_page_id=all_items)を参考にしてUnityで作成したシューティングゲーム

アイテムを取得して自機の強化やエネルギーを回復しながら高得点を目指す

一定時間経過でステージクリアとなり無限にループする

![ゲーム画面](docs/images/stage.png)

### 自機

|  |  |
|:-----------|:---------|
| ![自機1](docs/images/player.png) | スペースキー押下で弾を発射<br>Aキー押下でオート連射（再度Aキー押下で解除）<br>矢印キーで移動 |
| ![自機2](docs/images/shot.png) | 通常弾 |
| ![自機3](docs/images/Piercing.png) | 貫通弾 |

### 敵機

|  |  |
|:-----------|:---------|
| ![敵機1](docs/images/enemy1.png) | 1発当てると撃破可能<br>ステージが進むと耐久力UP |
| ![敵機2](docs/images/enemy2.png) | 2発当てると撃破可能<br>ステージが進むと耐久力UP |
| ![敵機3](docs/images/enemy3.png) | 3発当てると撃破可能<br>ステージが進むと耐久力UP |
| ![敵機4](docs/images/enemy4.png) | 撃破不能な敵<br>自機で体当たりすると撃破可能 |

### アイテム

|  |  |
|:-----------|:---------|
| ![アイテム1](docs/images/portion.png) | エネルギーを1つ回復する |
| ![アイテム2](docs/images/ramen.png) | 同時発射弾数が増える<br>同時発射の最大は9発 |
| ![アイテム3](docs/images/fire.png) |100発分貫通弾を発射できる<br>残弾有りで取得した場合は現在の残弾に+100 |
