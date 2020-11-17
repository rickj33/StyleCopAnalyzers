﻿// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace StyleCop.Analyzers.Lightup
{
    using System;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal partial struct TupleElementSyntaxWrapper : ISyntaxWrapper<CSharpSyntaxNode>
    {
        private static readonly Func<CSharpSyntaxNode, SyntaxToken> IdentifierAccessor;
        private static readonly Func<CSharpSyntaxNode, TypeSyntax> TypeAccessor;
        private static readonly Func<CSharpSyntaxNode, SyntaxToken, CSharpSyntaxNode> WithIdentifierAccessor;
        private static readonly Func<CSharpSyntaxNode, TypeSyntax, CSharpSyntaxNode> WithTypeAccessor;

        static TupleElementSyntaxWrapper()
        {
            WrappedType = SyntaxWrapperHelper.GetWrappedType(typeof(TupleElementSyntaxWrapper));
            IdentifierAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<CSharpSyntaxNode, SyntaxToken>(WrappedType, nameof(Identifier));
            TypeAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<CSharpSyntaxNode, TypeSyntax>(WrappedType, nameof(Type));
            WithIdentifierAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<CSharpSyntaxNode, SyntaxToken>(WrappedType, nameof(Identifier));
            WithTypeAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<CSharpSyntaxNode, TypeSyntax>(WrappedType, nameof(Type));
        }

        public SyntaxToken Identifier
        {
            get
            {
                return IdentifierAccessor(this.SyntaxNode);
            }
        }

        public TypeSyntax Type
        {
            get
            {
                return TypeAccessor(this.SyntaxNode);
            }
        }

        public TupleElementSyntaxWrapper WithIdentifier(SyntaxToken identifier)
        {
            return new TupleElementSyntaxWrapper(WithIdentifierAccessor(this.SyntaxNode, identifier));
        }

        public TupleElementSyntaxWrapper WithType(TypeSyntax type)
        {
            return new TupleElementSyntaxWrapper(WithTypeAccessor(this.SyntaxNode, type));
        }
    }
}
