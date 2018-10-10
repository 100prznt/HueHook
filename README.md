## Project under construction :construction:

This project is in a early develop phase (10/10/2018).

---

# HueHook
Control your Philips Hue system with simple HTTP GET requests. POST parameters are not needed!


## How to use

### Start the program
Run the HueHookServer.exe with 2 start parameters.
* parameter 1: IP of the hue-bridge
* parameter 2: authorized user-id

To obtain this parameters you can start the program with a shortcut. Append the parameters to the target path, e.g. `C:\path-to-program\HueHookServer.exe 192.168.0.1 my-app-key`.

After successfully initialization the programm prints the server address (ip and port).

### Use the program

Call the urls described below, each url starts with the address (ip and port) and have some optional parameters:

|Description       |Name|Value      |Light             |Group             |Scene             |
|------------------|----|-----------|:----------------:|:----------------:|:----------------:|
|:warning: URL     |    |`/*.hue`   |`/light.hue`      |`/group.hue`      |`/scene.hue`      |
|:warning: ID      |id  |0 - 254    |:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|
|On state          |on  |0, 1       |:heavy_check_mark:|:heavy_check_mark:|:x:               |
|Hue               |hue |0 - 65535  |:heavy_check_mark:|:heavy_check_mark:|:x:               |
|Saturation        |sat |0 - 254    |:heavy_check_mark:|:heavy_check_mark:|:x:               |
|Brightness        |bri |0 - 254    |:heavy_check_mark:|:heavy_check_mark:|:x:               |
|Color Temperature |ct  |153 - 500  |:heavy_check_mark:|:heavy_check_mark:|:x:               |

:warning: required parameter &nbsp; :heavy_check_mark: parameter allowed &nbsp; :x: parameter not allowed

The URL must at least be made up of the required parameters (:warning:). In addition, further allowed parameters (:heavy_check_mark:) can be appended. The parameters are appended to the URL as a query string (name/value pairs), see the example below.

#### Example
The url `http://192.168.0.1/light.hue?id=1&on=1&bri=127` means, switch on the light with id 1 and setup the brightness to a value of 127.

#### Security
Access is only allowed from the same computer on which the program is running.

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
