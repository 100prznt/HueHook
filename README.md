## Project has no stable release yet :construction:

This project is in a early develop phase (10/09/2018).

---

# HueHook
Control your Philips Hue system with simple url calls, POST parameters are not needed.


## How to use

### Start the program
Run the HueHookServer.exe with 2 start parameters.
* parameter 1: IP of the hue-bridge
* parameter 2: authorized user-id

After successfully initialization the programm prints the server address (ip and port).

### Use the program

Call the urls described below, each url starts with the address (ip and port) and have some optional parameters:

|   |Value    |Light             |Group             |Scene             |
|---|---------|:----------------:|:----------------:|:----------------:|
|url|         |`/light.hue`      |`/group.hue`      |`/scene.hue`      |
|id |0 - 254  |:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|
|on |0, 1     |:heavy_check_mark:|:heavy_check_mark:|:x:               |
|hue|0 - 65535|:heavy_check_mark:|:heavy_check_mark:|:x:               |
|sat|0 - 254  |:heavy_check_mark:|:heavy_check_mark:|:x:               |
|bri|0 - 254  |:heavy_check_mark:|:heavy_check_mark:|:x:               |

#### Example
The url `http://192.168.0.1/light.hue?id=1&on=1&bri=127` means, switch on the light with id 1 and setup the brightness to a value of 127.


## Releases
This project build on the continuous integration (CI) platform [AppVeyor](https://www.appveyor.com/) and released in the [Release-Feed](https://github.com/rmmlr/HueHook/releases).

[![AppVeyor Build](https://img.shields.io/appveyor/ci/rmmlr/huehook.svg)](https://ci.appveyor.com/project/rmmlr/huehook)  
[![AppVeyor Tests](https://img.shields.io/appveyor/tests/rmmlr/HueHook/master.svg)](https://ci.appveyor.com/project/rmmlr/HueHook/build/tests)

[![GitHub Release](https://img.shields.io/github/release/rmmlr/huehook.svg)](https://github.com/rmmlr/huehook/releases/latest)  
[![GitHub (Pre-)Release](https://img.shields.io/github/release/rmmlr/huehook/all.svg)](https://github.com/rmmlr/huehook/releases) (Pre-)Release



## Credits

* **Elias Ruemmler** - *Initial work* - [rmmlr](https://github.com/rmmlr)

Under [Contributors](https://github.com/rmmlr/HueHook/contributors) you can see more project supporter.

### Open Source Project Credits

* [Q42.HueApi](https://github.com/Q42/Q42.HueApi) Bedienung der Hue-API

## License

This project (HueHook) is licensed under  [MIT License](http://www.opensource.org/licenses/mit-license.php "Read more about the MIT license form").  
Refer to [LICENSE](https://github.com/rmmlr/HueHook/blob/master/LICENSE.txt) for more information.

[![license](https://img.shields.io/github/license/rmmlr/HueHook.svg)](https://github.com/rmmlr/HueHook/blob/master/LICENSE.txt) 
