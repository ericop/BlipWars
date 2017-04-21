# BlipWars
Unity 2D RTS game that's simple yet interesting!

![image](https://cloud.githubusercontent.com/assets/5218249/24610557/0051d80a-184d-11e7-813b-b8b596375e9c.png)

## How to Install This Amazing, Free Game

### On Android
1. Change your browser setting check the box to enable **Request Desktop Site [x]**
2. Visit https://github.com/ericop/BlipWars/blob/master/builds/BlipWars1.0.0.apk
3. Click the **Download**
3. If asked *Do you want to Download BlipWars1.0.0.apk?* Select *Yes* or *Download*
4. After Downloading Open the .apk file (can be done by clicking on the Notification) and click **INSTALL**
4. During the installation process for BlipWars, follow the on-screen prompts to enable *Unknown Sources*.
  - To access the *Unknown Sources* setting directly, press the menu icon or button from the *Home* screen and tap **Settings**. Select **Security** (Android OS 4.0+). You may need to scroll down to see the *Unknown Sources* setting.

### On Windows
1. From https://github.com/ericop/BlipWars click **Cone or download** then **Download ZIP** (File includes all builds, etc. so its over 200MB)
2. Unzip BlipWars-master.zip to something like `C:\Users\{YourWindowsUserName}\Downloads\BlipWars-master\`
3. Go into `C:\Users\{YourWindowsUserName}\Downloads\BlipWars-master\BlipWars-master\builds` and double click **BlipWars1.0.0.exe**
  - Note: For Windows builds, it needs the **BlipWars1.0.0_Data** directroy and all that's in it and the **BlipWars1.0.0.exe** to function. If those are all you want you can drag them both to your Desktop, etc. and the **BlipWars1.0.0.exe** should still play just fine and you can delete the rest of the files in `C:\Users\{YourWindowsUserName}\Downloads\BlipWars-master`

## Game play

This is a 2 player local, or 1 player verse AI game where each player controls a base. Each base has 10 Hit Points, after 10 hits by attackers, it's dead and you lose to your worhty oponenent.

### 2 Player Mode
- To control the Good Guy Base 
  - Click the Add Good Guy Worker button (or hit `A`), costing 25 energy. *Each return trip from the `Energy Well` you get 10 energy.*
  - Click the Add Good Guy Worker button (or hit `Z`), costing 25 energy. *You must have at least 100 energy to build attackers.*
- To control the Bad Guy Base 
  - Click the Add Bad Guy Worker button (or hit `UP`), costing 25 energy. *Each return trip from the `Energy Well` you get 10 energy.*
  - Click the Add Bad Guy Worker button (or hit `DOWN`), costing 25 energy. *You must have at least 100 energy to build attackers.*

### 1 Player verse AI Mode
- There is a box in the bottom right where you determine how the game will auto-spend your energy
  - Click in the top-right to build *attacker* automatically (everytime you have over 100 energy they will be build and cost 25 energy)
  - Click in the bottom-left to build *workers* automatically
  - Note the option to build *snipers* and *taskMasters* is not yet included in the game
  - Click the *Save Energy* white box to not auto-spend energy and save up for a big attack, etc.

## Games Assets

- Music is by *FoxSynergy* (http://opengameart.org/content/planetrise) and by *PetterTheSturgeon* (http://opengameart.org/content/sci-fi-electronic-lost-signal)
- EricOP https://github.com/ericop for other graphics and sound effects
- This game BlipWars draws inspiration from all the sci-fi RTS games before it. Thanks for inspiring me ;)


## To Do
- [x] Add 1 player mode vs AI
- [x] Add *Pin Selector* to replace buttons for building new units
- [ ] Add project landing page with [cool theme](http://themes.gohugo.io/github-project-landing-page/)
- [ ] Add first two specialists, Researcher and Sniper
- [ ] Add other specialists as time allows
