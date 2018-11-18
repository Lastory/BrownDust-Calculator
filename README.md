# BrownDust-Calculator

* [English](#intro)
* [中文](#介绍)

## Intro
This a damage calculator for Brown Dust.

## How to Use

### Prepare  
1. Download the latest version of ***"BrownDust-Calculator.exe"*** at the [release page](https://github.com/Lastory/BrownDust-Calculator/releases).  
2. It is recommended to put the EXE file into a separate folder because it will create a ***"save.save"*** file.  
3. After opening the EXE file, you can change the language by choosing your language at the upper right corner. (At this stage, only the characters' names are translated.)

### Attacking side
1. Choose your Supporters and Attackers at the ***"Character"*** column in two upper tables. (At this stage, Supporters are all calculated as **full-class** - Star.6 Lv.Max Awakened.)
2. Choose the skill levels for them at the ***"Skill"*** column. (A characters may not have full selections from +0 to +10 if he/she is low-star or some skill levels make no difference.)
3. Input your attackers' stats.
4. Select the supporters in effect.
5. If clicking the ***"Calculate!"*** button now, you will get the ***Pure Damage*** every attackers can cause in Normal Attack,  Additional Attack and in total.
6. The calculator will show the most extreme cases with probabilities at the first line (e.g. ***"500 40% | 1500 30%"*** means the lowest Pure Damage is 500 at 40% chances while the highest is 1500 at 30% chances), and the expectation at the second. If there is only one possibility it will be directly shown. (There may be some discrepancies because the data in the game is of limited precision. You may see 0% which means a very low probability because of rounding.)

### Defending side
1. Input your Defenders' stats. Name them whatever you like. (At this stage, you may need to input the supporters' effect at the defending side.)
2. Select an attacker.
3. If clicking the ***"Calculate!"*** button now, you can also get the ***Remaining HP*** after Normal Attack and Additional Attack.

### Other
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
* Ignored: Additional XXX boost *every turn*  
Affected: Edin
* Ignored: Additional DMG based on *Taunt/Concentrated Fire* skill  
Affected: Ventana
* Ignored: Remove Barrier  
Affected: Rafina, Alche
* Simplified: Additional DMG based on *Remaining HP Rate*  
Affected: Siegmund(always calculated as 100% HP)
* Simplified: Additional DMG based on *HP Loss Rate*  
Affected: Edin(always calculated as 65% HP, or 35% Lost)



## 介绍
这是一个用于Brown Dust的伤害计算器

## 使用方式

### 准备工作  

1. 在[发布页](https://github.com/Lastory/BrownDust-Calculator/releases)下载最新的 ***BrownDust-Calculator.exe*** 。
2. 您最好将下载的exe文件放入一个单独的文件夹，因为它会创建一个 ***save.save*** 存档文件。  
3. 打开exe文件后，您可以在右上角的下拉菜单选择您的语言。（现阶段只有角色名有多语言翻译）

### 攻击侧
1. 在靠上的两张表格的 ***Character*** 列选择您要计算的攻击角色和支援角色。（现阶段，支援角色全部以满破计算——六星、最高等级、已觉醒）
2. 在 ***Skill*** 列选择他们的技能等级。（有的角色可能没有+0到+10的全部选项，可能是因为他是低星或者缺失的等级不造成效果影响）
3. 输入攻击角色的数据。
4. 选择生效的支援角色。
5. 如果现在点击 ***Calculate!*** 按钮，您可以得到攻击角色在基础攻击和追伤中造成的 **纯粹伤害** ，以及总和。
6. 伤害显示的第一行列出了两种最极端的情况及其可能性 (例： ***"500 40% | 1500 30%"*** 代表有40%概率出现最低伤500，30%最高伤1500)，第二行列出的伤害的期望。如果只有一种可能性则会被直接显示。（可能会存在误差，因为游戏内能获取的数据精度有限。可能性可能会显示0%，因为存在四舍五入）

### 防御侧
1. 输入防御角色的数据。给他们随便起个名字就行。（现阶段，您可能需要在输入时手动加上防御侧的支援效果）。
2. 选择一个攻击角色。
3. 如果现在点击 ***"Calculate!"*** 按钮，您还可以得到基础攻击和追伤后防御角色的 **剩余血量** 。

### 其他
* 点击 ***Save*** 按钮以存储配置。
* 应用启动时会自动读取存档。

## 注意事项
* 更多角色和功能在更新计划上。
* 这个项目仍然处于开发早期，可能会更新十分频繁并且不太稳定。您可以在[发布页](https://github.com/Lastory/BrownDust-Calculator/releases)检查更新。
* 更新后可能不兼容旧版本的存档。
* 现阶段，如果输入了错误的格式，应用可能会直接报错退出，更好的报错机制在开发计划上。
* 现阶段，有些特殊技能效果被忽略了，有些被条件简化了，您可以在 [技能例外](#技能例外) 查看详情。
* 如果遇到问题，您可以在[这里](https://github.com/Lastory/BrownDust-Calculator/issues)提交。
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
