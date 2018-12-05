# BrownDust-Calculator

* [English](#intro)
* [中文](#介绍)
* [日本語](#紹介)

## Intro
This a damage calculator for Brown Dust (Data based  on Japan / Taiwan / Asia servers).  
Relies on .NET framework  4.7.1 or later version. You can [download it here](https://www.microsoft.com/net/download/dotnet-framework-runtime).

## How to Use

### Prepare  
1. Download the latest version of ***"BrownDust-Calculator.exe"*** at the [release page](https://github.com/Lastory/BrownDust-Calculator/releases).  
2. It is recommended to put the EXE file into a separate folder because it will create a ***"save.save"*** file.  
3. After opening the EXE file, you can change the language by choosing your language at the upper right corner.

### Attacking side
1. Choose your Supporters and Attackers at the ***"Character"*** column in two upper tables. (At this stage, Supporters are all calculated as **full-class** - Star.6 Lv.Max Awakened.)
2. Choose the skill levels for them at the ***"Skill"*** column. (A characters may not have full selections from +0 to +10 if he/she is low-star or some skill levels make no difference.)
3. Select the supporters in effect.
4. Input your attackers' stats.
5. You will get the ***Pure Damage*** every attackers can cause in Normal Attack,  Additional Attack and in total.
6. The calculator will show the most extreme cases with probabilities at the first line (e.g. ***"500 40% | 1500 30%"*** means the lowest Pure Damage is 500 at 40% chances while the highest is 1500 at 30% chances), and the expectation at the second. If there is only one possibility it will be directly shown. (There may be some discrepancies because the data in the game is of limited precision. You may see 0% which means a very low probability because of rounding.)

### Defending side
1. Input your Defenders' stats. Name them whatever you like. (Formula like ***"50+43\*171.3%"*** is legitimate for defenders with supporters' barrier. Notice that there should be ***NO Spaces!*** )
2. Select an attacker.
3. Now you can also get the ***Remaining HP*** after Normal Attack and Additional Attack.

### Other
* To force a refresh of calculation, click the ***"Calculate!"*** button
* To save your data, click the ***"Save"*** button.
* The archive will be automatically read when the application starts.

## Notice and Warning
* More characters and features are in plan.
* This project is still in its early stage, which means it will be updated frequently and not very stable. You can check the updates at the [release page](https://github.com/Lastory/BrownDust-Calculator/releases).
* Updates may make the old archive incompatible.
* At this stage, the application may crash if the input format is incorrect. A better error-notification is in project.
* At this stage, some of the special skills are NOT effective while some of them are considered as a simple skill. Check [Skill exception](#skill-exception) for detail.
* If there is a problem, you can create an issue [here](https://github.com/Lastory/BrownDust-Calculator/issues).
* For bug report, it will be better if you can attach the "save.save" file for the configuration triggering the bug.

## Appendix

### Skill exception
* Ignored: Additional XXX boost **every turn**  
Affected: Edin
* Ignored: Additional DMG based on **Taunt/Concentrated Fire** skill  
Affected: Ventana
* Ignored: Remove Barrier  
Affected: Rafina, Alche
* Simplified: Additional DMG based on **Remaining HP Rate**  
Affected: Siegmund(always calculated as 100% HP)
* Simplified: Additional DMG based on **HP Loss Rate**  
Affected: Edin(always calculated as 65% HP, or 35% Lost)



## 介绍
这是一个用于Brown Dust的伤害计算器（数据基于日/台/亚服）。  
依赖 .NET framework  4.7.1 或更新版本，您可以 [在这里下载](https://www.microsoft.com/net/download/dotnet-framework-runtime)。

## 使用方式

### 准备工作  

1. 在[发布页](https://github.com/Lastory/BrownDust-Calculator/releases)下载最新的 ***BrownDust-Calculator.exe*** 。
2. 您最好将下载的exe文件放入一个单独的文件夹，因为它会创建一个 ***save.save*** 存档文件。  
3. 打开exe文件后，您可以在右上角的下拉菜单选择您的语言。

### 攻击侧
1. 在靠上的两张表格的“**角色**”列选择您要计算的攻击角色和支援角色。（现阶段，支援角色全部以满破计算——六星、最高等级、已觉醒）
2. 在“**技能**”列选择他们的技能等级。（有的角色可能没有+0到+10的全部选项，可能是因为他是低星或者缺失的等级不造成效果影响）
3. 选择生效的支援角色。
4. 输入攻击角色的数据。
5. 将会显示攻击角色在基础攻击和追伤中造成的 **纯粹伤害** ，以及总和。
6. 伤害显示的第一行列出了两种最极端的情况及其可能性 (例： ***"500 40% | 1500 30%"*** 代表有40%概率出现最低伤500，30%最高伤1500)，第二行列出的伤害的期望。如果只有一种可能性则会被直接显示。（可能会存在误差，因为游戏内能获取的数据精度有限。可能性可能会显示0%，因为存在四舍五入）

### 防御侧
1. 输入防御角色的数据。给他们随便起个名字就行。（您可以使用 ***"50+43\*171.3%"*** 这样的算式以计算支援提供的防护罩，请注意 **不要加入空格**）。
2. 选择一个攻击角色。
3. 还将会显示基础攻击和追伤后防御角色的 **剩余血量** 。

### 其他
* 点击“**计算**”按钮以强制刷新计算
* 点击“**保存**”按钮以存储配置。
* 应用启动时会自动读取存档。

## 注意事项
* 英文版以外的说明可能不会随每个版本更新，您可以参阅[英文说明](#intro)以获取最新信息。
* 更多角色和功能在更新计划上。
* 这个项目仍然处于开发早期，可能会更新十分频繁并且不太稳定。您可以在[发布页](https://github.com/Lastory/BrownDust-Calculator/releases)检查更新。
* 更新后可能不兼容旧版本的存档。
* 现阶段，如果输入了错误的格式，应用可能会直接报错退出，更好的报错机制在开发计划上。
* 现阶段，有些特殊技能效果被忽略了，有些被条件简化了，您可以在[技能例外](#技能例外)查看详情。
* 如果遇到问题，您可以[在这里提交](https://github.com/Lastory/BrownDust-Calculator/issues)。
* 如果想要报告bug，引发bug的配置的存档可能会很有帮助。

## 附录

### 技能例外
* 忽略： **每回合** XXX上升  
将会影响：黑剑
* 忽略：基于 **挑衅/锁定** 的追伤  
将会影响：妖刀
* 忽略：清除护盾  
将会影响：锤妹，机械盾
* 简化： **剩余血量比例** 依存追伤  
将会影响：白剑（总是以100%血量计算）
* 简化： **损失血量比例** 依存追伤  
将会影响：黑剑（总是以失去35%血量计算）

## 紹介
Brown Dust用のダメージ計算ツールです（データは日本/台湾/アジアサーバーに基づいている）。  
NET Framework 4.7.1 (以降のバージョン)に依存します。[ここでダウンロード](https://www.microsoft.com/net/download/dotnet-framework-runtime)できます。

## 使用方法

### 準備作業

1. [リリースページ](https://github.com/Lastory/BrownDust-Calculator/releases)で最新の ***BrownDust-Calculator.exe*** をダウンロード。
2. ダウンロードしたexeファイルを1つのフォルダに入れたほうがいいです。アーカイブ ***save.save*** を作成しますから。  
3. exeファイルを開けたら、右上に言語を選択できます。

### 攻撃側
1. 上の2枚の表「**キャラ**」列で、攻撃キャラと支援キャラを選択します。（現段階では、支援キャラはすべてfull-classとされている——星6+Lv.Max+覚醒）
2. スキルレベルを「**スキル**」列で選択する。（すべてのオプションがないかもしれません）
3. 有効な支援役を選ぶ。
4. 攻撃キャラのステータスを入力します。
5. 基本攻撃と追加攻撃による **純粋なダメージ** 、そしてそれらの総和を表示します。
6. 傷害表示の第1行は、2つの最も極端な状況とその確率を書き出した。 (例： ***"500 40% | 1500 30%"*** 40%の確率で最低500純粋なダメージ出ます、30%で最高1500)、2行目はダメージの期待。可能性が一つだけなら、直接表示される。（誤差が存在する可能性があり、ゲーム内で取得できるデータの精度には限られているから。確率は0%を表示することができてなら、四捨五入が存在するだから）

### 防御側
1. 防御役のステータスを入力します。名前はなんでもいいです。（ ***"50+43\*171.3%"*** のような計算式で支援バリアを表示することができます。 **スペースなし** で気をつけてください。）
2. 攻撃キャラ一人を選ぶ。
3. 基本攻撃と追加攻撃後の防御役の **残りのHP** も表示されます。

### その他
* 「**計算**」ボタンをクリックして、コンピューティング結果を強制的に再表示します。
* 「**保存**」ボタンをクリックして配置を保存する。
* 起動時に、アーカイブを自動的に読み取ります。

## 注意事項
* 英語版以外の説明は、すべてのバージョンによって更新されない可能性があります。[英語の説明](#intro)によって最新の情報を取得することができます。
* 他のキャラクターや機能を追加する予定です。
* このプロジェクトはまだ開発中で、かなり頻繁に更新される、不安定になる可能性があります。[リリースページ](https://github.com/Lastory/BrownDust-Calculator/releases)で更新を確認できます。
* 更新された後には、古いバージョンの保存に対応しない可能性があります。
* 現段階では、エラーのフォーマットを入力すれば、アプリケーションが崩れてしまう可能性があります。より良いメカニズムを追加する予定です。
* 現段階では、一部の特殊なスキルの効果は無視されて、一部は条件によって簡略化された。[スキルの例外](#スキルの例外)で詳細を調べることができます。
* もし問題があったら、[ここで提出](https://github.com/Lastory/BrownDust-Calculator/issues)してください。
* バグを報告したい場合には、バグを誘発するの配置のアーカイブが助けられるかもしれません。

## 付録

### スキルの例外
* 無視する： **毎ターン** XXX追加で上昇  
関連するキャラ：エディン
* 無視する： **挑発/ロックオン** タイプスキル応じて追加ダメージ  
関連するキャラ：ヴェンタナ
* 無視する：バリア無効化  
関連するキャラ：アーチェ、ラフィーナ
* 簡素化する： **残りHPの割合** 応じて追加ダメージ  
関連するキャラ：シグムンド（いつも100%のHPになる）
* 簡素化する： **失ったHPの割合** 応じて追加ダメージ  
関連するキャラ：エディン（いつも65%のHPになる――35%失った）

