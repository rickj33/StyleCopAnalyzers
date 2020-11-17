﻿// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace StyleCop.Analyzers.Lightup
{
    using System;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;

    internal partial struct PatternSyntaxWrapper : ISyntaxWrapper<CSharpSyntaxNode>
    {
        static PatternSyntaxWrapper()
        {
            WrappedType = SyntaxWrapperHelper.GetWrappedType(typeof(PatternSyntaxWrapper));
        }

        internal static PatternSyntaxWrapper FromUpcast(CSharpSyntaxNode node)
        {
            return new PatternSyntaxWrapper(node);
        }
    }
}
