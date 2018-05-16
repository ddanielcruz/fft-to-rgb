
Using FFT from audio to animate an analog RGB LED strip

In this project, we created a program that captures the audio coming from the sound card of a computer("Speakers" in the Windows Playback Devices tab), analyzes it using the Fast Fourier Transform(FFT) algorithm, converts data from specific frequencies previously configured by us and the amplitude of the sound in color patterns(RGB standard) and luminous intensity, sends the converted data via USB/Wi-Fi to an Arduino UNO connected in a circuit with MOSFETs, which activates the LED strip, according to the sound.
