# HueHook
Control your Philips Hue system with simple HTTP GET requests. POST parameters are not needed!

### HueCmd
You can find a seperate [README.md](HueCmd/README.md) for `HueCmd`, now. Browse to [HueCmd/README.md](HueCmd/README.md)

## How to use

### Start the program

#### Since version [1.0.19](https://github.com/100prznt/HueHook/releases/tag/1.0.19)
Before the first program start, a settings file must be created. You can modify the example file, found in [ExampleData/HueHookSettings.xml](https://github.com/100prznt/HueHook/blob/master/ExampleData/HueHookSettings.xml). The file must be in the same directory as the program and named `HueHookSettings.xml`. See next point [Settings](#settings) for detailed informations.

#### Up to version [1.0.18](https://github.com/100prznt/HueHook/releases/tag/1.0.18)
Run the HueHookServer.exe with 2 start parameters.
* parameter 1: IP of the hue-bridge
* parameter 2: authorized username to access the bridge*

To obtain this parameters you can start the program with a shortcut. Append the parameters to the target path, e.g. `C:\path-to-program\HueHookServer.exe 192.168.0.1 my-app-key`.

### Settings
The program settings are stored in a xml-formated file, named `HueHookSettings.xml`.
This file have one root node `<HueHookSettings>`, which have several child nodes.

|Node               |         |Description                                                                         |
|-------------------|:-------:|------------------------------------------------------------------------------------|
|`<BridgeIp>`       |:warning:|IP address of the Philips Hue Bridge                                                |
|`<BridgeUsername>` |:warning:|authorized user on the Philips Hue Bridge*                                          |
|`<LocalServerIp>`  |         |                                                                                    |
|`<LocalServerPort>`|         |port of the HueHookServer                                                           |
|`<WhiteList>`      |:warning:|this node contains child nodes (`<IpAddress>`) for each IP address of allowed client|

:warning: required setting

An example you can find under [ExampleData/HueHookSettings.xml](https://github.com/100prznt/HueHook/blob/master/ExampleData/HueHookSettings.xml).

\* to get an new username see the [Getting Started](https://developers.meethue.com/login/) article on the *hue developer program*.


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
* Since version [1.0.14](https://github.com/100prznt/HueHook/releases/tag/1.0.14) access is only allowed from the same computer on which the program is running.
* Since version [1.0.15](https://github.com/100prznt/HueHook/releases/tag/1.0.15) access is managed by a whitlist file, this file contains whitlisted ip-addresses (each per line). The file must be in the same directory as the program and named `ip-whitelist.txt`. An example you can find under [ExampleData](https://github.com/100prznt/HueHook/blob/master/ExampleData).
* Since version [1.0.19](https://github.com/100prznt/HueHook/releases/tag/1.0.19) the whitelist is defined in the settings file. See [Since version 1.0.19](https://github.com/100prznt/HueHook/blob/develop/README.md#since-version-1019).

## Releases
This project build on the continuous integration (CI) platform [AppVeyor](https://www.appveyor.com/) and released in the [Release-Feed](https://github.com/100prznt/HueHook/releases).

[![AppVeyor Build](https://img.shields.io/appveyor/ci/100prznt/huehook.svg)](https://ci.appveyor.com/project/100prznt/huehook)  
[![AppVeyor Tests](https://img.shields.io/appveyor/tests/100prznt/HueHook/master.svg)](https://ci.appveyor.com/project/100prznt/HueHook/build/tests)

[![GitHub Release](https://img.shields.io/github/release/100prznt/huehook.svg)](https://github.com/100prznt/huehook/releases/latest)  
[![GitHub (Pre-)Release](https://img.shields.io/github/release/100prznt/huehook/all.svg)](https://github.com/100prznt/huehook/releases) (Pre-)Release



## Credits

* **Elias Ruemmler** - *Initial work* - [100prznt](https://github.com/100prznt)

Under [Contributors](https://github.com/100prznt/HueHook/contributors) you can see more project supporter.

### Open Source Project Credits

* [Q42.HueApi](https://github.com/Q42/Q42.HueApi) C# helper library to talk to the Philips Hue bridge 

## License

This project (HueHook) is licensed under  [MIT License](http://www.opensource.org/licenses/mit-license.php "Read more about the MIT license form").  
Refer to [LICENSE](https://github.com/100prznt/HueHook/blob/master/LICENSE.txt) for more information.

[![license](https://img.shields.io/github/license/100prznt/HueHook.svg)](https://github.com/100prznt/HueHook/blob/master/LICENSE.txt) 
