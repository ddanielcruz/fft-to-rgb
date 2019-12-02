# Using audio to animate a RGB LED strip

The idea of this project is to animate a RGB LED strip accordingly to what music we are listening to.

Basically, our algorithm captures the audio coming from the sound card of a computer, analyzes it using the [Fast Fourier Transform (FFT)](https://en.wikipedia.org/wiki/Fast_Fourier_transform) algorithm, converts data from specific frequencies previously configured by us and the amplitude of the sound in color patterns and luminous intensity and, finally, send the converted data via USB/Wi-Fi to an [Arduino UNO](https://store.arduino.cc/usa/arduino-uno-rev3) connected in a circuit with [MOSFETs](https://en.wikipedia.org/wiki/MOSFET).

## To Do

- [ ] Create a simple .NET library for working with this functionality
- [ ] Write a better little wiki explaining how it works
- [ ] Upload some medias showing it working

## License

MIT License.
