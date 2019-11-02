// Copyright 2019 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// [START translate_v3_translate_text_with_glossary_and_model]
using Google.Cloud.Translate.V3;
using System;

namespace GoogleCloudSamples
{
    public static class TranslateV3TranslateTextWithGlossaryAndModel
    {
        /// <summary>
        /// Translating Text with Glossary and Model
        /// </summary>
        /// <param name="modelId">Translation Model ID.</param>
        /// <param name="glossaryId">Translation Glossary ID.</param>
        /// <param name="text">The content to translate in string format</param>
        /// <param name="targetLanguage">Required. Target language code.</param>
        /// <param name="sourceLanguage">Optional. Source language code.</param>
        public static void TranslateTextWithGlossaryAndModelSample(string modelId, string glossaryId, string text,
            string targetLanguage, string sourceLanguage, string projectId, string location)
        {
            TranslationServiceClient translationServiceClient = TranslationServiceClient.Create();
            string modelPath = $"projects/{projectId}/locations/{location}/models/{modelId}";
            string glossaryPath = $"projects/{projectId}/locations/{location}/glossaries/{glossaryId}";

            TranslateTextRequest request = new TranslateTextRequest
            {
                Contents =
                {
                    // The content to translate in string format
                    text,
                },
                TargetLanguageCode = targetLanguage,
                ParentAsLocationName = new LocationName(projectId, location),
                Model = modelPath,
                GlossaryConfig = new TranslateTextGlossaryConfig
                {
                    // Translation Glossary ID.
                    Glossary = glossaryPath,
                },
                SourceLanguageCode = sourceLanguage,
                MimeType = "text/plain",
            };
            TranslateTextResponse response = translationServiceClient.TranslateText(request);
            // Display the translation for each input text provided
            foreach (Translation translation in response.GlossaryTranslations)
            {
                Console.WriteLine($"Translated text: {translation.TranslatedText}");
            }
        }
    }

    // [END translate_v3_translate_text_with_glossary_and_model]
}
