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

|   |Light             |Group             |Scene             |
|---|------------------|------------------|------------------|
|url|`/light.hue`      |`/group.hue`      |`/scene.hue`      |
|id |:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|
|on |:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|
|hue|:heavy_check_mark:|:heavy_check_mark:|:x:               |
|sat|:heavy_check_mark:|:heavy_check_mark:|:x:               |
|bri|:heavy_check_mark:|:heavy_check_mark:|:x:               |

#### Example
The url `http://192.168.0.1/light.hue?id=1&on=1&bri=127` means, switch on the light with id 1 and setup the brightness to a value of 127.
