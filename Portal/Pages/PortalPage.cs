// SPDX-License-Identifier: MIT AND Apache 2.0
//
// Portions Copyright (c) Microsoft Corporation
// Licensed under the MIT License. See LICENSE file for details.
//
// Modifications Copyright 2025 Carrier Pigeon Dev (carrierpigeon.dev@gmail.com).
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


using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Portal;

internal sealed partial class PortalPage : ListPage
{
    private List<Dictionary<string, string>> _urlDictList = [];
    private DynamicListItem? _dynamicItem;

    public PortalPage()
    {
        Icon = IconHelpers.FromRelativePath("Assets\\StoreLogo.png");
        Title = "Portal";
        Name = "Open";

        _ = InitializeAsync();
    }
    private async Task InitializeAsync()
    {
        System.Diagnostics.Debug.WriteLine("InitializeAsync started.");
        try
        {
            _dynamicItem = await DynamicListItem.CreateAsync(this);
            System.Diagnostics.Debug.WriteLine("DynamicListItem created.");
            RaiseItemsChanged();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("InitializeAsync failed: " + ex);
        }
    }


    public override IListItem[] GetItems()
    {
        IEnumerable<IListItem> items = _urlDictList
            .Select(entry => { return new ListItem(new PortalOpenURLCommand(entry["url"]))
                {
                    Title = entry["alias"]
                };
            })
            .Cast<IListItem>();

        if (_dynamicItem != null)
        {
            items = items.Append(_dynamicItem);
        }
        else
        {
            items = items.Append(new ListItem(new NoOpCommand())
            {
                Title = "Loading...",
            });
        }

        return items.ToArray();
    }

    internal void UpdateUrls(List<Dictionary<string, string>> newUrlDictList)
    {
        _urlDictList = newUrlDictList;
        RaiseItemsChanged();
    }
}
