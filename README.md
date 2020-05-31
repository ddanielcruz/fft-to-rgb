<div align="center">
  <h1>
    :notes: <i>fft-to-rgb</i>
  </h1>

  <p>
    Animate a RGB Led strip using C# and Arduino
  </p>
</div>

The idea of this project is to animate a RGB Led strip according to what music we are listening to. It basically captures the audio coming from the sound card of a computer, analyze it using the [Fast Fourier Transform (FFT)](https://en.wikipedia.org/wiki/Fast_Fourier_transform) algorithm, converts data from specific frequencies previously configured by us and the amplitude of the sound in color patterns and luminous intensity and, finally, send the converted data via USB/Wi-Fi to an [Arduino UNO](https://store.arduino.cc/usa/arduino-uno-rev3) connected in a circuit with [MOSFETs](https://en.wikipedia.org/wiki/MOSFET).

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
