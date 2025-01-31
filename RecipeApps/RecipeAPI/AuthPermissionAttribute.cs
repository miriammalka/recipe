﻿using Microsoft.AspNetCore.Mvc;
using RecipeAPI;
using System;

public class AuthPermissionAttribute : TypeFilterAttribute
{
    public AuthPermissionAttribute(int requiredPermissionLevel)
        : base(typeof(AuthFilter))
    {
        Arguments = new object[] { requiredPermissionLevel };
    }
}