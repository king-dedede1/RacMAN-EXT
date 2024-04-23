# RacMAN EXT
A multi-purpose speedrun tool for PS3 games, on console and emulator, based on [racman](https://github.com/MichaelRelaxen/racman)

## Builidng
1. Use Visual Studio 2022
2. Clone the GitHub repository
3. Click Build > Build Solution

## Developing
Coming Soon™

## Using on PS3
You need a homebrew-enabled PS3 (either CFW or HEN) and webMAN MOD installed. Additionally you need the ratchetron server VSH plugin installed (this is not currently included with racman EXT)
1. Open RaCMAN EXT, in the dropdown menu select "PS3"
2. Enter your ps3's IP address and click 'connect'. (If you use HEN, make sure it is enabled first.)

Be sure to close racman before closing the game or turning off your ps3, or crashes/hardlocks may occur.

## Using on RPCS3
1. Open RPCS3 (don't start the game yet)
2. Click Configuration > IPC and check the box that says "Enable IPC Server". Note the IPC server port. Click "Save"
3. Start RaCMAN and select RPCS3 from the dropdown. Type the server port in the text box that says 'slot'
4. Click 'connect'

## Using on PCSX2
1. Enable advanced settings (Tools > Show advanced settings)
2. Open PCSX2 settings (System > Settings)
3. Under "Advanced", scroll down to the bottom and under "PINE Settings" check the box that says "Enable". Note the slot number (default is 28011)
4. If you have a game running, you'll have to restart it for the changes to apply.
5. Start RaCMAN and select PCSX2 from the dropdown. Type the slot number in the text box that says 'slot'
6. Click 'connect'

Please note that you'll need to reconnect racman if you switch games.

## Using autosplitters with LiveSplit

### 1.8.28 and before:
You'll need to install the [LiveSplit Server component](https://github.com/LiveSplit/LiveSplit.Server/releases) and add it to your layout.

### 1.8.29 and after:
Everything should work right out of the box... hopefully

## Credits & Acknowledgments
- [racman](https://github.com/MichaelRelaxen/racman) contributors
- [webMAN MOD](https://github.com/aldostools/webMAN-MOD) contributors
- [bordplate](https://github.com/bordplate), for the [Ratchetron](https://github.com/bordplate/Ratchetron) API
- Some icons from [aha-soft.com](http://www.small-icons.com/packs/16x16-free-application-icons.htm) and [softicons.com](https://www.softicons.com/system-icons/refresh-cl-icons-by-tpdk/game-controllers-icon) (free for non-commercial use, as far as I can tell) 
