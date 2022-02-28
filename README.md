
# Google-Wavenet-Synthesised-Phrase-Downloader

A simple winforms application for downloading and saving .wav files straight from google
cloud's speech synthesis powered by the Wavenet algorithm.

I've put this together for my wife since she's making sound-based flashcards in Anki to
study a foreign language (polish in this case).





## Screenshots

![App Screenshot](https://i.imgur.com/ce5YwMg.png)


## Installation

Whether you run it from IDE or build an executable you will need to find a Key
folder in the main directory. Follow these steps to setup your API on google's console:

https://cloud.google.com/text-to-speech/docs/libraries

Downloaded the API key .json file and place it in the Key folder or replace the code and
and add key in *env variable* manually.

To change the language settings adjust the language name and code in the WordDownloaderSaver class here:

```cs
var voiceSelection = new VoiceSelectionParams
                {
                    LanguageCode = "pl-PL",
                    Name = "pl-PL-Wavenet-B",
                };
        
```
According to the table at:
https://cloud.google.com/text-to-speech/docs/voices



    
## Contact

- Adrian Sieradzki
contact@exmachinasoft.com

