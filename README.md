# SaveTheVid


### Description
SaveTheVid is a simple and lightweight graphical user interface for the popular [youtube-dl](https://github.com/rg3/youtube-dl), written in C#.

It allows you to download video/audio from [supported sites](https://rg3.github.io/youtube-dl/supportedsites.html) in desired quality and file format.


##### Features
* The URLs are added to a queue and the downloads start automatically.
* Each URL can be added to queue with different settings (quality and file format), as well as a different output directory.
* Allows updating youtube-dl with a click of a button.


##### Screenshots
![savethevid usage](https://user-images.githubusercontent.com/44162363/50375875-61ffb400-060d-11e9-9fb0-3c8c76fff9d1.gif)
![savethevid screenshot](https://user-images.githubusercontent.com/44162363/50375877-6d52df80-060d-11e9-97be-656dcc3a8d7c.png)


### Downloads
[Windows Installer](https://github.com/elgaspar/SaveTheVid/releases/download/untagged-6c0388a21323ac7b464b/SaveTheVid-v1.0.0-setup.zip)

[Windows Portable](https://github.com/elgaspar/SaveTheVid/releases/download/untagged-6c0388a21323ac7b464b/SaveTheVid-v1.0.0-portable.zip)


### Installation
In order to be able to set custom quality and file format you have to intall [FFmpeg](https://ffmpeg.org/). You can download the latest build of FFmpeg from [here](https://ffmpeg.zeranoe.com/builds/). Just copy `ffmpeg.exe` and `ffprobe.exe` into `"Resources/bin"` folder in the directory you installed SaveTheVid. Something similar to: `C:\Program Files\elgaspar\SaveTheVid\Resources\bin`

You can still use SaveTheVid without FFmpeg but in this case you can only download videos with default quality and format.


### License
This software is licensed under the [MIT License](https://github.com/elgaspar/SaveTheVid/blob/master/LICENSE).
