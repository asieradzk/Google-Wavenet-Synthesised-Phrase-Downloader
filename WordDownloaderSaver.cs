using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.TextToSpeech.V1;

namespace WordsDownloader
{
    static class WordDownloaderSaver
    {
        public static void downloadsound(string filePath, string text)
        {
            new Thread(() =>
            {

                var client = TextToSpeechClient.Create();



                // The input to be synthesized, can be provided as text or SSML.
                var input = new SynthesisInput
                {
                    Text = text
                };

                // Build the voice request.
                var voiceSelection = new VoiceSelectionParams
                {
                    LanguageCode = "pl-PL",
                    Name = "pl-PL-Wavenet-B",
                };

                // Specify the type of audio file.
                var audioConfig = new AudioConfig
                {
                    AudioEncoding = AudioEncoding.Linear16
                };

                // Perform the text-to-speech request.
                var response = client.SynthesizeSpeech(input, voiceSelection, audioConfig);

                // Write the response to the output file.
                using (var output = File.Create(filePath + @"\" + RemoveDiacritics2(text) + ".wav"))
                {
                    response.AudioContent.WriteTo(output);
                }

                string RemoveDiacritics(string s)
                {
                    string asciiEquivalents = Encoding.ASCII.GetString(
                                 Encoding.GetEncoding("utf-32").GetBytes(s)
                             );

                    return asciiEquivalents;
                }

                string RemoveDiacritics2(string text)
                {
                    var normalizedString = text.Normalize(NormalizationForm.FormD);
                    var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

                    for (int i = 0; i < normalizedString.Length; i++)
                    {
                        char c = normalizedString[i];
                        var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                        if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                        {
                            stringBuilder.Append(c);
                        }
                    }

                    return stringBuilder
                        .ToString()
                        .Normalize(NormalizationForm.FormC);
                }
            }).Start();
        }
    }
}
