﻿namespace Smartwyre.DeveloperTest.Types;

public class CalculateRebateRequest
{
    public string RebateIdentifier { get; set; }

    public string ProductIdentifier { get; set; }

    public decimal Volume { get; set; }

    public CalculateRebateRequest(decimal volume)
    {
        RebateIdentifier = System.Guid.NewGuid().ToString();
        ProductIdentifier = System.Guid.NewGuid().ToString();
        Volume = volume;
    }
}
