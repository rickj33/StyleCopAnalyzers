﻿// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace StyleCop.Analyzers.Lightup
{
    using System;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal partial struct DeclarationPatternSyntaxWrapper : ISyntaxWrapper<CSharpSyntaxNode>
    {
        private static readonly Func<CSharpSyntaxNode, TypeSyntax> TypeAccessor;
        private static readonly Func<CSharpSyntaxNode, CSharpSyntaxNode> DesignationAccessor;
        private static readonly Func<CSharpSyntaxNode, TypeSyntax, CSharpSyntaxNode> WithTypeAccessor;
        private static readonly Func<CSharpSyntaxNode, CSharpSyntaxNode, CSharpSyntaxNode> WithDesignationAccessor;

        static DeclarationPatternSyntaxWrapper()
        {
            WrappedType = SyntaxWrapperHelper.GetWrappedType(typeof(DeclarationPatternSyntaxWrapper));
            TypeAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<CSharpSyntaxNode, TypeSyntax>(WrappedType, nameof(Type));
            DesignationAccessor = LightupHelpers.CreateSyntaxPropertyAccessor<CSharpSyntaxNode, CSharpSyntaxNode>(WrappedType, nameof(Designation));
            WithTypeAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<CSharpSyntaxNode, TypeSyntax>(WrappedType, nameof(Type));
            WithDesignationAccessor = LightupHelpers.CreateSyntaxWithPropertyAccessor<CSharpSyntaxNode, CSharpSyntaxNode>(WrappedType, nameof(Designation));
        }

        public TypeSyntax Type
        {
            get
            {
                return TypeAccessor(this.SyntaxNode);
            }
        }

        public VariableDesignationSyntaxWrapper Designation
        {
            get
            {
                return (VariableDesignationSyntaxWrapper)DesignationAccessor(this.SyntaxNode);
            }
        }

        public static explicit operator DeclarationPatternSyntaxWrapper(PatternSyntaxWrapper node)
        {
            return (DeclarationPatternSyntaxWrapper)node.SyntaxNode;
        }

        public static implicit operator PatternSyntaxWrapper(DeclarationPatternSyntaxWrapper wrapper)
        {
            return PatternSyntaxWrapper.FromUpcast(wrapper.node);
        }

        public DeclarationPatternSyntaxWrapper WithType(TypeSyntax type)
        {
            return new DeclarationPatternSyntaxWrapper(WithTypeAccessor(this.SyntaxNode, type));
        }

        public DeclarationPatternSyntaxWrapper WithDesignation(VariableDesignationSyntaxWrapper designation)
        {
            return new DeclarationPatternSyntaxWrapper(WithDesignationAccessor(this.SyntaxNode, designation.SyntaxNode));
        }
    }
}
