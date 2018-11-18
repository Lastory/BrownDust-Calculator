# BrownDust-Calculator

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
3. If clicking the ***"Calculate!"*** button now, you can get the ***Remaining HP*** after Normal Attack and Additional Attack.

### Other
* To save your data, click the ***"Save"*** button.
* The archive will be automatically read when the application starts.

## Notice and Warning
* More characters and features are in plan.
* This project is still in its early stage, which means it will be updated frequently and not very stable. You can check the updates at  the [release page](https://github.com/Lastory/BrownDust-Calculator/releases).
* Updates may make the old archive incompatible.
* At this stage, some of the special skills are NOT effective (e.g. "additional ATK boost every turn"). Some of them are considered as a simple skill (e.g. Siegmund is always calculated as 100% HP.)
* If there is a problem, you can create an issue [here](https://github.com/Lastory/BrownDust-Calculator/issues).
* For bug report, it will be better if you can attach the "save.save" file for the configuration triggering the bug.
