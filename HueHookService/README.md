# HueHookService
Control your Philips Hue system with simple HTTP GET requests. POST parameters are not needed!


## How to use

### Install the program

TODO!

#### Installation

TODO!

#### Settings

TODO!

|Node        |            |         |Description                                                       |
|------------|------------|:-------:|------------------------------------------------------------------|
|Bridge      |IP address  |:warning:|IP address of the Philips Hue Bridge                              |
|            |User        |:warning:|authorized user on the Philips Hue Bridge\*                       |
|Local Server|Ip address  |         |                                                                  |
|            |Port        |         |port of the HueHookServer                                         |
|Whitelist   |Ip addresses|         |IP addresses of allowed client (each per line)                    |
|            |Enable      |:warning:|Enable or disable the complete whitelist                          |

:warning: required setting

An example you can find under [ExampleData/HueHookSettings.xml](https://github.com/rmmlr/HueHook/blob/master/ExampleData/HueHookSettings.xml).

\* to get an new username see the [Getting Started](https://www.developers.meethue.com/documentation/getting-started) article on the *hue developer program*.


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
Access is managed by a whitlist contains in [Settings](#Settings).

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