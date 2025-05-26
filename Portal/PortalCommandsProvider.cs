// SPDX-License-Identifier: MIT
//
// Copyright (c) Microsoft Corporation
// Licensed under the MIT License. See LICENSE file for details.
//
// Minor modifications made by Carrier Pigeon Dev (carrierpigeon.dev@gmail.com).

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Portal;

public partial class PortalCommandsProvider : CommandProvider
{
    private readonly ICommandItem[] _commands;

    public PortalCommandsProvider()
    {
        DisplayName = "Portal";
        Icon = IconHelpers.FromRelativePath("Assets\\StoreLogo.png");
        _commands = [
            new CommandItem(new PortalPage()) { Title = DisplayName },
        ];
    }

    public override ICommandItem[] TopLevelCommands()
    {
        return _commands;
    }

}
