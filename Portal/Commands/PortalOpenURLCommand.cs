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

using Microsoft.CommandPalette.Extensions.Toolkit;
using System.Diagnostics;

namespace Portal
{
    internal partial class PortalOpenURLCommand : InvokableCommand
    {
        private readonly string __url;

        public PortalOpenURLCommand(string url)
        {
            __url = url;
        }

        public string Title => __url;

        public override CommandResult Invoke()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"Trying to open URL '{__url}'");
                Process.Start(new ProcessStartInfo
                {
                    FileName = __url,
                    UseShellExecute = true
                });
                return CommandResult.Hide();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to open URL '{__url}': {e.Message}");
                return CommandResult.ShowToast($"Failed to open URL '{__url}': {e.Message}");
            }
            
        }

    }
}
