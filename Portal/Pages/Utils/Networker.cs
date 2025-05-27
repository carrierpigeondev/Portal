// SPDX-License-Identifier: Apache 2.0
//
// Copyright 2025 Carrier Pigeon Dev (carrierpigeon.dev@gmail.com).
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Portal
{
    [JsonSerializable(typeof(Dictionary<string, Dictionary<string, string>>))]
    public partial class UrlJsonContext : JsonSerializerContext { }

    internal class Networker
    {
        internal static readonly string[] separator = ["\r\n", "\n"];

        public static async Task<List<Dictionary<string, string>>?> FetchUrls()
        {
            System.Diagnostics.Debug.WriteLine("Fetch called.");

            List<Dictionary<string, string>> urlDictList = [];

            string? fetchUrl = Environment.GetEnvironmentVariable("PORTAL_FETCH_URL");
            System.Diagnostics.Debug.WriteLine($"PORTAL_FETCH_URL: {fetchUrl}");
            if (fetchUrl == null)
            {
                System.Diagnostics.Debug.WriteLine("PORTAL_FETCH_URL environment variable is not set.");
                return null;
            }

            try
            {
                using HttpClient client = new();
                string content = await client.GetStringAsync(fetchUrl);
                if (content.StartsWith('{'))
                {
                    urlDictList = ParseContentAsJSON(content);
                }
                else
                {
                    urlDictList = ParseContentAsPlaintext(content);
                }

            }
            catch (HttpRequestException e)
            {
                System.Diagnostics.Debug.WriteLine($"Error fetching URLs: {e.Message}");
                return null;
            }

            return urlDictList;
        }

        private static List<Dictionary<string, string>> ParseContentAsJSON(string content)
        {
            List<Dictionary<string, string>> _urlDictList = [];

            var deserializedContent = JsonSerializer.Deserialize(content, UrlJsonContext.Default.DictionaryStringDictionaryStringString);
            if (deserializedContent != null)
            {
                foreach (var entry in deserializedContent)
                {
                    Dictionary<string, string> urlEntry = new() { { "alias", entry.Key } };

                    foreach (var urlKVP in entry.Value)
                    {
                        urlEntry[urlKVP.Key] = urlKVP.Value.Trim();
                    }

                    _urlDictList.Add(urlEntry);
                }
            }

            return _urlDictList;
        }

        private static List<Dictionary<string, string>> ParseContentAsPlaintext(string content)
        {
            List<Dictionary<string, string>> _urlDictList = [];
            string[] lines = content.Split(separator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            foreach (var line in lines) {
                Dictionary<string, string> urlEntry = new()
                {
                    { "alias", line },
                    { "url", line }
                };

                _urlDictList.Add(urlEntry);
            }
            return _urlDictList;
        }
    }
}
