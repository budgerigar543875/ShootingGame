![タイトル画面](docs/images/title.png)

[7大ゲームの作り方を完全マスター！　ゲームアルゴリズムまるごと図鑑](https://direct.gihyo.jp/view/item/000000002620?category_page_id=all_items)を参考にしてUnityで作成したシューティングゲーム

アイテムを取得して自機の強化やエネルギーを回復しながら高得点を目指す

一定時間経過でステージクリアとなり無限にループする

プレイは[こちら](https://budgerigar543875.github.io/ShootingGame/)

![ゲーム画面](docs/images/stage.png)

### 自機
<table>
    <tr>
        <td><img src="docs/images/player.png"/></td>
        <td>スペースキー押下で弾を発射<br>Aキー押下でオート連射（再度Aキー押下で解除）<br>矢印キーで移動</td>
    </tr>
    <tr>
        <td><img src="docs/images/shot.png"/></td>
        <td>通常弾</td>
    </tr>
    <tr>
        <td><img src="docs/images/Piercing.png"/></td>
        <td>貫通弾</td>
    </tr>
</table>

### 敵機
<table>
    <tr>
        <td><img src="docs/images/enemy1.png"/></td>
        <td>1発当てると撃破可能<br>ステージが進むと耐久力UP</td>
    </tr>
    <tr>
        <td><img src="docs/images/enemy2.png"/></td>
        <td>2発当てると撃破可能<br>ステージが進むと耐久力UP</td>
    </tr>
    <tr>
        <td><img src="docs/images/enemy3.png"/></td>
        <td>3発当てると撃破可能<br>ステージが進むと耐久力UP</td>
    </tr>
    <tr>
        <td><img src="docs/images/enemy4.png"/></td>
        <td>撃破不能な敵<br>自機で体当たりすると撃破可能</td>
    </tr>
</table>

### アイテム
<table>
    <tr>
        <td><img src="docs/images/portion.png"/></td>
        <td>エネルギーを1つ回復する</td>
    </tr>
    <tr>
        <td><img src="docs/images/ramen.png"/></td>
        <td>同時発射弾数が増える<br>同時発射の最大は9発</td>
    </tr>
    <tr>
        <td><img src="docs/images/fire.png"/></td>
        <td>100発分貫通弾を発射できる<br>残弾有りで取得した場合は現在の残弾に+100</td>
    </tr>
</table>