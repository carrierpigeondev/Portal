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

using Microsoft.Security.Authentication.OAuth;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Portal
{
    [JsonSerializable(typeof(Dictionary<string, Dictionary<string, string>>))]
    public partial class UrlJsonContext : JsonSerializerContext { }

    [Serializable]
    internal class PortalFetchURLEnvNotSetException : Exception { public PortalFetchURLEnvNotSetException(string message) : base(message) { } }

    internal class Networking
    {
        public static async Task<List<Dictionary<string, string>>> FetchURLsRemote(string fetchURI)
        {
            System.Diagnostics.Debug.WriteLine("Networked fetch called.");

            using HttpClient client = new();

            string content = "";
            try
            {
                content = await client.GetStringAsync(fetchURI);
                FileHelping.WriteLastURLS(content);
            }
            catch (HttpRequestException e)
            {
                System.Diagnostics.Debug.WriteLine($"An error occurred while fetching URLs: {e.Message}");
                System.Diagnostics.Debug.WriteLine($"Attempting to fall back to last local URLs.");
                content = FileHelping.ReadLastURLS();
            }


            List<Dictionary<string, string>> urlDictList = Parsing.ParseToURLList(content);

            return urlDictList;
        }

        
    }
}
