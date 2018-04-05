﻿using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class SoftUniAttribute : Attribute
{
    private string name;

    public SoftUniAttribute(string name)
    {
        this.Name = name;
    }

    public string Name { get => name; set => name = value; }
}