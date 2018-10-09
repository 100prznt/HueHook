# HueHook
Control your Philips Hue system with simple url calls, POST parameters are not needed.


## How to use

### Start the program
Run the HueHookServer.exe with 2 start parameters.
* 1. parameter: IP of the hue-bridge
* 2. parameter: authorized user-id

After successfully initialization the programm prints the server address (ip and port).

### Use the program

#### Light
To control a single light you must call 'http://192.168.0.1/light.hue'
