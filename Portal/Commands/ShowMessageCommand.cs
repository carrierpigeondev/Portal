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
//
// Credit also goes to https://learn.microsoft.com/en-us/windows/powertoys/command-palette/adding-commands
// for code snippet

using Microsoft.CommandPalette.Extensions.Toolkit;
using System.Runtime.InteropServices;

namespace Portal
{
    internal partial class ShowMessageCommand(string title, string message) : InvokableCommand
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        private readonly string __title = title;
        private readonly string __message = message;

        public override CommandResult Invoke()
        {
            // 0x00001000 is MB_SYSTEMMODAL, which will display the message box on top of other windows.
            _ = MessageBox(0, __message, __title, 0x00001000);
            return CommandResult.KeepOpen();
        }
    }
}
