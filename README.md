<div align="center">
  <h1>
    :notes: <i>fft-to-rgb</i>
  </h1>

  <p>
    Animate a RGB Led strip using C# and Arduino
  </p>
</div>

## Overview

The idea of this project is to animate a RGB Led strip according to what music we are listening to. It basically captures the audio coming from the sound card of a computer, analyze it and send it to an Arduino which will animate the led.

It uses [Fast Fourier Transform (FFT)](https://en.wikipedia.org/wiki/Fast_Fourier_transform) algorithm to analyze the audio, converting it to data from specific frequencies previously configured by us and the amplitude of the sound in color patterns and luminous intensity.Then, send the converted data via USB/Wi-Fi to an [Arduino UNO](https://store.arduino.cc/usa/arduino-uno-rev3) connected in a circuit with [MOSFETs](https://en.wikipedia.org/wiki/MOSFET).

This project is no longer **maintained** because I don't work with C# anymore. Maybe some day I convert it to Node.js for study purposes, then I update this repository.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
