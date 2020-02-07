<h1 align="center">
  <br>
  <a href=""><img src="/img/bbuam.png" width="150"></a>
</h1>

<h4 align="center">Real time messaging between Unity and Microcontrollers</h4>

<p align="center">
  <img src="https://img.shields.io/github/license/PLVTON/bbuam">
	<a href="https://twitter.com/PLVTON"><img alt="Twitter" src="https://img.shields.io/twitter/url?label=Contact&style=social&url=https%3A%2F%2Ftwitter.com%2FPLVTON"></a>
</p>

<hr/>

**bbuam** is a solution to exchange data between Unity and microcontrollers (e.g., Arduino or Adafruit). This project started as a fork of [wrmhl](https://github.com/relativty/wrmhl).

<p align="center">
<img src="/img/mpu.gif" width="500">
</p>

## Getting Started
### Prerequisites
Any Unity version from 2018+, earlier versions haven't been tested. You can either use the [Unity Hub](https://unity3d.com/get-unity/download) or use their [Download Archive](https://unity3d.com/get-unity/download/archive).

The [Arduino IDE](https://www.arduino.cc/en/main/software) to upload the program to your microcontroller.

On the hardware side, you will need an Arduino-IDE compatible microcontroller with a usb-cable to link it to your computer.

### Installation
The easiest way to download *bbuam* is to download the [latest Unity package](/UnityPackages/bbuam.unitypackage) and import it in your project.

Otherwise, *bbuam* can be downloaded using [Git](https://git-scm.com/) with the following command:

```bash
$ git clone https://github.com/PLVTON/bbuam
```

Next up, you can build either [NativeUSB.ino](/Arduino/NativeUSB) or [SerialUSB.ino](/Arduino/SerialUSB) depending on your [microcontroller](https://www.arduino.cc/reference/en/language/functions/communication/serial/). If you don't know which one your microcontroller should use, only one of them will be able to build, the other will throw an error.

The demo scenes in the project will help you test and understand the Unity integration. Make sure to set the parameters such as the *COM port* accordingly.

If you have any other questions, feel free to reach out to me on [Twitter](https://twitter.com/PLVTON).

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details

## Acknowledgments
* [Relatvty](https://github.com/relativty) for making wrmhl.