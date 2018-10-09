# HueHook
Control your Philips Hue system with simple url calls, POST parameters are not needed.


## How to use

### Start the program
Run the HueHookServer.exe with 2 start parameters.
* 1. parameter: IP of the hue-bridge
* 2. parameter: authorized user-id

After successfully initialization the programm prints the server address (ip and port).

### Use the program

Call the urls described below, each url starts with the address (ip and port) and have some optional parameters:

|   |Light             |Group             |Scene             |
|---|------------------|------------------|------------------|
|url|`/light.hue`      |`/group.hue`      |`/scene.hue`      |
|id |:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|
|on |:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|
|hue|:heavy_check_mark:|:heavy_check_mark:|:x:               |
|sat|:heavy_check_mark:|:heavy_check_mark:|:x:               |
|bri|:heavy_check_mark:|:heavy_check_mark:|:x:               |

